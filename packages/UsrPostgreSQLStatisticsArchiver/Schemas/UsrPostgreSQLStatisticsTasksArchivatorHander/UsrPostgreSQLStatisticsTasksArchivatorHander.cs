namespace Terrasoft.Configuration
{
    using Quartz;
    using Quartz.Impl.Triggers;
    using System;
    using Terrasoft.Core;
    using Terrasoft.Core.Scheduler;

    #region Class: UsrPostgreSQLStatisticsTasksArchivatorHandler

    /// <summary>
    /// Handler for UsrPostgreSQLTasks archiver.
    /// </summary>
    public class UsrPostgreSQLStatisticsTasksArchivatorHandler : UsrBasePostgreSQLStatisticsTasksArchivatorHandler
    {

        #region Constants: Private

        private const string CronExpression = "0 0 0 ? * * *";

        #endregion

        #region Properties: Protected

        protected override string JobName { get; } = "ArchiveUsrPostgreSQLTasks";

        protected override string ProcessName => throw new NotImplementedException();

        #endregion

        #region Methods: Public

        /// <summary>
        /// Creates instance of the handler.
        /// </summary>
        /// <param name="userConnection">Instance of user connection.</param>
        public override void CreateInstance(UserConnection userConnection)
        {
            if (AppScheduler.DoesJobExist(JobName, JobGroupName))
            {
                return;
            }
            var job = AppScheduler.CreateClassJob<UsrPostgreSQLTasksArchiveJobExecutor>(JobName, JobGroupName, userConnection, null, true);
            var trigger = new CronTriggerImpl(JobName + "Trigger",
                JobGroupName, CronExpression);
            trigger.TimeZone = TimeZoneInfo.Local;
            trigger.MisfireInstruction = MisfireInstruction.CronTrigger.FireOnceNow;
            AppScheduler.Instance.ScheduleJob(job, trigger);
        }

        #endregion
    }

    #endregion

}

