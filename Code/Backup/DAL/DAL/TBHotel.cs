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
    public class TBHotel
    {
        DBL.DB db = new DBL.DB();
        public int Insert(DML.TBHotel entity)
        {
            SqlParameter[] sqlParam = new SqlParameter[7];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 2147483646);
            sqlParam[1].Value = entity.Name;
            sqlParam[2] = new SqlParameter("@Stars", SqlDbType.Int, 4);
            sqlParam[2].Value = entity.Stars;
            sqlParam[3] = new SqlParameter("@Address", SqlDbType.NVarChar, 2147483646);
            sqlParam[3].Value = entity.Address;
            sqlParam[4] = new SqlParameter("@City", SqlDbType.Int, 4);
            sqlParam[4].Value = entity.City;
            sqlParam[5] = new SqlParameter("@Tell", SqlDbType.NVarChar, 14);
            sqlParam[5].Value = entity.Tell;
            sqlParam[6] = new SqlParameter("@Description", SqlDbType.NVarChar, 2147483646);
            sqlParam[6].Value = entity.Description;

            return db.ExecuteNonQuery("sp_TBHotel_Insert", sqlParam);
        }

        public void Delete(DML.TBHotel entity)
        {
            Delete(entity.ID);
        }

        public void Delete(Int32? id)
        {
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@id", id);
            db.ExecuteNonQuery("sp_TBHotel_Delete", sp);
        }

        public void Update(DML.TBHotel entity)
        {
            SqlParameter[] sqlParam = new SqlParameter[7];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 2147483646);
            sqlParam[1].Value = entity.Name;
            sqlParam[2] = new SqlParameter("@Stars", SqlDbType.Int, 4);
            sqlParam[2].Value = entity.Stars;
            sqlParam[3] = new SqlParameter("@Address", SqlDbType.NVarChar, 2147483646);
            sqlParam[3].Value = entity.Address;
            sqlParam[4] = new SqlParameter("@City", SqlDbType.Int, 4);
            sqlParam[4].Value = entity.City;
            sqlParam[5] = new SqlParameter("@Tell", SqlDbType.NVarChar, 14);
            sqlParam[5].Value = entity.Tell;
            sqlParam[6] = new SqlParameter("@Description", SqlDbType.NVarChar, 2147483646);
            sqlParam[6].Value = entity.Description;

            db.ExecuteNonQuery("sp_TBHotel_Update", sqlParam);
        }

        public DML.TBHotel SelectById(Int32? id)
        {
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@id", id);
            DataTable dt = db.RetToDataTable("sp_TBHotel_SelectById", sp);
            DML.TBHotel Entity = new DML.TBHotel();
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0]["ID"] != null && dt.Rows[0]["ID"] != DBNull.Value)
                    Entity.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                if (dt.Rows[0]["Name"] != null && dt.Rows[0]["Name"] != DBNull.Value)
                    Entity.Name = Convert.ToString(dt.Rows[0]["Name"]);
                if (dt.Rows[0]["Stars"] != null && dt.Rows[0]["Stars"] != DBNull.Value)
                    Entity.Stars = Convert.ToInt32(dt.Rows[0]["Stars"]);
                if (dt.Rows[0]["Address"] != null && dt.Rows[0]["Address"] != DBNull.Value)
                    Entity.Address = Convert.ToString(dt.Rows[0]["Address"]);
                if (dt.Rows[0]["City"] != null && dt.Rows[0]["City"] != DBNull.Value)
                    Entity.City = Convert.ToInt32(dt.Rows[0]["City"]);
                if (dt.Rows[0]["Tell"] != null && dt.Rows[0]["Tell"] != DBNull.Value)
                    Entity.Tell = Convert.ToString(dt.Rows[0]["Tell"]);
                if (dt.Rows[0]["Description"] != null && dt.Rows[0]["Description"] != DBNull.Value)
                    Entity.Description = Convert.ToString(dt.Rows[0]["Description"]);

            }
            return Entity;
        }

        public System.Data.DataTable Select(DML.TBHotel entity, String filter)
        {
            SqlParameter[] sqlParam = new SqlParameter[8];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 2147483646);
            sqlParam[1].Value = entity.Name;
            sqlParam[2] = new SqlParameter("@Stars", SqlDbType.Int, 4);
            sqlParam[2].Value = entity.Stars;
            sqlParam[3] = new SqlParameter("@Address", SqlDbType.NVarChar, 2147483646);
            sqlParam[3].Value = entity.Address;
            sqlParam[4] = new SqlParameter("@City", SqlDbType.Int, 4);
            sqlParam[4].Value = entity.City;
            sqlParam[5] = new SqlParameter("@Tell", SqlDbType.NVarChar, 14);
            sqlParam[5].Value = entity.Tell;
            sqlParam[6] = new SqlParameter("@Description", SqlDbType.NVarChar, 2147483646);
            sqlParam[6].Value = entity.Description;
            sqlParam[7] = new SqlParameter("@filter", SqlDbType.NVarChar);
            sqlParam[7].Value = filter;

            return db.RetToDataTable("sp_TBHotel_Select", sqlParam);
        }


    }
}
