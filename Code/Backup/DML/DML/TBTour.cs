using System;
using System.Collections.Generic;
using System.Text;

namespace DML
{
	public sealed class TBTour
	{
		public Int32 ?ID;
		public String Name;
		public Int32 ?Hotel;
		public Int32 ?AirPlane;
		public String Price;
		public Int32 ?LengthDays;
		public Int32 ?lengthNights;
		public Int32 ?City;
		public String Date;


		public readonly Dictionary<String, bool> AllowNull = new Dictionary<String, bool>() {
			{ "ID", false },
			{ "Name", false },
			{ "Hotel", false },
			{ "AirPlane", false },
			{ "Price", false },
			{ "LengthDays", false },
			{ "lengthNights", false },
			{ "City", false },
			{ "Date", false }
		};

		public readonly Dictionary<String, Type> DataType = new Dictionary<String, Type>() {
			{ "ID", typeof(System.Int32) },
			{ "Name", typeof(System.String) },
			{ "Hotel", typeof(System.Int32) },
			{ "AirPlane", typeof(System.Int32) },
			{ "Price", typeof(System.String) },
			{ "LengthDays", typeof(System.Int32) },
			{ "lengthNights", typeof(System.Int32) },
			{ "City", typeof(System.Int32) },
			{ "Date", typeof(System.String) }
		};

		public Dictionary<String, FilterOperator> FilterOption = new Dictionary<String, FilterOperator>() {
			{ "ID",FilterOperator.Equal },
			{ "Name",FilterOperator.EqualString },
			{ "Hotel",FilterOperator.Equal },
			{ "AirPlane",FilterOperator.Equal },
			{ "Price",FilterOperator.EqualString },
			{ "LengthDays",FilterOperator.Equal },
			{ "lengthNights",FilterOperator.Equal },
			{ "City",FilterOperator.Equal },
			{ "Date",FilterOperator.EqualString }
		};
	}
}
