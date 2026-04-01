namespace Terrasoft.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Terrasoft.Core;
    using Terrasoft.Core.DB;
    using Terrasoft.Core.Entities;

    #region Class: UsrPostgreSQLTasksArchiver

    public class UsrPostgreSQLTasksArchiver
    {

        #region Fields: Private

        private readonly DBExecutor _dbExecutor;
        private readonly UserConnection _userConnection;
        private readonly int _batchSize = 5000;

        //List of main tables and archive tables
        private readonly string _statisticsCollectTasksTableName = "UsrStatisticsCollectTa";
        private readonly string _statisticsCollectTasksArchiveTableName = "UsrStatisticsCollectTasksArchive";
        private readonly string _statisticsCollectParamsTableName = "UsrStatsCollectParams";
        private readonly string _statisticsCollectParamsArchiveTableName = "UsrStatsCollectParamsArchive";
        private readonly string _pgStatStatementsTotalExecTimeTableName = "UsrPgStatStatementsTotalExecTime";
        private readonly string _pgStatStatementsTotalExecTimeArchiveTableName = "UsrPgStatStatementsTotalExecTimeArchive";
        private readonly string _pgStatStatementsCallsTableName = "UsrPgStatStatementsCalls";
        private readonly string _pgStatStatementsCallsArchiveTableName = "UsrPgStatStatementsCallsArchive";

        #endregion

        #region Constructors: Public

        public UsrPostgreSQLTasksArchiver(DBExecutor dbExecutor)
        {
            _dbExecutor = dbExecutor;
            _userConnection = _dbExecutor.UserConnection;
        }

        #endregion

        #region Methods: Private

        private Select GetUsrStatisticsCollectTaskArchivingQuery(string sourceSchemaName, string targetSchemaName,
            DateTime archivePeriod, List<string> columnList)
        {
            var selectQuery = new Select(_userConnection);
            foreach (string column in columnList)
            {
                selectQuery.Column("s", column);
            }
            selectQuery.Top(_batchSize);
            selectQuery.From(sourceSchemaName).As("s").WithHints(Hints.NoLock)
                .Where("s", "ModifiedOn").IsLessOrEqual(new QueryParameter(archivePeriod))
                .And().Not().Exists(new Select(_userConnection)
                .Column(Column.Parameter(1))
                .From(targetSchemaName).As("t")
                .Where("t", "Id")
                .IsEqual("s", "Id"))
                .OrderByDesc("s", "Id");
            return selectQuery;
        }

        private Select GetUsrStatisticsCollectParamsArchivingQuery(string sourceSchemaName, DateTime archivePeriod, List<string> columnList)
        {
            var selectQuery = new Select(_userConnection);
            selectQuery.Top(_batchSize);
            foreach (string column in columnList)
            {
                selectQuery.Column("scp", column);
            }
            selectQuery.From(sourceSchemaName).As("scp").WithHints(Hints.NoLock)
                .Where("scp", "ModifiedOn").IsLessOrEqual(new QueryParameter(archivePeriod))
                .And().Exists(new Select(_userConnection)
                    .Column(Column.Parameter(1))
                    .From(_statisticsCollectTasksArchiveTableName).As("scta")
                    .Where("scp", "UsrStatisticsCollectTaskId").IsEqual("scta", "Id"));
            return selectQuery;
        }

        private Select UsrPgStatStatementsTotalExecTimeArchivingQuery(string sourceSchemaName, DateTime archivePeriod, List<string> columnList)
        {
            var selectQuery = new Select(_userConnection);
            foreach (string column in columnList)
            {
                selectQuery.Column("sstet", column);
            }
            selectQuery.Top(_batchSize);
            selectQuery.From(sourceSchemaName).As("sstet")
                .WithHints(Hints.NoLock)
                .Where("sstet", "ModifiedOn").IsLessOrEqual(new QueryParameter(archivePeriod))
                .And().Exists(new Select(_userConnection)
                    .Column(Column.Parameter(1))
                    .From(_statisticsCollectTasksArchiveTableName).As("sct")
                    .Where("sstet", "UsrStatisticsCollectTaskId").IsEqual("sct", "Id"));
            return selectQuery;
        }

        private Select UsrPgStatStatementsCallsArchivingQuery(string sourceSchemaName, DateTime archivePeriod, List<string> columnList)
        {
            var selectQuery = new Select(_userConnection);
            foreach (string column in columnList)
            {
                selectQuery.Column("ssc", column);
            }
            selectQuery.Top(_batchSize);
            selectQuery.From(sourceSchemaName).As("ssc").WithHints(Hints.NoLock)
                .Where("ssc", "ModifiedOn").IsLessOrEqual(new QueryParameter(archivePeriod))
                .And().Exists(new Select(_userConnection)
                    .Column(Column.Parameter(1))
                    .From(_statisticsCollectTasksArchiveTableName).As("sct")
                    .Where("ssc", "UsrStatisticsCollectTaskId").IsEqual("sct", "Id"));
            return selectQuery;
        }

        private List<string> GetSchemaColumnsNames(string schemaName)
        {
            EntitySchemaManager manager = _userConnection.EntitySchemaManager;
            var schema = manager.GetInstanceByName(schemaName);
            var columnList = schema.Columns.Select(col => col.ColumnValueName).ToList();
            return columnList;
        }

        private void DeleteStatisticsCollectParams()
        {
            int processedRecords;
            do
            {
                var deleteQuery = new Delete(_userConnection).From(_statisticsCollectParamsTableName)
                    .Where().Exists(new Select(_userConnection)
                        .Column(Column.Parameter(1))
                        .From(_statisticsCollectParamsArchiveTableName)
                        .Where(_statisticsCollectParamsArchiveTableName, "Id")
                        .IsEqual(_statisticsCollectParamsTableName, "Id"));
                processedRecords = deleteQuery.Execute(_dbExecutor);
            }
            while (processedRecords != 0);
        }

        private void DeletePgStatStatementsTotalExecTime()
        {
            int processedRecords;
            do
            {
                var deleteQuery = new Delete(_userConnection).From(_pgStatStatementsTotalExecTimeTableName)
                    .Where().Exists(new Select(_userConnection)
                        .Column(Column.Parameter(1))
                        .From(_pgStatStatementsTotalExecTimeArchiveTableName)
                        .Where(_pgStatStatementsTotalExecTimeArchiveTableName, "Id")
                        .IsEqual(_pgStatStatementsTotalExecTimeTableName, "Id"));
                processedRecords = deleteQuery.Execute(_dbExecutor);
            }
            while (processedRecords != 0);
        }

        private void DeletePgStatStatementsCalls()
        {
            int processedRecords;
            do
            {
                var deleteQuery = new Delete(_userConnection).From(_pgStatStatementsCallsTableName)
                    .Where().Exists(new Select(_userConnection)
                        .Column(Column.Parameter(1))
                        .From(_pgStatStatementsCallsArchiveTableName)
                        .Where(_pgStatStatementsCallsArchiveTableName, "Id")
                        .IsEqual(_pgStatStatementsCallsTableName, "Id"));
                processedRecords = deleteQuery.Execute(_dbExecutor);
            }
            while (processedRecords != 0);
        }

        private void DeletePgStatStatementsTasks(string sourceSchemaName, string targetSchemaName)
        {
            int processedRecords;
            do
            {
                var deleteQuery = new Delete(_userConnection).From(sourceSchemaName)
                    .Where("Id").In(new Select(_userConnection)
                        .Top(_batchSize)
                        .Column("s", "Id")
                        .From(sourceSchemaName).As("s")
                        .Where().Exists(new Select(_userConnection)
                            .Column(Column.Parameter(1))
                            .From(targetSchemaName)
                            .Where(targetSchemaName, "Id")
                            .IsEqual("s", "Id")));
                processedRecords = deleteQuery.Execute(_dbExecutor);
            }
            while (processedRecords != 0);
        }

        private int InsertArchiveLevel(string sourceSchemaName, string targetSchemaName, DateTime archivePeriod)
        {
            var columnsList = GetSchemaColumnsNames(targetSchemaName);
            var oldUsrStatisticsCollectTaskSelect =
                GetUsrStatisticsCollectTaskArchivingQuery(sourceSchemaName, targetSchemaName, archivePeriod, columnsList);
            var insertSelectCommand = new InsertSelect(_userConnection)
                .Into(targetSchemaName).Set(columnsList).FromSelect(oldUsrStatisticsCollectTaskSelect);
            return insertSelectCommand.Execute(_dbExecutor);
        }

        private int InsertArchiveStatisticsCollectParamsLevel(string sourceSchemaName, string targetSchemaName, DateTime archivePeriod)
        {
            var columnsList = GetSchemaColumnsNames(_statisticsCollectParamsTableName);
            Select oldStatisticsCollectParamsSelectQuery = GetUsrStatisticsCollectParamsArchivingQuery(sourceSchemaName, archivePeriod, columnsList);
            var insertSelectCommand = new InsertSelect(_userConnection)
                .Into(targetSchemaName).Set(columnsList).FromSelect(oldStatisticsCollectParamsSelectQuery);
            return insertSelectCommand.Execute(_dbExecutor);
        }

        private int InsertArchivePgStatStatementsTotalExecTimeLevel(string sourceSchemaName, string targetSchemaName, DateTime archivePeriod)
        {
            var columnsList = GetSchemaColumnsNames(_pgStatStatementsTotalExecTimeTableName);
            Select oldPgStatStatementsTotalExecTimeSelectQuery = UsrPgStatStatementsTotalExecTimeArchivingQuery(sourceSchemaName, archivePeriod, columnsList);
            var insertSelectCommand = new InsertSelect(_userConnection)
                .Into(targetSchemaName).Set(columnsList).FromSelect(oldPgStatStatementsTotalExecTimeSelectQuery);
            return insertSelectCommand.Execute(_dbExecutor);
        }

        private int InsertArchivePgStatStatementsCallsLevel(string sourceSchemaName, string targetSchemaName, DateTime archivePeriod)
        {
            var columnsList = GetSchemaColumnsNames(_pgStatStatementsCallsTableName);
            Select oldPgStatStatementsCallsSelectQuery = UsrPgStatStatementsCallsArchivingQuery(sourceSchemaName, archivePeriod, columnsList);
            var insertSelectCommand = new InsertSelect(_userConnection)
                .Into(targetSchemaName).Set(columnsList).FromSelect(oldPgStatStatementsCallsSelectQuery);
            return insertSelectCommand.Execute(_dbExecutor);
        }

        /*  Delete archive zone */

        private void DeleteStatisticsCollectParamsArchive(DateTime archivePeriod)
        {
            var deleteQuery = new Delete(_userConnection).From(_statisticsCollectParamsArchiveTableName)
                .Where("ModifiedOn").IsLessOrEqual(new QueryParameter(archivePeriod))
                .And().Exists(new Select(_userConnection).From(_statisticsCollectTasksArchiveTableName)
                    .Where("ModifiedOn").IsLessOrEqual(new QueryParameter(archivePeriod))
                    .And(_statisticsCollectTasksArchiveTableName, "Id").IsEqual(_statisticsCollectParamsArchiveTableName, "UsrStatisticsCollectTaskId"));
            deleteQuery.Execute(_dbExecutor);
        }

        private void DeletePgStatStatementsTotalExecTimeArchive(DateTime archivePeriod)
        {
            var deleteQuery = new Delete(_userConnection).From(_pgStatStatementsTotalExecTimeArchiveTableName)
                .Where("ModifiedOn").IsLessOrEqual(new QueryParameter(archivePeriod))
                .And().Exists(new Select(_userConnection).From(_statisticsCollectTasksArchiveTableName)
                    .Where("ModifiedOn").IsLessOrEqual(new QueryParameter(archivePeriod))
                    .And(_statisticsCollectTasksArchiveTableName, "Id").IsEqual(_pgStatStatementsTotalExecTimeArchiveTableName, "UsrStatisticsCollectTaskId"));
            deleteQuery.Execute(_dbExecutor);
        }

        private void DeletePgStatStatementsCallsArchive(DateTime archivePeriod)
        {
            var deleteQuery = new Delete(_userConnection).From(_pgStatStatementsCallsArchiveTableName)
                .Where("ModifiedOn").IsLessOrEqual(new QueryParameter(archivePeriod))
                .And().Exists(new Select(_userConnection).From(_statisticsCollectTasksArchiveTableName)
                    .Where("ModifiedOn").IsLessOrEqual(new QueryParameter(archivePeriod))
                    .And(_statisticsCollectTasksArchiveTableName, "Id").IsEqual(_pgStatStatementsCallsArchiveTableName, "UsrStatisticsCollectTaskId"));
            deleteQuery.Execute(_dbExecutor);
        }

        private int DeleteStatisticsCollectTasksArchive(DateTime archivePeriod)
        {
            int processedRecords;
            do
            {
                var deleteQuery = new Delete(_userConnection).From(_statisticsCollectTasksArchiveTableName)
                .Where("ModifiedOn").IsLessOrEqual(new QueryParameter(archivePeriod));
                processedRecords = deleteQuery.Execute(_dbExecutor);
            }
            while (processedRecords != 0);
            return processedRecords;
        }

        /*  End delete archive zone */

        #endregion

        #region Methods: Public

        public int Archive(DateTime archivePeriod, DateTime archiveRemovePeriod)
        {
            /*  Insert to archive tables */
            var insertedCount = InsertArchiveLevel(_statisticsCollectTasksTableName, _statisticsCollectTasksArchiveTableName, archivePeriod);
            InsertArchiveStatisticsCollectParamsLevel(_statisticsCollectParamsTableName, _statisticsCollectParamsArchiveTableName, archivePeriod);
            InsertArchivePgStatStatementsTotalExecTimeLevel(_pgStatStatementsTotalExecTimeTableName, _pgStatStatementsTotalExecTimeArchiveTableName, archivePeriod);
            InsertArchivePgStatStatementsCallsLevel(_pgStatStatementsCallsTableName, _pgStatStatementsCallsArchiveTableName, archivePeriod);
            /*  End insert to archive tables */

            /*  Delete from main tables */
            DeleteStatisticsCollectParams();
            DeletePgStatStatementsTotalExecTime();
            DeletePgStatStatementsCalls();
            DeletePgStatStatementsTasks(_statisticsCollectTasksTableName, _statisticsCollectTasksArchiveTableName);
            /*  End delete from main tables */

            /*  Delete archive zone */
            DeleteStatisticsCollectParamsArchive(archiveRemovePeriod);
            DeletePgStatStatementsTotalExecTimeArchive(archiveRemovePeriod);
            DeletePgStatStatementsCallsArchive(archiveRemovePeriod);
            DeleteStatisticsCollectTasksArchive(archiveRemovePeriod);
            /*  End delete archive zone */
            return insertedCount;
        }

        #endregion

    }

    #endregion

}

