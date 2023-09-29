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
    public class TBMembers
    {
        DBL.DB db = new DBL.DB();
        public int Insert(DML.TBMembers entity)
        {
            SqlParameter[] sqlParam = new SqlParameter[8];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@Username", SqlDbType.NVarChar, 2147483646);
            sqlParam[1].Value = entity.Username;
            sqlParam[2] = new SqlParameter("@Password", SqlDbType.NVarChar, 2147483646);
            sqlParam[2].Value = entity.Password;
            sqlParam[3] = new SqlParameter("@GoogleEmail", SqlDbType.NVarChar, 2147483646);
            sqlParam[3].Value = entity.GoogleEmail;
            sqlParam[4] = new SqlParameter("@YahooEmail", SqlDbType.NVarChar, 2147483646);
            sqlParam[4].Value = entity.YahooEmail;
            sqlParam[5] = new SqlParameter("@MSNEmail", SqlDbType.NVarChar, 2147483646);
            sqlParam[5].Value = entity.MSNEmail;
            sqlParam[6] = new SqlParameter("@OtherEmail", SqlDbType.NVarChar, 2147483646);
            sqlParam[6].Value = entity.OtherEmail;
            sqlParam[7] = new SqlParameter("@DisplayName", SqlDbType.NVarChar, 100);
            sqlParam[7].Value = entity.DisplayName;

            return db.ExecuteNonQuery("sp_TBMembers_Insert", sqlParam);
        }

        public void Delete(DML.TBMembers entity)
        {
            Delete(entity.ID);
        }

        public void Delete(Int32? id)
        {
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@id", id);
            db.ExecuteNonQuery("sp_TBMembers_Delete", sp);
        }

        public void Update(DML.TBMembers entity)
        {
            SqlParameter[] sqlParam = new SqlParameter[8];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@Username", SqlDbType.NVarChar, 2147483646);
            sqlParam[1].Value = entity.Username;
            sqlParam[2] = new SqlParameter("@Password", SqlDbType.NVarChar, 2147483646);
            sqlParam[2].Value = entity.Password;
            sqlParam[3] = new SqlParameter("@GoogleEmail", SqlDbType.NVarChar, 2147483646);
            sqlParam[3].Value = entity.GoogleEmail;
            sqlParam[4] = new SqlParameter("@YahooEmail", SqlDbType.NVarChar, 2147483646);
            sqlParam[4].Value = entity.YahooEmail;
            sqlParam[5] = new SqlParameter("@MSNEmail", SqlDbType.NVarChar, 2147483646);
            sqlParam[5].Value = entity.MSNEmail;
            sqlParam[6] = new SqlParameter("@OtherEmail", SqlDbType.NVarChar, 2147483646);
            sqlParam[6].Value = entity.OtherEmail;
            sqlParam[7] = new SqlParameter("@DisplayName", SqlDbType.NVarChar, 100);
            sqlParam[7].Value = entity.DisplayName;

            db.ExecuteNonQuery("sp_TBMembers_Update", sqlParam);
        }

        public DML.TBMembers SelectById(Int32? id)
        {
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@id", id);
            DataTable dt = db.RetToDataTable("sp_TBMembers_SelectById", sp);
            DML.TBMembers Entity = new DML.TBMembers();
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0]["ID"] != null && dt.Rows[0]["ID"] != DBNull.Value)
                    Entity.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                if (dt.Rows[0]["Username"] != null && dt.Rows[0]["Username"] != DBNull.Value)
                    Entity.Username = Convert.ToString(dt.Rows[0]["Username"]);
                if (dt.Rows[0]["Password"] != null && dt.Rows[0]["Password"] != DBNull.Value)
                    Entity.Password = Convert.ToString(dt.Rows[0]["Password"]);
                if (dt.Rows[0]["GoogleEmail"] != null && dt.Rows[0]["GoogleEmail"] != DBNull.Value)
                    Entity.GoogleEmail = Convert.ToString(dt.Rows[0]["GoogleEmail"]);
                if (dt.Rows[0]["YahooEmail"] != null && dt.Rows[0]["YahooEmail"] != DBNull.Value)
                    Entity.YahooEmail = Convert.ToString(dt.Rows[0]["YahooEmail"]);
                if (dt.Rows[0]["MSNEmail"] != null && dt.Rows[0]["MSNEmail"] != DBNull.Value)
                    Entity.MSNEmail = Convert.ToString(dt.Rows[0]["MSNEmail"]);
                if (dt.Rows[0]["OtherEmail"] != null && dt.Rows[0]["OtherEmail"] != DBNull.Value)
                    Entity.OtherEmail = Convert.ToString(dt.Rows[0]["OtherEmail"]);
                if (dt.Rows[0]["DisplayName"] != null && dt.Rows[0]["DisplayName"] != DBNull.Value)
                    Entity.DisplayName = Convert.ToString(dt.Rows[0]["DisplayName"]);

            }
            return Entity;
        }

        public System.Data.DataTable Select(DML.TBMembers entity, String filter)
        {
            SqlParameter[] sqlParam = new SqlParameter[9];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@Username", SqlDbType.NVarChar, 2147483646);
            sqlParam[1].Value = entity.Username;
            sqlParam[2] = new SqlParameter("@Password", SqlDbType.NVarChar, 2147483646);
            sqlParam[2].Value = entity.Password;
            sqlParam[3] = new SqlParameter("@GoogleEmail", SqlDbType.NVarChar, 2147483646);
            sqlParam[3].Value = entity.GoogleEmail;
            sqlParam[4] = new SqlParameter("@YahooEmail", SqlDbType.NVarChar, 2147483646);
            sqlParam[4].Value = entity.YahooEmail;
            sqlParam[5] = new SqlParameter("@MSNEmail", SqlDbType.NVarChar, 2147483646);
            sqlParam[5].Value = entity.MSNEmail;
            sqlParam[6] = new SqlParameter("@OtherEmail", SqlDbType.NVarChar, 2147483646);
            sqlParam[6].Value = entity.OtherEmail;
            sqlParam[7] = new SqlParameter("@DisplayName", SqlDbType.NVarChar, 100);
            sqlParam[7].Value = entity.DisplayName;
            sqlParam[8] = new SqlParameter("@filter", SqlDbType.NVarChar);
            sqlParam[8].Value = filter;

            return db.RetToDataTable("sp_TBMembers_Select", sqlParam);
        }


    }
}
