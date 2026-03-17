namespace Terrasoft.Core.Process
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: UsrStatisticsCollectorTaskBPMethodsWrapper

	/// <exclude/>
	public class UsrStatisticsCollectorTaskBPMethodsWrapper : ProcessModel
	{

		public UsrStatisticsCollectorTaskBPMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
			AddScriptTaskMethod("ScriptTask2Execute", ScriptTask2Execute);
			AddScriptTaskMethod("ScriptTask3Execute", ScriptTask3Execute);
			AddScriptTaskMethod("ScriptTask4Execute", ScriptTask4Execute);
			AddScriptTaskMethod("ScriptTask5Execute", ScriptTask5Execute);
			AddScriptTaskMethod("ScriptTask6Execute", ScriptTask6Execute);
			AddScriptTaskMethod("ScriptTask7Execute", ScriptTask7Execute);
			AddScriptTaskMethod("ScriptTask8Execute", ScriptTask8Execute);
			AddScriptTaskMethod("ScriptTask9Execute", ScriptTask9Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			string instanceUId = context.Process.InstanceUId;
			Guid businessProcessLogId;
			if (!Guid.TryParse(instanceUId, out businessProcessLogId))
			{
			    businessProcessLogId = Guid.Empty;
			}
			Set<Guid>("UsrProcessLogId", businessProcessLogId);
			return true;
		}

		private bool ScriptTask2Execute(ProcessExecutingContext context) {
			Guid statisticsCollectTaskId = Get<Guid>("UsrStatisticsCollectTaskId");
			CollectStatistics(statisticsCollectTaskId);
			return true;
		}

		private bool ScriptTask3Execute(ProcessExecutingContext context) {
			DateTime startDateTimeValue = Get<DateTime>("UsrStartDateTimeToCollect");
			DateTime endDateTimeValue = Get<DateTime>("UsrEndDateTimeToCollect");
			int differenceInSeconds = DifferenceBetweenStartAndEndDateTimes(startDateTimeValue, endDateTimeValue);
			Set<int>("UsrDifferenceInSecondsForStatsCollect", differenceInSeconds);
			return true;
		}

		private bool ScriptTask4Execute(ProcessExecutingContext context) {
			DateTime startDateTime = Get<DateTime>("UsrStartDateTimeToCollect");
			int differenceInSeconds = DifferenceBetweenCurrentDateTimeAndTargetDateTime(startDateTime);
			Set<int>("UsrDifferenceInSecondsForStartingStatsCollect", differenceInSeconds);
			return true;
		}

		private bool ScriptTask5Execute(ProcessExecutingContext context) {
			ClearCurrentStatistics();
			return true;
		}

		private bool ScriptTask6Execute(ProcessExecutingContext context) {
			Guid statisticsCollectTaskId = Get<Guid>("UsrStatisticsCollectTaskId");
			CollectStatistics(statisticsCollectTaskId);
			return true;
		}

		private bool ScriptTask7Execute(ProcessExecutingContext context) {
			DateTime endDateTime = Get<DateTime>("UsrEndDateTimeToCollect");
			int differenceInSeconds = DifferenceBetweenCurrentDateTimeAndTargetDateTime(endDateTime);
			Set<int>("UsrDifferenceInSecondsForStartingStatsCollect", differenceInSeconds);
			return true;
		}

		private bool ScriptTask8Execute(ProcessExecutingContext context) {
			ClearCurrentStatistics();
			return true;
		}

		private bool ScriptTask9Execute(ProcessExecutingContext context) {
			Guid statisticsCollectTaskId = Get<Guid>("UsrStatisticsCollectTaskId");
			CollectStatistics(statisticsCollectTaskId);
			return true;
		}

			private void CollectStatistics(Guid statisticsCollectTaskId)
			{
				var storedProcedure = new StoredProcedure(UserConnection, "ufn_CollectPgStatStatements");
				storedProcedure.WithParameter(statisticsCollectTaskId);
				try
				{
					using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection())
					{
						dbExecutor.CommandTimeout = 30;
						storedProcedure.Execute(dbExecutor);
					}
				}
				catch (Exception e)
				{
					Set<string>("UsrExceptionErrorDetails", e.ToString());
				}
			}
			
			private void ClearCurrentStatistics()
			{
				var storedProcedure = new StoredProcedure(UserConnection, "ufn_ClearPgStatStatements");
				try
				{
					using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection())
					{
						dbExecutor.CommandTimeout = 30;
						storedProcedure.Execute(dbExecutor);
					}
				}
				catch (Exception e)
				{
					Set<string>("UsrExceptionErrorDetails", e.ToString());
				}
			}
			
			private int DifferenceBetweenStartAndEndDateTimes(DateTime startDateTime, DateTime endDateTime)
			{
				TimeSpan difference = endDateTime - startDateTime;
				int differenceInSeconds = (int)difference.TotalSeconds;
				return differenceInSeconds;
			}
			
			private int DifferenceBetweenCurrentDateTimeAndTargetDateTime(DateTime targetDateTime)
			{
				var currentUser = UserConnection.CurrentUser;
				DateTime currentDateTime = currentUser.GetCurrentDateTime();
				return DifferenceBetweenStartAndEndDateTimes(currentDateTime, targetDateTime);
			}

		#endregion

	}

	#endregion

}

