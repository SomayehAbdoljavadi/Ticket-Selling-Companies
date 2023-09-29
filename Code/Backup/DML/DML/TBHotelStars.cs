using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Text;

namespace DML
{
    public sealed class TBHotelStars
    {
        public Int32? ID;
        public String Caption;


        public readonly Dictionary<String, bool> AllowNull = new Dictionary<String, bool>() {
			{ "ID", false },
			{ "Caption", false }
		};

        public readonly Dictionary<String, Type> DataType = new Dictionary<String, Type>() {
			{ "ID", typeof(System.Int32) },
			{ "Caption", typeof(System.String) }
		};

        public Dictionary<String, FilterOperator> FilterOption = new Dictionary<String, FilterOperator>() {
			{ "ID",FilterOperator.Equal },
			{ "Caption",FilterOperator.EqualString }
		};
    }
}
