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
	public class TBCity
	{
		DBL.DB db = new DBL.DB();
		public int Insert(DML.TBCity entity)
		{
			SqlParameter[] sqlParam = new SqlParameter[3];

			sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
			sqlParam[0].Value = entity.ID;
			sqlParam[1] = new SqlParameter("@CountryID", SqlDbType.Int, 4);
			sqlParam[1].Value = entity.CountryID;
			sqlParam[2] = new SqlParameter("@Name", SqlDbType.NVarChar, 2147483646);
			sqlParam[2].Value = entity.Name;

			return db.ExecuteNonQuery("sp_TBCity_Insert",sqlParam);
		}

		public void Delete(DML.TBCity entity)
		{
			Delete(entity.ID);
		}

		public void Delete(Int32? id)
		{
			SqlParameter[] sp = new SqlParameter[1];
			sp[0] = new SqlParameter("@id", id);
			db.ExecuteNonQuery("sp_TBCity_Delete",sp);
		}

		public void Update(DML.TBCity entity)
		{
			SqlParameter[] sqlParam = new SqlParameter[3];

			sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
			sqlParam[0].Value = entity.ID;
			sqlParam[1] = new SqlParameter("@CountryID", SqlDbType.Int, 4);
			sqlParam[1].Value = entity.CountryID;
			sqlParam[2] = new SqlParameter("@Name", SqlDbType.NVarChar, 2147483646);
			sqlParam[2].Value = entity.Name;

			db.ExecuteNonQuery("sp_TBCity_Update",sqlParam);
		}

		public DML.TBCity SelectById(Int32? id)
		{
			SqlParameter[] sp = new SqlParameter[1];
			sp[0] = new SqlParameter("@id", id);
			DataTable dt = db.RetToDataTable("sp_TBCity_SelectById",sp);
			DML.TBCity Entity = new DML.TBCity();
			if (dt.Rows.Count == 1)
			{
				if (dt.Rows[0]["ID"] != null && dt.Rows[0]["ID"] != DBNull.Value)
					Entity.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
				if (dt.Rows[0]["CountryID"] != null && dt.Rows[0]["CountryID"] != DBNull.Value)
					Entity.CountryID = Convert.ToInt32(dt.Rows[0]["CountryID"]);
				if (dt.Rows[0]["Name"] != null && dt.Rows[0]["Name"] != DBNull.Value)
					Entity.Name = Convert.ToString(dt.Rows[0]["Name"]);
				
			}
			return Entity;
		}

		public System.Data.DataTable Select(DML.TBCity entity, String filter)
		{
			SqlParameter[] sqlParam = new SqlParameter[4];

			sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
			sqlParam[0].Value = entity.ID;
			sqlParam[1] = new SqlParameter("@CountryID", SqlDbType.Int, 4);
			sqlParam[1].Value = entity.CountryID;
			sqlParam[2] = new SqlParameter("@Name", SqlDbType.NVarChar, 2147483646);
			sqlParam[2].Value = entity.Name;
			sqlParam[3] = new SqlParameter("@filter", SqlDbType.NVarChar);
			sqlParam[3].Value = filter;
			
			return db.RetToDataTable("sp_TBCity_Select",sqlParam);
		}


	}
}
