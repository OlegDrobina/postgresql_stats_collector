namespace Terrasoft.Configuration
{
    using Polly;
    using System;
    using System.Collections.Generic;
    using Terrasoft.Core;
    using Terrasoft.Core.DB;
    using CoreSysSettings = Terrasoft.Core.Configuration.SysSettings;
    using global::Common.Logging;

    #region Class: UsrPostgreSQLTasksArchiveJobExecutor

    public class UsrPostgreSQLTasksArchiveJobExecutor : IJobExecutor
    {

        #region Constants: Private

        private const string ArchivingTableName = "archivingTableName";
        private const string ArchiveTableName = "UsrStatisticsCollectTaskArchive";
        private const string UsrStatisticsCollectTaTableName = "UsrStatisticsCollectTa";
        private const string DbExecutor = "dbExecutor";
        private const string RecordsToProcessCount = "recordsToProcessCount";
        private const string ArchiveDate = "archiveDate";
        private const string _retryContextName = "UsrStatisticsCollectTaArchivePolicy";
        private const int RetryCount = 3;
        private static readonly ILog _log = LogManager.GetLogger("UsrPostgreSQLTasksArchive");

        #endregion

        #region Fields: Private

        private UsrPostgreSQLTasksArchiver _dataArchiver;
        private int _archivationPeriod;
        private int _iterationSize;
        private bool _isStatisticsArchivatorEnabled;
        private Policy _policy;
        private Context _retryContext;
        private UserConnection _userConnection;

        #endregion

        #region Methods: Private

        private static void OnRetry(Context context, int retryIteration, Exception exception)
        {
            (context[DbExecutor] as DBExecutor)?.RollbackTransaction();
            _log.WarnFormat(
                "[UsrStatisticsCollectTaskArchive.DeleteArchiveLevel. Error while archiving UsrStatisticsCollectTa. Rollback transaction. " +
                $"RecordsToProcess: {context[RecordsToProcessCount]} " +
                $"Archiving table name: {context[ArchivingTableName]} " + $"Iteration: {retryIteration}.", exception);
        }

        private void Archive()
        {
            ArchiveLevelSafe(UsrStatisticsCollectTaTableName, ArchiveTableName, _archivationPeriod);
            //ArchiveLevelSafe(BetFirstTableName, BetSecondTableName, _secondPeriodNumberOfDays);
        }

        private void ArchiveLevelSafe(string sourceTableName, string targetTableName, int archivingPeriod)
        {
            PrepareRetryContext(sourceTableName, archivingPeriod);
            _policy.Execute(() => TransferArchiveLevel(sourceTableName, targetTableName),
                _retryContext);
        }

        private void InitializeArchiving()
        {
            _policy = Policy.Handle<Exception>()
                .Retry(RetryCount, (exception, retryIteration, context) => OnRetry(context, retryIteration, exception));
            _iterationSize = CoreSysSettings.GetValue(_userConnection, "UsrStatisticsCollectorArchivationIterationSize", 10000);
            _archivationPeriod =
                CoreSysSettings.GetValue(_userConnection, "UsrStatisticsCollectorArchivationPeriod", 365);
            _isStatisticsArchivatorEnabled =
                CoreSysSettings.GetValue(_userConnection, "UsrStatisticsCollectorArchivationEnabled", false);
        }

        private void PrepareRetryContext(string schemaName, int periodDays)
        {
            var archiveDate = DateTime.Today.AddDays(-periodDays);
            _retryContext = new Context(_retryContextName, new Dictionary<string, object> {
                { ArchivingTableName, schemaName },
                { RecordsToProcessCount,  _iterationSize} ,
                { ArchiveDate, archiveDate }
            });
        }

        private void TransferArchiveLevel(string sourceSchemaName, string targetSchemaName)
        {
            using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection())
            {
                _retryContext[DbExecutor] = dbExecutor;
                _dataArchiver = new UsrPostgreSQLTasksArchiver(dbExecutor);
                DateTime archiveDate = (DateTime)_retryContext[ArchiveDate];
                int processedRecords;
                do
                {
                    dbExecutor.StartTransaction();
                    processedRecords = _dataArchiver.Archive(sourceSchemaName, targetSchemaName, archiveDate);
                    dbExecutor.CommitTransaction();
                    _retryContext[RecordsToProcessCount] = (int)_retryContext[RecordsToProcessCount] - processedRecords;
                }
                while ((int)_retryContext[RecordsToProcessCount] > 0 && processedRecords > 0);
            }
        }

        #endregion

        #region Methods: Public

        public void Execute(UserConnection userConnection, IDictionary<string, object> parameters)
        {
            _userConnection = userConnection;
            InitializeArchiving();
            if (_isStatisticsArchivatorEnabled)
            {
                Archive();
            }
        }

        #endregion

    }

    #endregion

}

