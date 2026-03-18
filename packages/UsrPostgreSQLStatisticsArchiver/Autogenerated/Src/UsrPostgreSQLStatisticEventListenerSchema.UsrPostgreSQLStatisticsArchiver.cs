namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: UsrPostgreSQLStatisticEventListenerSchema

	/// <exclude/>
	public class UsrPostgreSQLStatisticEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UsrPostgreSQLStatisticEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UsrPostgreSQLStatisticEventListenerSchema(UsrPostgreSQLStatisticEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d6c2229c-b577-45e0-9096-14de3176184e");
			Name = "UsrPostgreSQLStatisticEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("31d71ee4-dddf-4c07-b20f-9d219e37600c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,147,77,107,220,48,16,134,207,27,200,127,24,220,75,122,177,239,217,15,72,66,83,10,41,77,187,13,57,148,82,20,123,236,138,218,146,152,25,155,110,67,254,123,103,101,59,196,222,208,238,101,189,154,143,71,163,87,175,156,105,144,131,201,17,190,34,145,97,95,74,122,229,93,105,171,150,140,88,239,78,79,30,79,79,22,45,91,87,77,74,8,151,175,196,239,241,65,115,77,227,157,102,53,255,134,176,82,8,92,213,134,249,28,238,152,110,61,75,69,184,253,124,179,21,221,128,197,230,239,58,116,114,163,127,209,33,197,182,44,203,96,197,109,211,24,218,109,134,245,23,12,132,172,149,12,13,202,79,95,48,136,7,235,172,88,83,219,63,8,122,138,95,166,194,116,236,207,94,0,66,251,80,219,28,242,253,24,199,76,1,231,112,17,194,36,116,105,24,149,244,24,7,124,62,216,181,197,186,208,147,221,146,237,140,96,159,12,253,66,55,66,82,49,29,230,123,37,225,71,59,89,47,7,18,186,162,135,77,201,31,251,67,30,135,126,143,50,141,156,141,227,107,72,240,183,64,222,127,223,194,254,58,23,11,91,194,217,108,30,88,175,193,181,117,61,150,44,58,67,96,66,208,138,177,96,164,164,74,87,61,163,65,190,37,23,177,102,40,74,190,131,97,152,132,150,61,238,96,187,9,60,221,238,84,231,230,110,46,145,54,62,197,95,66,105,233,53,17,99,193,113,74,70,23,244,201,185,197,98,224,210,58,181,213,96,36,214,60,34,228,132,229,58,137,6,190,54,185,120,218,37,217,6,172,206,202,233,51,40,155,147,86,193,144,105,192,233,243,90,39,131,106,201,230,131,99,49,78,31,155,47,95,194,103,119,165,252,116,149,69,64,228,13,230,245,157,62,51,91,32,116,222,22,240,201,105,151,154,151,228,127,87,189,191,198,3,233,15,13,51,118,253,67,209,62,58,13,62,253,5,132,61,90,57,66,4,0,0 };
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

