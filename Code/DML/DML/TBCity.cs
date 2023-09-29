using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Text;

namespace DML
{
	public sealed class TBCity
	{
		public Int32 ?ID;
		public Int32 ?CountryID;
		public String Name;


		public readonly Dictionary<String, bool> AllowNull = new Dictionary<String, bool>() {
			{ "ID", false },
			{ "CountryID", false },
			{ "Name", false }
		};

		public readonly Dictionary<String, Type> DataType = new Dictionary<String, Type>() {
			{ "ID", typeof(System.Int32) },
			{ "CountryID", typeof(System.Int32) },
			{ "Name", typeof(System.String) }
		};

		public Dictionary<String, FilterOperator> FilterOption = new Dictionary<String, FilterOperator>() {
			{ "ID",FilterOperator.Equal },
			{ "CountryID",FilterOperator.Equal },
			{ "Name",FilterOperator.EqualString }
		};
	}
}
