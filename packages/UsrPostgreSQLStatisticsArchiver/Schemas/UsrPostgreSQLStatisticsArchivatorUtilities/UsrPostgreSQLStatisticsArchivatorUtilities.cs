namespace Terrasoft.Configuration
{
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core.Factories;


	#region Class: UsrPostgreSQLStatisticsArchivatorUtilities
	/// <summary>
	/// Utilities for interaction with mailing handlers.
	/// </summary>
	public static class UsrPostgreSQLStatisticsArchivatorUtilities
	{

		#region Methods: Private

		private static EntityCollection GetArchivatorHandlers(UserConnection userConnection) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "UsrPostgreSQLStatisticsArchivators");
			esq.AddColumn("UsrName");
			esq.AddColumn("UsrClassName");
			var collection = esq.GetEntityCollection(userConnection);
			return collection;
		}
		
		private static void ActivateHandlers(IEnumerable<UsrIArchivatorHandler> handlers, UserConnection userConnection) {
			foreach(var handler in handlers) {
				try {
					handler.CreateInstance(userConnection);
				} catch (Exception e) {
				}
			}
		}
		
		private static IEnumerable<UsrIArchivatorHandler> InstantiateHandlers(IEnumerable<string> handlersClassNames) {
			List<UsrIArchivatorHandler> handlers = new List<UsrIArchivatorHandler>();
			foreach(string className in handlersClassNames) {
				var workspaceTypeProvider = ClassFactory.Get<IWorkspaceTypeProvider>();
				Type classType = workspaceTypeProvider.GetType(className);
				if (classType != null) {
					try {
						var archivatorHandler = Activator.CreateInstance(classType) as UsrIArchivatorHandler;
						handlers.Add(archivatorHandler);
					} catch (Exception e) {
					}
				}
			}
			return handlers;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Enables handlers of the active archivators.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		public static void EnableActiveProviderHandlers(UserConnection userConnection) {
			EntityCollection archivatorHandlers = GetArchivatorHandlers(userConnection);
			IEnumerable<string> activeHandlersNames =
				archivatorHandlers.Select(_ => _.GetTypedColumnValue<string>("ClassName")).Distinct();
			IEnumerable<UsrIArchivatorHandler> activeHandlers = InstantiateHandlers(activeHandlersNames);
			ActivateHandlers(activeHandlers, userConnection);
		}
		#endregion

	}

	#endregion

}