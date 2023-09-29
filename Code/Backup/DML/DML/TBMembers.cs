using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Text;

namespace DML
{
    public sealed class TBMembers
    {
        public Int32? ID;
        public String Username;
        public String Password;
        public String GoogleEmail;
        public String YahooEmail;
        public String MSNEmail;
        public String OtherEmail;
        public String DisplayName;


        public readonly Dictionary<String, bool> AllowNull = new Dictionary<String, bool>() {
			{ "ID", false },
			{ "Username", false },
			{ "Password", false },
			{ "GoogleEmail", true },
			{ "YahooEmail", true },
			{ "MSNEmail", true },
			{ "OtherEmail", true },
			{ "DisplayName", true }
		};

        public readonly Dictionary<String, Type> DataType = new Dictionary<String, Type>() {
			{ "ID", typeof(System.Int32) },
			{ "Username", typeof(System.String) },
			{ "Password", typeof(System.String) },
			{ "GoogleEmail", typeof(System.String) },
			{ "YahooEmail", typeof(System.String) },
			{ "MSNEmail", typeof(System.String) },
			{ "OtherEmail", typeof(System.String) },
			{ "DisplayName", typeof(System.String) }
		};

        public Dictionary<String, FilterOperator> FilterOption = new Dictionary<String, FilterOperator>() {
			{ "ID",FilterOperator.Equal },
			{ "Username",FilterOperator.EqualString },
			{ "Password",FilterOperator.EqualString },
			{ "GoogleEmail",FilterOperator.EqualString },
			{ "YahooEmail",FilterOperator.EqualString },
			{ "MSNEmail",FilterOperator.EqualString },
			{ "OtherEmail",FilterOperator.EqualString },
			{ "DisplayName",FilterOperator.EqualString }
		};
    }
}
