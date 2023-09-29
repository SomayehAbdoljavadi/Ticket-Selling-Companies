using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Text;

namespace DML
{
	public sealed class FilterOperators
	{
		public Int32 ?code;
		public String text;


		public readonly Dictionary<String, bool> AllowNull = new Dictionary<String, bool>() {
			{ "code", false },
			{ "text", false }
		};

		public readonly Dictionary<String, Type> DataType = new Dictionary<String, Type>() {
			{ "code", typeof(System.Int32) },
			{ "text", typeof(System.String) }
		};

		public Dictionary<String, FilterOperator> FilterOption = new Dictionary<String, FilterOperator>() {
			{ "code",FilterOperator.Nothing },
			{ "text",FilterOperator.Nothing }
		};
	}
}
