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
    public class TBAirPlane
    {
        DBL.DB db = new DBL.DB();
        public int Insert(DML.TBAirPlane entity)
        {
            SqlParameter[] sqlParam = new SqlParameter[4];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 2147483646);
            sqlParam[1].Value = entity.Name;
            sqlParam[2] = new SqlParameter("@MadeIn", SqlDbType.Int, 4);
            sqlParam[2].Value = entity.MadeIn;
            sqlParam[3] = new SqlParameter("@Description", SqlDbType.NVarChar, 2147483646);
            sqlParam[3].Value = entity.Description;

            return db.ExecuteNonQuery("sp_TBAirPlane_Insert", sqlParam);
        }

        public void Delete(DML.TBAirPlane entity)
        {
            Delete(entity.ID);
        }

        public void Delete(Int32? id)
        {
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@id", id);
            db.ExecuteNonQuery("sp_TBAirPlane_Delete", sp);
        }

        public void Update(DML.TBAirPlane entity)
        {
            SqlParameter[] sqlParam = new SqlParameter[4];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 2147483646);
            sqlParam[1].Value = entity.Name;
            sqlParam[2] = new SqlParameter("@MadeIn", SqlDbType.Int, 4);
            sqlParam[2].Value = entity.MadeIn;
            sqlParam[3] = new SqlParameter("@Description", SqlDbType.NVarChar, 2147483646);
            sqlParam[3].Value = entity.Description;

            db.ExecuteNonQuery("sp_TBAirPlane_Update", sqlParam);
        }

        public DML.TBAirPlane SelectById(Int32? id)
        {
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@id", id);
            DataTable dt = db.RetToDataTable("sp_TBAirPlane_SelectById", sp);
            DML.TBAirPlane Entity = new DML.TBAirPlane();
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0]["ID"] != null && dt.Rows[0]["ID"] != DBNull.Value)
                    Entity.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                if (dt.Rows[0]["Name"] != null && dt.Rows[0]["Name"] != DBNull.Value)
                    Entity.Name = Convert.ToString(dt.Rows[0]["Name"]);
                if (dt.Rows[0]["MadeIn"] != null && dt.Rows[0]["MadeIn"] != DBNull.Value)
                    Entity.MadeIn = Convert.ToInt32(dt.Rows[0]["MadeIn"]);
                if (dt.Rows[0]["Description"] != null && dt.Rows[0]["Description"] != DBNull.Value)
                    Entity.Description = Convert.ToString(dt.Rows[0]["Description"]);

            }
            return Entity;
        }

        public System.Data.DataTable Select(DML.TBAirPlane entity, String filter)
        {
            SqlParameter[] sqlParam = new SqlParameter[5];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 2147483646);
            sqlParam[1].Value = entity.Name;
            sqlParam[2] = new SqlParameter("@MadeIn", SqlDbType.Int, 4);
            sqlParam[2].Value = entity.MadeIn;
            sqlParam[3] = new SqlParameter("@Description", SqlDbType.NVarChar, 2147483646);
            sqlParam[3].Value = entity.Description;
            sqlParam[4] = new SqlParameter("@filter", SqlDbType.NVarChar);
            sqlParam[4].Value = filter;

            return db.RetToDataTable("sp_TBAirPlane_Select", sqlParam);
        }


    }
}
