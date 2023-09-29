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
    public class TBTour
    {
        DBL.DB db = new DBL.DB();
        public int Insert(DML.TBTour entity)
        {
            SqlParameter[] sqlParam = new SqlParameter[9];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 2147483646);
            sqlParam[1].Value = entity.Name;
            sqlParam[2] = new SqlParameter("@Hotel", SqlDbType.Int, 4);
            sqlParam[2].Value = entity.Hotel;
            sqlParam[3] = new SqlParameter("@AirPlane", SqlDbType.Int, 4);
            sqlParam[3].Value = entity.AirPlane;
            sqlParam[4] = new SqlParameter("@Price", SqlDbType.NVarChar, 40);
            sqlParam[4].Value = entity.Price;
            sqlParam[5] = new SqlParameter("@LengthDays", SqlDbType.Int, 4);
            sqlParam[5].Value = entity.LengthDays;
            sqlParam[6] = new SqlParameter("@lengthNights", SqlDbType.Int, 4);
            sqlParam[6].Value = entity.lengthNights;
            sqlParam[7] = new SqlParameter("@City", SqlDbType.Int, 4);
            sqlParam[7].Value = entity.City;
            sqlParam[8] = new SqlParameter("@Date", SqlDbType.NVarChar, 10);
            sqlParam[8].Value = entity.Date;

            return db.ExecuteNonQuery("sp_TBTour_Insert", sqlParam);
        }

        public void Delete(DML.TBTour entity)
        {
            Delete(entity.ID);
        }

        public void Delete(Int32? id)
        {
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@id", id);
            db.ExecuteNonQuery("sp_TBTour_Delete", sp);
        }

        public void Update(DML.TBTour entity)
        {
            SqlParameter[] sqlParam = new SqlParameter[9];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 2147483646);
            sqlParam[1].Value = entity.Name;
            sqlParam[2] = new SqlParameter("@Hotel", SqlDbType.Int, 4);
            sqlParam[2].Value = entity.Hotel;
            sqlParam[3] = new SqlParameter("@AirPlane", SqlDbType.Int, 4);
            sqlParam[3].Value = entity.AirPlane;
            sqlParam[4] = new SqlParameter("@Price", SqlDbType.NVarChar, 40);
            sqlParam[4].Value = entity.Price;
            sqlParam[5] = new SqlParameter("@LengthDays", SqlDbType.Int, 4);
            sqlParam[5].Value = entity.LengthDays;
            sqlParam[6] = new SqlParameter("@lengthNights", SqlDbType.Int, 4);
            sqlParam[6].Value = entity.lengthNights;
            sqlParam[7] = new SqlParameter("@City", SqlDbType.Int, 4);
            sqlParam[7].Value = entity.City;
            sqlParam[8] = new SqlParameter("@Date", SqlDbType.NVarChar, 10);
            sqlParam[8].Value = entity.Date;

            db.ExecuteNonQuery("sp_TBTour_Update", sqlParam);
        }

        public DML.TBTour SelectById(Int32? id)
        {
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@id", id);
            DataTable dt = db.RetToDataTable("sp_TBTour_SelectById", sp);
            DML.TBTour Entity = new DML.TBTour();
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0]["ID"] != null && dt.Rows[0]["ID"] != DBNull.Value)
                    Entity.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                if (dt.Rows[0]["Name"] != null && dt.Rows[0]["Name"] != DBNull.Value)
                    Entity.Name = Convert.ToString(dt.Rows[0]["Name"]);
                if (dt.Rows[0]["Hotel"] != null && dt.Rows[0]["Hotel"] != DBNull.Value)
                    Entity.Hotel = Convert.ToInt32(dt.Rows[0]["Hotel"]);
                if (dt.Rows[0]["AirPlane"] != null && dt.Rows[0]["AirPlane"] != DBNull.Value)
                    Entity.AirPlane = Convert.ToInt32(dt.Rows[0]["AirPlane"]);
                if (dt.Rows[0]["Price"] != null && dt.Rows[0]["Price"] != DBNull.Value)
                    Entity.Price = Convert.ToString(dt.Rows[0]["Price"]);
                if (dt.Rows[0]["LengthDays"] != null && dt.Rows[0]["LengthDays"] != DBNull.Value)
                    Entity.LengthDays = Convert.ToInt32(dt.Rows[0]["LengthDays"]);
                if (dt.Rows[0]["lengthNights"] != null && dt.Rows[0]["lengthNights"] != DBNull.Value)
                    Entity.lengthNights = Convert.ToInt32(dt.Rows[0]["lengthNights"]);
                if (dt.Rows[0]["City"] != null && dt.Rows[0]["City"] != DBNull.Value)
                    Entity.City = Convert.ToInt32(dt.Rows[0]["City"]);
                if (dt.Rows[0]["Date"] != null && dt.Rows[0]["Date"] != DBNull.Value)
                    Entity.Date = Convert.ToString(dt.Rows[0]["Date"]);

            }
            return Entity;
        }

        public System.Data.DataTable Select(DML.TBTour entity, String filter)
        {
            SqlParameter[] sqlParam = new SqlParameter[10];

            sqlParam[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            sqlParam[0].Value = entity.ID;
            sqlParam[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 2147483646);
            sqlParam[1].Value = entity.Name;
            sqlParam[2] = new SqlParameter("@Hotel", SqlDbType.Int, 4);
            sqlParam[2].Value = entity.Hotel;
            sqlParam[3] = new SqlParameter("@AirPlane", SqlDbType.Int, 4);
            sqlParam[3].Value = entity.AirPlane;
            sqlParam[4] = new SqlParameter("@Price", SqlDbType.NVarChar, 40);
            sqlParam[4].Value = entity.Price;
            sqlParam[5] = new SqlParameter("@LengthDays", SqlDbType.Int, 4);
            sqlParam[5].Value = entity.LengthDays;
            sqlParam[6] = new SqlParameter("@lengthNights", SqlDbType.Int, 4);
            sqlParam[6].Value = entity.lengthNights;
            sqlParam[7] = new SqlParameter("@City", SqlDbType.Int, 4);
            sqlParam[7].Value = entity.City;
            sqlParam[8] = new SqlParameter("@Date", SqlDbType.NVarChar, 10);
            sqlParam[8].Value = entity.Date;
            sqlParam[9] = new SqlParameter("@filter", SqlDbType.NVarChar);
            sqlParam[9].Value = filter;

            return db.RetToDataTable("sp_TBTour_Select", sqlParam);
        }


    }
}
