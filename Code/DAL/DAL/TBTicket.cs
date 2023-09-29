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
    public class TBTicket
    {
        DBL.DB db = new DBL.DB();
        public int Insert(DML.TBTicket entity)
        {
            SqlParameter[] sqlParam = new SqlParameter[3];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@Member", SqlDbType.Int, 4);
            sqlParam[1].Value = entity.Member;
            sqlParam[2] = new SqlParameter("@Tour", SqlDbType.Int, 4);
            sqlParam[2].Value = entity.Tour;

            return db.ExecuteNonQuery("sp_TBTicket_Insert", sqlParam);
        }

        public void Delete(DML.TBTicket entity)
        {
            Delete(entity.ID);
        }

        public void Delete(Int32? id)
        {
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@id", id);
            db.ExecuteNonQuery("sp_TBTicket_Delete", sp);
        }

        public void Update(DML.TBTicket entity)
        {
            SqlParameter[] sqlParam = new SqlParameter[3];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@Member", SqlDbType.Int, 4);
            sqlParam[1].Value = entity.Member;
            sqlParam[2] = new SqlParameter("@Tour", SqlDbType.Int, 4);
            sqlParam[2].Value = entity.Tour;

            db.ExecuteNonQuery("sp_TBTicket_Update", sqlParam);
        }

        public DML.TBTicket SelectById(Int32? id)
        {
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@id", id);
            DataTable dt = db.RetToDataTable("sp_TBTicket_SelectById", sp);
            DML.TBTicket Entity = new DML.TBTicket();
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0]["ID"] != null && dt.Rows[0]["ID"] != DBNull.Value)
                    Entity.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                if (dt.Rows[0]["Member"] != null && dt.Rows[0]["Member"] != DBNull.Value)
                    Entity.Member = Convert.ToInt32(dt.Rows[0]["Member"]);
                if (dt.Rows[0]["Tour"] != null && dt.Rows[0]["Tour"] != DBNull.Value)
                    Entity.Tour = Convert.ToInt32(dt.Rows[0]["Tour"]);

            }
            return Entity;
        }

        public System.Data.DataTable Select(DML.TBTicket entity, String filter)
        {
            SqlParameter[] sqlParam = new SqlParameter[4];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@Member", SqlDbType.Int, 4);
            sqlParam[1].Value = entity.Member;
            sqlParam[2] = new SqlParameter("@Tour", SqlDbType.Int, 4);
            sqlParam[2].Value = entity.Tour;
            sqlParam[3] = new SqlParameter("@filter", SqlDbType.NVarChar);
            sqlParam[3].Value = filter;

            return db.RetToDataTable("sp_TBTicket_Select", sqlParam);
        }


    }
}
