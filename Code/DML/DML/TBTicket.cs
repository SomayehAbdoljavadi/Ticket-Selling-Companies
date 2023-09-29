using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Text;

namespace DML
{
    public sealed class TBTicket
    {
        public Int32? ID;
        public Int32? Member;
        public Int32? Tour;


        public readonly Dictionary<String, bool> AllowNull = new Dictionary<String, bool>() {
			{ "ID", false },
			{ "Member", false },
			{ "Tour", false }
		};

        public readonly Dictionary<String, Type> DataType = new Dictionary<String, Type>() {
			{ "ID", typeof(System.Int32) },
			{ "Member", typeof(System.Int32) },
			{ "Tour", typeof(System.Int32) }
		};

        public Dictionary<String, FilterOperator> FilterOption = new Dictionary<String, FilterOperator>() {
			{ "ID",FilterOperator.Equal },
			{ "Member",FilterOperator.Equal },
			{ "Tour",FilterOperator.Equal }
		};
    }
}
