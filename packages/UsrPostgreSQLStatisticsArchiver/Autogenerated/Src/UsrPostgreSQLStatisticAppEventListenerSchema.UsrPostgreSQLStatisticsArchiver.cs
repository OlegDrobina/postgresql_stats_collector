namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: UsrPostgreSQLStatisticAppEventListenerSchema

	/// <exclude/>
	public class UsrPostgreSQLStatisticAppEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UsrPostgreSQLStatisticAppEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UsrPostgreSQLStatisticAppEventListenerSchema(UsrPostgreSQLStatisticAppEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d6c2229c-b577-45e0-9096-14de3176184e");
			Name = "UsrPostgreSQLStatisticAppEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("31d71ee4-dddf-4c07-b20f-9d219e37600c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,147,77,107,220,48,16,134,207,27,200,127,24,220,75,122,177,239,217,15,72,66,83,10,41,77,187,13,57,148,82,38,246,216,21,181,37,49,26,155,110,67,254,123,103,101,59,196,222,208,238,197,70,243,241,104,244,234,149,197,134,130,199,156,224,43,49,99,112,165,164,87,206,150,166,106,25,197,56,123,122,242,120,122,178,104,131,177,213,164,132,105,249,74,252,158,30,52,215,52,206,106,86,243,111,152,42,133,192,85,141,33,156,195,93,224,91,23,164,98,218,126,190,217,138,110,16,196,228,23,222,191,235,200,202,141,174,200,18,199,206,44,203,96,21,218,166,65,222,109,134,245,23,242,76,65,43,3,52,36,63,93,17,64,28,24,107,196,96,109,254,16,232,65,126,97,69,233,216,159,189,0,248,246,161,54,57,228,251,73,142,28,4,206,97,30,186,196,64,10,123,140,51,62,31,239,218,80,93,232,249,110,217,116,40,212,39,125,191,208,189,136,85,82,75,249,94,79,248,209,78,214,203,129,68,182,232,97,83,242,199,254,156,199,161,223,147,76,35,103,227,248,26,18,250,45,144,247,255,183,176,191,212,197,194,148,112,54,155,7,214,107,176,109,93,143,37,139,14,25,208,123,173,24,11,70,74,170,116,149,52,218,228,91,114,17,107,134,162,228,59,96,128,73,104,217,227,14,182,155,192,211,237,78,117,110,238,230,18,105,227,83,252,50,73,203,175,137,24,11,142,83,50,26,161,79,206,93,22,3,151,198,170,179,6,47,5,205,19,65,206,84,174,147,104,227,107,204,197,241,46,201,54,96,116,214,144,62,131,178,57,105,229,145,177,1,171,143,108,157,12,170,37,155,15,54,8,90,125,114,174,124,9,159,221,149,242,211,85,22,1,145,55,248,215,117,250,216,76,65,208,57,83,192,39,171,93,234,95,150,255,93,245,254,26,15,164,63,52,204,216,245,15,69,251,232,52,248,244,23,241,113,2,61,72,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d6c2229c-b577-45e0-9096-14de3176184e"));
		}

		#endregion

	}

	#endregion

}

