namespace Terrasoft.Configuration
{
    using Terrasoft.Core;
    using Terrasoft.Web.Common;
    using global::Common.Logging;

    #region Class: UsrPostgreSQLStatisticAppEventListener

    /// <summary>
    /// Represents methods to initialize package.
    /// </summary>
    public class UsrPostgreSQLStatisticAppEventListener : AppEventListenerBase
    {

        #region Fields: Private

        private UserConnection _userConnection;
        private static readonly ILog _log = LogManager.GetLogger("UsrPostgreSQLStatisticsArchivationLogger");

        #endregion

        #region Methods: Private

        private UserConnection GetUserConnection(AppEventContext context)
        {
            if (_userConnection == null)
            {
                var appConection = context.Application["AppConnection"] as AppConnection;
                _userConnection = appConection.SystemUserConnection;
            }
            return _userConnection;
        }

        #endregion

        #region Methods: Public

        /// <summary>
        /// Binds packages <see cref="ClassFactory"/> items.
        /// </summary>
        /// <param name="context">Instance of <see cref="AppEventContext"/>.</param>
        public override void OnAppStart(AppEventContext context)
        {
            var userConnection = GetUserConnection(context);
            _log.Warn("App started. Initializing UsrPostgreSQLStatisticAppEventListener.");
            UsrPostgreSQLStatisticsArchivatorUtilities.EnableActiveArchivationHandlers(userConnection);
        }

        #endregion

    }

    #endregion

}