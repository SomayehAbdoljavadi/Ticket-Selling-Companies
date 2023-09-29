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
    public class TBMembers
    {
        DAL.TBMembers dal = new DAL.TBMembers();
        public DML.TBMembers dml = new DML.TBMembers();


        private DataTable dataTable;

        public DataTable Select(DML.TBMembers entity)
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
                DML.TBMembers entity = new DML.TBMembers();
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

        public DML.TBMembers Select(Object id)
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

        public bool Delete(DML.TBMembers entity)
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

        public int Insert(DML.TBMembers entity)
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

        public bool Update(DML.TBMembers entity)
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

        private String getFilterOptionCode(DML.TBMembers entity)
        {
            try
            {
                StringBuilder sb = new StringBuilder("");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["ID"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["Username"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["Password"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["GoogleEmail"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["YahooEmail"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["MSNEmail"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["OtherEmail"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["DisplayName"]));
                return sb.ToString();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public bool CheckEntityValidity(DML.TBMembers entity)
        {
            try
            {
                bool ret = true;
                ret = ret && ((entity.ID != null) || entity.AllowNull["ID"]);
                ret = ret && ((entity.Username != null) || entity.AllowNull["Username"]);
                ret = ret && ((entity.Password != null) || entity.AllowNull["Password"]);
                ret = ret && ((entity.GoogleEmail != null) || entity.AllowNull["GoogleEmail"]);
                ret = ret && ((entity.YahooEmail != null) || entity.AllowNull["YahooEmail"]);
                ret = ret && ((entity.MSNEmail != null) || entity.AllowNull["MSNEmail"]);
                ret = ret && ((entity.OtherEmail != null) || entity.AllowNull["OtherEmail"]);
                ret = ret && ((entity.DisplayName != null) || entity.AllowNull["DisplayName"]);
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

        public DML.TBMembers CreateEntity(Object ID, Object Username, Object Password, Object GoogleEmail, Object YahooEmail, Object MSNEmail, Object OtherEmail, Object DisplayName)
        {
            DML.TBMembers entity = new DML.TBMembers();
            try
            {
                if (ID != null && ID.ToString() != "")
                    entity.ID = Convert.ToInt32(ID);
                if (Username != null && Username.ToString() != "")
                    entity.Username = Convert.ToString(Username);
                if (Password != null && Password.ToString() != "")
                    entity.Password = Convert.ToString(Password);
                if (GoogleEmail != null && GoogleEmail.ToString() != "")
                    entity.GoogleEmail = Convert.ToString(GoogleEmail);
                if (YahooEmail != null && YahooEmail.ToString() != "")
                    entity.YahooEmail = Convert.ToString(YahooEmail);
                if (MSNEmail != null && MSNEmail.ToString() != "")
                    entity.MSNEmail = Convert.ToString(MSNEmail);
                if (OtherEmail != null && OtherEmail.ToString() != "")
                    entity.OtherEmail = Convert.ToString(OtherEmail);
                if (DisplayName != null && DisplayName.ToString() != "")
                    entity.DisplayName = Convert.ToString(DisplayName);

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

        public DML.TBMembers AddEntity(DML.TBMembers entity)
        {
            if (entity.ID != null)
                this.dml.ID = entity.ID;
            if (entity.Username != null)
                this.dml.Username = entity.Username;
            if (entity.Password != null)
                this.dml.Password = entity.Password;
            if (entity.GoogleEmail != null)
                this.dml.GoogleEmail = entity.GoogleEmail;
            if (entity.YahooEmail != null)
                this.dml.YahooEmail = entity.YahooEmail;
            if (entity.MSNEmail != null)
                this.dml.MSNEmail = entity.MSNEmail;
            if (entity.OtherEmail != null)
                this.dml.OtherEmail = entity.OtherEmail;
            if (entity.DisplayName != null)
                this.dml.DisplayName = entity.DisplayName;

            return this.dml;
        }
    }
}
