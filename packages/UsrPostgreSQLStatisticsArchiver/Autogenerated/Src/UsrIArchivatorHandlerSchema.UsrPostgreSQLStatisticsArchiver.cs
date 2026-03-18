namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: UsrIArchivatorHandlerSchema

	/// <exclude/>
	public class UsrIArchivatorHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UsrIArchivatorHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UsrIArchivatorHandlerSchema(UsrIArchivatorHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ca045052-e72a-4146-8743-eb2e1e3fe2f0");
			Name = "UsrIArchivatorHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("31d71ee4-dddf-4c07-b20f-9d219e37600c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,146,205,106,195,48,12,128,207,13,228,29,68,123,217,46,201,189,237,10,165,151,229,80,40,99,125,0,45,81,18,67,108,7,217,9,148,178,119,159,99,55,33,217,216,96,71,235,231,211,39,97,133,146,76,139,57,193,59,49,163,209,165,77,78,90,149,162,234,24,173,208,42,142,238,113,180,234,140,80,213,162,132,105,23,71,46,179,97,170,92,25,100,202,18,151,14,180,133,171,225,236,200,121,45,122,180,154,95,81,21,13,177,47,78,211,20,246,166,147,18,249,118,120,188,47,172,123,81,144,1,49,18,160,212,12,182,38,144,40,154,97,110,29,16,201,72,72,103,136,182,251,104,68,62,107,254,101,250,234,238,13,38,223,51,217,90,23,102,11,23,15,8,201,239,126,62,112,98,66,235,253,140,69,229,38,232,210,219,205,172,126,106,133,72,139,140,18,148,187,241,203,186,51,196,238,178,138,242,225,172,235,67,54,195,13,57,200,167,100,178,79,125,167,7,245,90,20,15,135,177,229,233,186,96,193,18,253,188,251,99,153,55,146,186,255,247,50,222,33,180,78,14,227,152,13,169,34,220,212,191,63,195,175,88,4,93,236,11,40,254,16,113,104,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ca045052-e72a-4146-8743-eb2e1e3fe2f0"));
		}

		#endregion

	}

	#endregion

}

