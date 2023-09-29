using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using DML;

namespace DCL
{
    public class TBTour
    {
        DAL.TBTour dal = new DAL.TBTour();
        public DML.TBTour dml = new DML.TBTour();


        private DataTable dataTable;

        public DataTable Select(DML.TBTour entity)
        {
            try
            {
                this.dataTable = dal.Select(entity, getFilterOptionCode(entity));
                return this.dataTable;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public DataTable SelectAll()
        {
            try
            {
                DML.TBTour entity = new DML.TBTour();
                return Select(entity);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public DataTable Select()
        {
            return Select(this.dml);
        }

        public DML.TBTour Select(Object id)
        {
            if (id == null)
                throw new ArgumentNullException("The ID Number Cannot Be Empty!");

            try
            {
                Int32 Id = Convert.ToInt32(id);
                this.dml = dal.SelectById(Id);
                return this.dml;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(Object id)
        {
            bool ret = true;
            try
            {
                Int32 _id = Convert.ToInt32(id);
                dal.Delete(_id);
                if (dal.SelectById(_id).ID == _id)
                    ret = false;
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return ret;
        }

        public bool Delete(DML.TBTour entity)
        {
            if (entity == null)
                throw new ArgumentNullException("The Argument Cannot Be Null!");

            if (entity.ID == null)
                throw new ArgumentException("The ID Number Cannot Be Null!");

            return Delete(entity.ID);
        }

        public bool Delete()
        {
            return Delete(this.dml);
        }

        public int Insert(DML.TBTour entity)
        {
            if (entity == null)
                throw new ArgumentNullException("The Argument Cannot Be Null!");

            entity.ID = -1;

            if (!CheckEntityValidity(entity))
                throw new ArgumentException("The Argument is Not Valid!");

            try
            {
                return dal.Insert(entity);
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        public int Insert()
        {
            return Insert(this.dml);
        }

        public bool Update(DML.TBTour entity)
        {
            if (entity == null)
                throw new ArgumentNullException("The Argument Cannot Be Null!");

            if (!CheckEntityValidity(entity))
                throw new ArgumentException("The Argument is Not Valid!");

            bool ret = false;
            try
            {
                dal.Update(entity);
                ret = true;
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return ret;
        }

        public bool Update()
        {
            return Update(this.dml);
        }

        public DataTable GetDataSource()
        {
            try
            {
                return this.dataTable;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private String getFilterOptionCode(DML.TBTour entity)
        {
            try
            {
                StringBuilder sb = new StringBuilder("");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["ID"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["Name"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["Hotel"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["AirPlane"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["Price"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["LengthDays"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["lengthNights"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["City"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["Date"]));
                return sb.ToString();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public bool CheckEntityValidity(DML.TBTour entity)
        {
            try
            {
                bool ret = true;
                ret = ret && ((entity.ID != null) || entity.AllowNull["ID"]);
                ret = ret && ((entity.Name != null) || entity.AllowNull["Name"]);
                ret = ret && ((entity.Hotel != null) || entity.AllowNull["Hotel"]);
                ret = ret && ((entity.AirPlane != null) || entity.AllowNull["AirPlane"]);
                ret = ret && ((entity.Price != null) || entity.AllowNull["Price"]);
                ret = ret && ((entity.LengthDays != null) || entity.AllowNull["LengthDays"]);
                ret = ret && ((entity.lengthNights != null) || entity.AllowNull["lengthNights"]);
                ret = ret && ((entity.City != null) || entity.AllowNull["City"]);
                ret = ret && ((entity.Date != null) || entity.AllowNull["Date"]);
                return ret;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public bool CheckEntityValidity()
        {
            return CheckEntityValidity(this.dml);
        }

        public DML.TBTour CreateEntity(Object ID, Object Name, Object Hotel, Object AirPlane, Object Price, Object LengthDays, Object lengthNights, Object City, Object Date)
        {
            DML.TBTour entity = new DML.TBTour();
            try
            {
                if (ID != null && ID.ToString() != "")
                    entity.ID = Convert.ToInt32(ID);
                if (Name != null && Name.ToString() != "")
                    entity.Name = Convert.ToString(Name);
                if (Hotel != null && Hotel.ToString() != "")
                    entity.Hotel = Convert.ToInt32(Hotel);
                if (AirPlane != null && AirPlane.ToString() != "")
                    entity.AirPlane = Convert.ToInt32(AirPlane);
                if (Price != null && Price.ToString() != "")
                    entity.Price = Convert.ToString(Price);
                if (LengthDays != null && LengthDays.ToString() != "")
                    entity.LengthDays = Convert.ToInt32(LengthDays);
                if (lengthNights != null && lengthNights.ToString() != "")
                    entity.lengthNights = Convert.ToInt32(lengthNights);
                if (City != null && City.ToString() != "")
                    entity.City = Convert.ToInt32(City);
                if (Date != null && Date.ToString() != "")
                    entity.Date = Convert.ToString(Date);

                this.dml = entity;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return entity;
        }

        //public void SetNumberInput_Event(System.Windows.Forms.Form frm)
        //{
        //    for (int i = 0; i < frm.Controls.Count; i++)
        //    {
        //        if (frm.Controls[i].GetType() == typeof(System.Windows.Forms.TextBox))
        //        {
        //            System.Windows.Forms.TextBox t = (frm.Controls[i] as System.Windows.Forms.TextBox);
        //            if (t.Tag != null && t.Tag.ToString() != "")
        //            {
        //                if (dml.DataType[t.Tag.ToString()] == typeof(Int16) ||
        //                    dml.DataType[t.Tag.ToString()] == typeof(Int32) ||
        //                    dml.DataType[t.Tag.ToString()] == typeof(Int64) ||
        //                    dml.DataType[t.Tag.ToString()] == typeof(Byte) ||
        //                    dml.DataType[t.Tag.ToString()] == typeof(Char))
        //                    SetDigitNumeric(ref t);

        //                if (dml.DataType[t.Tag.ToString()] == typeof(Single) ||
        //                    dml.DataType[t.Tag.ToString()] == typeof(float) ||
        //                    dml.DataType[t.Tag.ToString()] == typeof(Double))
        //                    SetRealNumeric(ref t);
        //            }
        //        }
        //    }
        //}

        //public void SetDigitNumeric(ref System.Windows.Forms.TextBox txt)
        //{
        //    txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(digitNumeric);
        //}

        //public void SetRealNumeric(ref System.Windows.Forms.TextBox txt)
        //{
        //    txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(realNumeric);
        //}

        //void digitNumeric(object sender, System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b'))
        //        e.Handled = true;
        //}

        //void realNumeric(object sender, System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    if (!((e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b') || (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') < 0)))
        //        e.Handled = true;
        //}

        //public void SetFocusColor_Event(ref System.Windows.Forms.TextBox txt)
        //{
        //    txt.Enter += new EventHandler(txt_Enter);
        //    txt.Leave += new EventHandler(txt_Leave);
        //}

        //public void SetFocusColor_Event(System.Windows.Forms.Form frm)
        //{
        //    for (int i = 0; i < frm.Controls.Count; i++)
        //    {
        //        if (frm.Controls[i].GetType() == typeof(System.Windows.Forms.TextBox))
        //        {
        //            System.Windows.Forms.TextBox t = (frm.Controls[i] as System.Windows.Forms.TextBox);
        //            SetFocusColor_Event(ref t);
        //        }
        //    }
        //}

        //void txt_Leave(object sender, EventArgs e)
        //{
        //    (sender as System.Windows.Forms.TextBox).BackColor = System.Drawing.Color.White;
        //}

        //void txt_Enter(object sender, EventArgs e)
        //{
        //    (sender as System.Windows.Forms.TextBox).BackColor = System.Drawing.Color.Yellow;
        //}

        public DML.TBTour AddEntity(DML.TBTour entity)
        {
            if (entity.ID != null)
                this.dml.ID = entity.ID;
            if (entity.Name != null)
                this.dml.Name = entity.Name;
            if (entity.Hotel != null)
                this.dml.Hotel = entity.Hotel;
            if (entity.AirPlane != null)
                this.dml.AirPlane = entity.AirPlane;
            if (entity.Price != null)
                this.dml.Price = entity.Price;
            if (entity.LengthDays != null)
                this.dml.LengthDays = entity.LengthDays;
            if (entity.lengthNights != null)
                this.dml.lengthNights = entity.lengthNights;
            if (entity.City != null)
                this.dml.City = entity.City;
            if (entity.Date != null)
                this.dml.Date = entity.Date;

            return this.dml;
        }
    }
}
