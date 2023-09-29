using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Text;

namespace DML
{
    public sealed class TBPassenger
    {
        public Int32? ID;
        public Int32? User_ID;
        public String Name;
        public String Family;
        public String Address;
        public Int32? City;
        public String Birthday;
        public String NationalCode;
        public String PasPortCode;
        public String Tell;
        public String PreCuontryTellCode;


        public readonly Dictionary<String, bool> AllowNull = new Dictionary<String, bool>() {
			{ "ID", false },
			{ "User_ID", false },
			{ "Name", false },
			{ "Family", false },
			{ "Address", false },
			{ "City", false },
			{ "Birthday", false },
			{ "NationalCode", false },
			{ "PasPortCode", false },
			{ "Tell", false },
			{ "PreCuontryTellCode", false }
		};

        public readonly Dictionary<String, Type> DataType = new Dictionary<String, Type>() {
			{ "ID", typeof(System.Int32) },
			{ "User_ID", typeof(System.Int32) },
			{ "Name", typeof(System.String) },
			{ "Family", typeof(System.String) },
			{ "Address", typeof(System.String) },
			{ "City", typeof(System.Int32) },
			{ "Birthday", typeof(System.String) },
			{ "NationalCode", typeof(System.String) },
			{ "PasPortCode", typeof(System.String) },
			{ "Tell", typeof(System.String) },
			{ "PreCuontryTellCode", typeof(System.String) }
		};

        public Dictionary<String, FilterOperator> FilterOption = new Dictionary<String, FilterOperator>() {
			{ "ID",FilterOperator.Equal },
			{ "User_ID",FilterOperator.Equal },
			{ "Name",FilterOperator.EqualString },
			{ "Family",FilterOperator.EqualString },
			{ "Address",FilterOperator.EqualString },
			{ "City",FilterOperator.Equal },
			{ "Birthday",FilterOperator.EqualString },
			{ "NationalCode",FilterOperator.EqualString },
			{ "PasPortCode",FilterOperator.EqualString },
			{ "Tell",FilterOperator.EqualString },
			{ "PreCuontryTellCode",FilterOperator.EqualString }
		};
    }
}
