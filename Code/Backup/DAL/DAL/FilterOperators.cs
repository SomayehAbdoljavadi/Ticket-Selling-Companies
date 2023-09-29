using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBL;
using DML;

namespace DAL
{
	public class FilterOperators
	{
		DBL.DB db = new DBL.DB();
		public int Insert(DML.FilterOperators entity)
		{
			SqlParameter[] sqlParam = new SqlParameter[2];

			sqlParam[0] = new SqlParameter("@code", SqlDbType.Int, 4);
			sqlParam[0].Value = entity.code;
			sqlParam[1] = new SqlParameter("@text", SqlDbType.NVarChar, 2147483646);
			sqlParam[1].Value = entity.text;

			return db.ExecuteNonQuery("sp_FilterOperators_Insert",sqlParam);
		}

		public void Delete(DML.FilterOperators entity)
		{
			Delete(entity.code);
		}

		public void Delete(Int32? id)
		{
			SqlParameter[] sp = new SqlParameter[1];
			sp[0] = new SqlParameter("@id", id);
			db.ExecuteNonQuery("sp_FilterOperators_Delete",sp);
		}

		public void Update(DML.FilterOperators entity)
		{
			SqlParameter[] sqlParam = new SqlParameter[2];

			sqlParam[0] = new SqlParameter("@code", SqlDbType.Int, 4);
			sqlParam[0].Value = entity.code;
			sqlParam[1] = new SqlParameter("@text", SqlDbType.NVarChar, 2147483646);
			sqlParam[1].Value = entity.text;

			db.ExecuteNonQuery("sp_FilterOperators_Update",sqlParam);
		}

		public DML.FilterOperators SelectById(Int32? id)
		{
			SqlParameter[] sp = new SqlParameter[1];
			sp[0] = new SqlParameter("@id", id);
			DataTable dt = db.RetToDataTable("sp_FilterOperators_SelectById",sp);
			DML.FilterOperators Entity = new DML.FilterOperators();
			if (dt.Rows.Count == 1)
			{
				if (dt.Rows[0]["code"] != null && dt.Rows[0]["code"] != DBNull.Value)
					Entity.code = Convert.ToInt32(dt.Rows[0]["code"]);
				if (dt.Rows[0]["text"] != null && dt.Rows[0]["text"] != DBNull.Value)
					Entity.text = Convert.ToString(dt.Rows[0]["text"]);
				
			}
			return Entity;
		}

		public System.Data.DataTable Select(DML.FilterOperators entity, String filter)
		{
			SqlParameter[] sqlParam = new SqlParameter[3];

			sqlParam[0] = new SqlParameter("@code", SqlDbType.Int, 4);
			sqlParam[0].Value = entity.code;
			sqlParam[1] = new SqlParameter("@text", SqlDbType.NVarChar, 2147483646);
			sqlParam[1].Value = entity.text;
			sqlParam[2] = new SqlParameter("@filter", SqlDbType.NVarChar);
			sqlParam[2].Value = filter;
			
			return db.RetToDataTable("sp_FilterOperators_Select",sqlParam);
		}


	}
}
