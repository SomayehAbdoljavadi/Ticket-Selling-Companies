using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Text;

namespace DML
{
    public sealed class TBAirPlane
    {
        public Int32? ID;
        public String Name;
        public Int32? MadeIn;
        public String Description;


        public readonly Dictionary<String, bool> AllowNull = new Dictionary<String, bool>() {
			{ "ID", false },
			{ "Name", false },
			{ "MadeIn", false },
			{ "Description", true }
		};

        public readonly Dictionary<String, Type> DataType = new Dictionary<String, Type>() {
			{ "ID", typeof(System.Int32) },
			{ "Name", typeof(System.String) },
			{ "MadeIn", typeof(System.Int32) },
			{ "Description", typeof(System.String) }
		};

        public Dictionary<String, FilterOperator> FilterOption = new Dictionary<String, FilterOperator>() {
			{ "ID",FilterOperator.Equal },
			{ "Name",FilterOperator.EqualString },
			{ "MadeIn",FilterOperator.Equal },
			{ "Description",FilterOperator.EqualString }
		};
    }
}
