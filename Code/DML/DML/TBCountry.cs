using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Text;

namespace DML
{
    public sealed class TBCountry
    {
        public Int32? ID;
        public String Name;
        public Int32? Capital;


        public readonly Dictionary<String, bool> AllowNull = new Dictionary<String, bool>() {
			{ "ID", false },
			{ "Name", false },
			{ "Capital", true }
		};

        public readonly Dictionary<String, Type> DataType = new Dictionary<String, Type>() {
			{ "ID", typeof(System.Int32) },
			{ "Name", typeof(System.String) },
			{ "Capital", typeof(System.Int32) }
		};

        public Dictionary<String, FilterOperator> FilterOption = new Dictionary<String, FilterOperator>() {
			{ "ID",FilterOperator.Equal },
			{ "Name",FilterOperator.EqualString },
			{ "Capital",FilterOperator.Equal }
		};
    }
}
