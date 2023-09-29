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
	public class TBHotelStars
	{
		DBL.DB db = new DBL.DB();
		public int Insert(DML.TBHotelStars entity)
		{
			SqlParameter[] sqlParam = new SqlParameter[2];

			sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
			sqlParam[0].Value = entity.ID;
			sqlParam[1] = new SqlParameter("@Caption", SqlDbType.NVarChar, 100);
			sqlParam[1].Value = entity.Caption;

			return db.ExecuteNonQuery("sp_TBHotelStars_Insert",sqlParam);
		}

		public void Delete(DML.TBHotelStars entity)
		{
			Delete(entity.ID);
		}

		public void Delete(Int32? id)
		{
			SqlParameter[] sp = new SqlParameter[1];
			sp[0] = new SqlParameter("@id", id);
			db.ExecuteNonQuery("sp_TBHotelStars_Delete",sp);
		}

		public void Update(DML.TBHotelStars entity)
		{
			SqlParameter[] sqlParam = new SqlParameter[2];

			sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
			sqlParam[0].Value = entity.ID;
			sqlParam[1] = new SqlParameter("@Caption", SqlDbType.NVarChar, 100);
			sqlParam[1].Value = entity.Caption;

			db.ExecuteNonQuery("sp_TBHotelStars_Update",sqlParam);
		}

		public DML.TBHotelStars SelectById(Int32? id)
		{
			SqlParameter[] sp = new SqlParameter[1];
			sp[0] = new SqlParameter("@id", id);
			DataTable dt = db.RetToDataTable("sp_TBHotelStars_SelectById",sp);
			DML.TBHotelStars Entity = new DML.TBHotelStars();
			if (dt.Rows.Count == 1)
			{
				if (dt.Rows[0]["ID"] != null && dt.Rows[0]["ID"] != DBNull.Value)
					Entity.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
				if (dt.Rows[0]["Caption"] != null && dt.Rows[0]["Caption"] != DBNull.Value)
					Entity.Caption = Convert.ToString(dt.Rows[0]["Caption"]);
				
			}
			return Entity;
		}

		public System.Data.DataTable Select(DML.TBHotelStars entity, String filter)
		{
			SqlParameter[] sqlParam = new SqlParameter[3];

			sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
			sqlParam[0].Value = entity.ID;
			sqlParam[1] = new SqlParameter("@Caption", SqlDbType.NVarChar, 100);
			sqlParam[1].Value = entity.Caption;
			sqlParam[2] = new SqlParameter("@filter", SqlDbType.NVarChar);
			sqlParam[2].Value = filter;
			
			return db.RetToDataTable("sp_TBHotelStars_Select",sqlParam);
		}


	}
}
