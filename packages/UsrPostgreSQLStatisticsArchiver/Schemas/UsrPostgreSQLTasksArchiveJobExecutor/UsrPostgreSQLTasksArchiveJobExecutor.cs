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
        private const string ArchiveTableName = "UsrStatisticsCollectTasksArchive";
        private string ArchiveRemoveDate = "archiveRemoveDate";
        private const string UsrStatisticsCollectTaTableName = "UsrStatisticsCollectTa";
        private const string DbExecutor = "dbExecutor";
        private const string RecordsToProcessCount = "recordsToProcessCount";
        private const string ArchiveDate = "archiveDate";
        private const string _retryContextName = "UsrStatisticsCollectTaArchivePolicy";
        private const int RetryCount = 3;
        private static readonly ILog _log = LogManager.GetLogger("UsrPostgreSQLStatisticsArchivationLogger");

        #endregion

        #region Fields: Private

        private UsrPostgreSQLTasksArchiver _dataArchiver;
        private int _archivationPeriod;
        private int _archiveRemovalPeriod;
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
                "[UsrStatisticsCollectTasksArchive.DeleteArchiveLevel. Error while archiving UsrStatisticsCollectTa. Rollback transaction. " +
                $"RecordsToProcess: {context[RecordsToProcessCount]} " +
                $"Archiving table name: {context[ArchivingTableName]} " + $"Iteration: {retryIteration}.", exception);
        }

        private void Archive()
        {
            ExecuteArchiveSafe(UsrStatisticsCollectTaTableName, ArchiveTableName, _archivationPeriod, _archiveRemovalPeriod);
        }

        private void ExecuteArchiveSafe(string sourceTableName, string targetTableName, int archivingPeriod, int archiveRemovalPeriod)
        {
            PrepareRetryContext(sourceTableName, archivingPeriod, archiveRemovalPeriod);
            _policy.Execute(() => ProcessArchive(sourceTableName, targetTableName),
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
            _archiveRemovalPeriod =
                CoreSysSettings.GetValue(_userConnection, "UsrStatisticsCollectorArchiveRemovalPeriod", 455);
        }

        private void PrepareRetryContext(string schemaName, int periodDays, int archiveRemovalPeriod)
        {
            var archiveDate = DateTime.Today.AddDays(-periodDays);
            var archiveRemoveDate = DateTime.Today.AddDays(-archiveRemovalPeriod);
            _retryContext = new Context(_retryContextName, new Dictionary<string, object> {
                { ArchivingTableName, schemaName },
                { RecordsToProcessCount,  _iterationSize },
                { ArchiveDate, archiveDate },
                { ArchiveRemoveDate, archiveRemoveDate }
            });
        }

        private void ProcessArchive(string sourceSchemaName, string targetSchemaName)
        {
            using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection())
            {
                _retryContext[DbExecutor] = dbExecutor;
                _dataArchiver = new UsrPostgreSQLTasksArchiver(dbExecutor);
                DateTime archiveDate = (DateTime)_retryContext[ArchiveDate];
                DateTime archiveRemoveDate = (DateTime)_retryContext[ArchiveRemoveDate];
                int processedRecords;
                do
                {
                    dbExecutor.StartTransaction();
                    processedRecords = _dataArchiver.Archive(archiveDate, archiveRemoveDate);
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
                _log.Warn("Starting archivation of UsrStatisticsCollectTa");
                Archive();
            }
        }

        #endregion

    }

    #endregion

}

