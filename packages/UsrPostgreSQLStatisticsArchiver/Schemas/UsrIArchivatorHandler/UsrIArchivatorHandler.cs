namespace Terrasoft.Configuration
{
	using Terrasoft.Core;

	#region Interface: UsrIArchivatorHandler

	/// <summary>
	/// Provides interface for the mailing handler.
	/// </summary>
	public interface UsrIArchivatorHandler
	{

		#region Methods: Public

		/// <summary>
		/// Creates instance of the handler.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		void CreateInstance(UserConnection userConnection);

		/// <summary>
		/// Removes instance of the handler.
		/// </summary>
		void RemoveInstance();

		#endregion

	}

	#endregion

}
