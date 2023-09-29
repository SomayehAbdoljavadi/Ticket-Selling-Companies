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
    public class TBHotelStars
    {
        DAL.TBHotelStars dal = new DAL.TBHotelStars();
        public DML.TBHotelStars dml = new DML.TBHotelStars();


        private DataTable dataTable;

        public DataTable Select(DML.TBHotelStars entity)
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
                DML.TBHotelStars entity = new DML.TBHotelStars();
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

        public DML.TBHotelStars Select(Object id)
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

        public bool Delete(DML.TBHotelStars entity)
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

        public int Insert(DML.TBHotelStars entity)
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

        public bool Update(DML.TBHotelStars entity)
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

        private String getFilterOptionCode(DML.TBHotelStars entity)
        {
            try
            {
                StringBuilder sb = new StringBuilder("");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["ID"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["Caption"]));
                return sb.ToString();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public bool CheckEntityValidity(DML.TBHotelStars entity)
        {
            try
            {
                bool ret = true;
                ret = ret && ((entity.ID != null) || entity.AllowNull["ID"]);
                ret = ret && ((entity.Caption != null) || entity.AllowNull["Caption"]);
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

        public DML.TBHotelStars CreateEntity(Object ID, Object Caption)
        {
            DML.TBHotelStars entity = new DML.TBHotelStars();
            try
            {
                if (ID != null && ID.ToString() != "")
                    entity.ID = Convert.ToInt32(ID);
                if (Caption != null && Caption.ToString() != "")
                    entity.Caption = Convert.ToString(Caption);

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

        public DML.TBHotelStars AddEntity(DML.TBHotelStars entity)
        {
            if (entity.ID != null)
                this.dml.ID = entity.ID;
            if (entity.Caption != null)
                this.dml.Caption = entity.Caption;

            return this.dml;
        }
    }
}
