using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Text;

namespace DML
{
    public sealed class TBHotel
    {
        public Int32? ID;
        public String Name;
        public Int32? Stars;
        public String Address;
        public Int32? City;
        public String Tell;
        public String Description;


        public readonly Dictionary<String, bool> AllowNull = new Dictionary<String, bool>() {
			{ "ID", false },
			{ "Name", false },
			{ "Stars", false },
			{ "Address", false },
			{ "City", false },
			{ "Tell", false },
			{ "Description", true }
		};

        public readonly Dictionary<String, Type> DataType = new Dictionary<String, Type>() {
			{ "ID", typeof(System.Int32) },
			{ "Name", typeof(System.String) },
			{ "Stars", typeof(System.Int32) },
			{ "Address", typeof(System.String) },
			{ "City", typeof(System.Int32) },
			{ "Tell", typeof(System.String) },
			{ "Description", typeof(System.String) }
		};

        public Dictionary<String, FilterOperator> FilterOption = new Dictionary<String, FilterOperator>() {
			{ "ID",FilterOperator.Equal },
			{ "Name",FilterOperator.EqualString },
			{ "Stars",FilterOperator.Equal },
			{ "Address",FilterOperator.EqualString },
			{ "City",FilterOperator.Equal },
			{ "Tell",FilterOperator.EqualString },
			{ "Description",FilterOperator.EqualString }
		};
    }
}
