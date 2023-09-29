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
	public class TBCountry
	{
		DBL.DB db = new DBL.DB();
		public int Insert(DML.TBCountry entity)
		{
			SqlParameter[] sqlParam = new SqlParameter[3];

			sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
			sqlParam[0].Value = entity.ID;
			sqlParam[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 2147483646);
			sqlParam[1].Value = entity.Name;
			sqlParam[2] = new SqlParameter("@Capital", SqlDbType.Int, 4);
			sqlParam[2].Value = entity.Capital;

			return db.ExecuteNonQuery("sp_TBCountry_Insert",sqlParam);
		}

		public void Delete(DML.TBCountry entity)
		{
			Delete(entity.ID);
		}

		public void Delete(Int32? id)
		{
			SqlParameter[] sp = new SqlParameter[1];
			sp[0] = new SqlParameter("@id", id);
			db.ExecuteNonQuery("sp_TBCountry_Delete",sp);
		}

		public void Update(DML.TBCountry entity)
		{
			SqlParameter[] sqlParam = new SqlParameter[3];

			sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
			sqlParam[0].Value = entity.ID;
			sqlParam[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 2147483646);
			sqlParam[1].Value = entity.Name;
			sqlParam[2] = new SqlParameter("@Capital", SqlDbType.Int, 4);
			sqlParam[2].Value = entity.Capital;

			db.ExecuteNonQuery("sp_TBCountry_Update",sqlParam);
		}

		public DML.TBCountry SelectById(Int32? id)
		{
			SqlParameter[] sp = new SqlParameter[1];
			sp[0] = new SqlParameter("@id", id);
			DataTable dt = db.RetToDataTable("sp_TBCountry_SelectById",sp);
			DML.TBCountry Entity = new DML.TBCountry();
			if (dt.Rows.Count == 1)
			{
				if (dt.Rows[0]["ID"] != null && dt.Rows[0]["ID"] != DBNull.Value)
					Entity.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
				if (dt.Rows[0]["Name"] != null && dt.Rows[0]["Name"] != DBNull.Value)
					Entity.Name = Convert.ToString(dt.Rows[0]["Name"]);
				if (dt.Rows[0]["Capital"] != null && dt.Rows[0]["Capital"] != DBNull.Value)
					Entity.Capital = Convert.ToInt32(dt.Rows[0]["Capital"]);
				
			}
			return Entity;
		}

		public System.Data.DataTable Select(DML.TBCountry entity, String filter)
		{
			SqlParameter[] sqlParam = new SqlParameter[4];

			sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
			sqlParam[0].Value = entity.ID;
			sqlParam[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 2147483646);
			sqlParam[1].Value = entity.Name;
			sqlParam[2] = new SqlParameter("@Capital", SqlDbType.Int, 4);
			sqlParam[2].Value = entity.Capital;
			sqlParam[3] = new SqlParameter("@filter", SqlDbType.NVarChar);
			sqlParam[3].Value = filter;
			
			return db.RetToDataTable("sp_TBCountry_Select",sqlParam);
		}


	}
}
