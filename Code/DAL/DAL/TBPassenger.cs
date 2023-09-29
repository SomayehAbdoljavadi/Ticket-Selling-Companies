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
    public class TBPassenger
    {
        DBL.DB db = new DBL.DB();
        public int Insert(DML.TBPassenger entity)
        {
            SqlParameter[] sqlParam = new SqlParameter[11];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@User_ID", SqlDbType.Int, 4);
            sqlParam[1].Value = entity.User_ID;
            sqlParam[2] = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
            sqlParam[2].Value = entity.Name;
            sqlParam[3] = new SqlParameter("@Family", SqlDbType.NVarChar, 200);
            sqlParam[3].Value = entity.Family;
            sqlParam[4] = new SqlParameter("@Address", SqlDbType.NVarChar, 2147483646);
            sqlParam[4].Value = entity.Address;
            sqlParam[5] = new SqlParameter("@City", SqlDbType.Int, 4);
            sqlParam[5].Value = entity.City;
            sqlParam[6] = new SqlParameter("@Birthday", SqlDbType.NVarChar, 10);
            sqlParam[6].Value = entity.Birthday;
            sqlParam[7] = new SqlParameter("@NationalCode", SqlDbType.NVarChar, 10);
            sqlParam[7].Value = entity.NationalCode;
            sqlParam[8] = new SqlParameter("@PasPortCode", SqlDbType.NVarChar, 20);
            sqlParam[8].Value = entity.PasPortCode;
            sqlParam[9] = new SqlParameter("@Tell", SqlDbType.NVarChar, 14);
            sqlParam[9].Value = entity.Tell;
            sqlParam[10] = new SqlParameter("@PreCuontryTellCode", SqlDbType.NVarChar, 9);
            sqlParam[10].Value = entity.PreCuontryTellCode;

            return db.ExecuteNonQuery("sp_TBPassenger_Insert", sqlParam);
        }

        public void Delete(DML.TBPassenger entity)
        {
            Delete(entity.ID);
        }

        public void Delete(Int32? id)
        {
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@id", id);
            db.ExecuteNonQuery("sp_TBPassenger_Delete", sp);
        }

        public void Update(DML.TBPassenger entity)
        {
            SqlParameter[] sqlParam = new SqlParameter[11];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@User_ID", SqlDbType.Int, 4);
            sqlParam[1].Value = entity.User_ID;
            sqlParam[2] = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
            sqlParam[2].Value = entity.Name;
            sqlParam[3] = new SqlParameter("@Family", SqlDbType.NVarChar, 200);
            sqlParam[3].Value = entity.Family;
            sqlParam[4] = new SqlParameter("@Address", SqlDbType.NVarChar, 2147483646);
            sqlParam[4].Value = entity.Address;
            sqlParam[5] = new SqlParameter("@City", SqlDbType.Int, 4);
            sqlParam[5].Value = entity.City;
            sqlParam[6] = new SqlParameter("@Birthday", SqlDbType.NVarChar, 10);
            sqlParam[6].Value = entity.Birthday;
            sqlParam[7] = new SqlParameter("@NationalCode", SqlDbType.NVarChar, 10);
            sqlParam[7].Value = entity.NationalCode;
            sqlParam[8] = new SqlParameter("@PasPortCode", SqlDbType.NVarChar, 20);
            sqlParam[8].Value = entity.PasPortCode;
            sqlParam[9] = new SqlParameter("@Tell", SqlDbType.NVarChar, 14);
            sqlParam[9].Value = entity.Tell;
            sqlParam[10] = new SqlParameter("@PreCuontryTellCode", SqlDbType.NVarChar, 9);
            sqlParam[10].Value = entity.PreCuontryTellCode;

            db.ExecuteNonQuery("sp_TBPassenger_Update", sqlParam);
        }

        public DML.TBPassenger SelectById(Int32? id)
        {
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@id", id);
            DataTable dt = db.RetToDataTable("sp_TBPassenger_SelectById", sp);
            DML.TBPassenger Entity = new DML.TBPassenger();
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0]["ID"] != null && dt.Rows[0]["ID"] != DBNull.Value)
                    Entity.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                if (dt.Rows[0]["User_ID"] != null && dt.Rows[0]["User_ID"] != DBNull.Value)
                    Entity.User_ID = Convert.ToInt32(dt.Rows[0]["User_ID"]);
                if (dt.Rows[0]["Name"] != null && dt.Rows[0]["Name"] != DBNull.Value)
                    Entity.Name = Convert.ToString(dt.Rows[0]["Name"]);
                if (dt.Rows[0]["Family"] != null && dt.Rows[0]["Family"] != DBNull.Value)
                    Entity.Family = Convert.ToString(dt.Rows[0]["Family"]);
                if (dt.Rows[0]["Address"] != null && dt.Rows[0]["Address"] != DBNull.Value)
                    Entity.Address = Convert.ToString(dt.Rows[0]["Address"]);
                if (dt.Rows[0]["City"] != null && dt.Rows[0]["City"] != DBNull.Value)
                    Entity.City = Convert.ToInt32(dt.Rows[0]["City"]);
                if (dt.Rows[0]["Birthday"] != null && dt.Rows[0]["Birthday"] != DBNull.Value)
                    Entity.Birthday = Convert.ToString(dt.Rows[0]["Birthday"]);
                if (dt.Rows[0]["NationalCode"] != null && dt.Rows[0]["NationalCode"] != DBNull.Value)
                    Entity.NationalCode = Convert.ToString(dt.Rows[0]["NationalCode"]);
                if (dt.Rows[0]["PasPortCode"] != null && dt.Rows[0]["PasPortCode"] != DBNull.Value)
                    Entity.PasPortCode = Convert.ToString(dt.Rows[0]["PasPortCode"]);
                if (dt.Rows[0]["Tell"] != null && dt.Rows[0]["Tell"] != DBNull.Value)
                    Entity.Tell = Convert.ToString(dt.Rows[0]["Tell"]);
                if (dt.Rows[0]["PreCuontryTellCode"] != null && dt.Rows[0]["PreCuontryTellCode"] != DBNull.Value)
                    Entity.PreCuontryTellCode = Convert.ToString(dt.Rows[0]["PreCuontryTellCode"]);

            }
            return Entity;
        }

        public System.Data.DataTable Select(DML.TBPassenger entity, String filter)
        {
            SqlParameter[] sqlParam = new SqlParameter[12];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@User_ID", SqlDbType.Int, 4);
            sqlParam[1].Value = entity.User_ID;
            sqlParam[2] = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
            sqlParam[2].Value = entity.Name;
            sqlParam[3] = new SqlParameter("@Family", SqlDbType.NVarChar, 200);
            sqlParam[3].Value = entity.Family;
            sqlParam[4] = new SqlParameter("@Address", SqlDbType.NVarChar, 2147483646);
            sqlParam[4].Value = entity.Address;
            sqlParam[5] = new SqlParameter("@City", SqlDbType.Int, 4);
            sqlParam[5].Value = entity.City;
            sqlParam[6] = new SqlParameter("@Birthday", SqlDbType.NVarChar, 10);
            sqlParam[6].Value = entity.Birthday;
            sqlParam[7] = new SqlParameter("@NationalCode", SqlDbType.NVarChar, 10);
            sqlParam[7].Value = entity.NationalCode;
            sqlParam[8] = new SqlParameter("@PasPortCode", SqlDbType.NVarChar, 20);
            sqlParam[8].Value = entity.PasPortCode;
            sqlParam[9] = new SqlParameter("@Tell", SqlDbType.NVarChar, 14);
            sqlParam[9].Value = entity.Tell;
            sqlParam[10] = new SqlParameter("@PreCuontryTellCode", SqlDbType.NVarChar, 9);
            sqlParam[10].Value = entity.PreCuontryTellCode;
            sqlParam[11] = new SqlParameter("@filter", SqlDbType.NVarChar);
            sqlParam[11].Value = filter;

            return db.RetToDataTable("sp_TBPassenger_Select", sqlParam);
        }


    }
}
