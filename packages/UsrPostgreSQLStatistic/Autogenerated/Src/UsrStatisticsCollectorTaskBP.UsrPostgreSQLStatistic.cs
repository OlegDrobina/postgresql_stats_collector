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

		#endregion

	}

	#endregion

}

