namespace Terrasoft.Configuration
{
    using Quartz;
    using Quartz.Impl.Triggers;
    using System;
    using Terrasoft.Core;
    using Terrasoft.Core.Scheduler;
    using global::Common.Logging;

    #region Class: UsrPostgreSQLStatisticsTasksArchivatorHandler

    /// <summary>
    /// Handler for UsrPostgreSQLTasks archiver.
    /// </summary>
    public class UsrPostgreSQLStatisticsTasksArchivatorHandler : UsrBasePostgreSQLStatisticsTasksArchivatorHandler
    {

        #region Constants: Private

        private const string CronExpression = "0 */5 * * * ?";

        #endregion

        #region Properties: Protected

        protected override string JobName { get; } = "ArchiveUsrPostgreSQLTasks";

        protected override string ProcessName => throw new NotImplementedException();

        #endregion

        #region Fields: Private

        private static readonly ILog _log = LogManager.GetLogger("UsrPostgreSQLStatisticsArchivationLogger");

        #endregion

        #region Methods: Public

        /// <summary>
        /// Creates instance of the handler.
        /// </summary>
        /// <param name="userConnection">Instance of user connection.</param>
        public override void CreateInstance(UserConnection userConnection)
        {
            _log.Warn("Entered CreateInstance method");
            if (AppScheduler.DoesJobExist(JobName, JobGroupName))
            {
                _log.Warn("Entered DoesJobExists");
                return;
            }
            _log.Warn("Scheduling job");
            try
            {
                var job = AppScheduler.CreateClassJob<UsrPostgreSQLTasksArchiveJobExecutor>(JobName, JobGroupName, userConnection, null, true);
                var trigger = new CronTriggerImpl(JobName + "Trigger",
                    JobGroupName, CronExpression);
                trigger.TimeZone = TimeZoneInfo.Local;
                trigger.MisfireInstruction = MisfireInstruction.CronTrigger.FireOnceNow;
                AppScheduler.Instance.ScheduleJob(job, trigger);
            }
            catch (Exception e)
            {
                _log.Error("Error while scheduling job", e);
            }
            _log.Warn("Job scheduled");
        }

        #endregion
    }

    #endregion

}

