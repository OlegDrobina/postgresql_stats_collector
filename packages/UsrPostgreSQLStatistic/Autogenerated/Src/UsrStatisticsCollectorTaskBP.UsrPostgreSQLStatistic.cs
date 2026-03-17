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
			CollectCurrentlyCollectedStatistics(statisticsCollectTaskId);
			return true;
		}

			private void CollectCurrentlyCollectedStatistics(Guid statisticsCollectTaskId)
			{
				var storedProcedure = new StoredProcedure(UserConnection, "ufn_CollectPgStatStatementsTotalExecTime");
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

		#endregion

	}

	#endregion

}

