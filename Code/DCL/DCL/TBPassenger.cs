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
    public class TBPassenger
    {
        DAL.TBPassenger dal = new DAL.TBPassenger();
        public DML.TBPassenger dml = new DML.TBPassenger();


        private DataTable dataTable;

        public DataTable Select(DML.TBPassenger entity)
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
                DML.TBPassenger entity = new DML.TBPassenger();
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

        public DML.TBPassenger Select(Object id)
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

        public bool Delete(DML.TBPassenger entity)
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

        public int Insert(DML.TBPassenger entity)
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

        public bool Update(DML.TBPassenger entity)
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

        private String getFilterOptionCode(DML.TBPassenger entity)
        {
            try
            {
                StringBuilder sb = new StringBuilder("");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["ID"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["User_ID"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["Name"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["Family"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["Address"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["City"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["Birthday"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["NationalCode"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["PasPortCode"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["Tell"])).Append("-");
                sb.Append(FilterOperatorValue.GetValue(entity.FilterOption["PreCuontryTellCode"]));
                return sb.ToString();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public bool CheckEntityValidity(DML.TBPassenger entity)
        {
            try
            {
                bool ret = true;
                ret = ret && ((entity.ID != null) || entity.AllowNull["ID"]);
                ret = ret && ((entity.User_ID != null) || entity.AllowNull["User_ID"]);
                ret = ret && ((entity.Name != null) || entity.AllowNull["Name"]);
                ret = ret && ((entity.Family != null) || entity.AllowNull["Family"]);
                ret = ret && ((entity.Address != null) || entity.AllowNull["Address"]);
                ret = ret && ((entity.City != null) || entity.AllowNull["City"]);
                ret = ret && ((entity.Birthday != null) || entity.AllowNull["Birthday"]);
                ret = ret && ((entity.NationalCode != null) || entity.AllowNull["NationalCode"]);
                ret = ret && ((entity.PasPortCode != null) || entity.AllowNull["PasPortCode"]);
                ret = ret && ((entity.Tell != null) || entity.AllowNull["Tell"]);
                ret = ret && ((entity.PreCuontryTellCode != null) || entity.AllowNull["PreCuontryTellCode"]);
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

        public DML.TBPassenger CreateEntity(Object ID, Object User_ID, Object Name, Object Family, Object Address, Object City, Object Birthday, Object NationalCode, Object PasPortCode, Object Tell, Object PreCuontryTellCode)
        {
            DML.TBPassenger entity = new DML.TBPassenger();
            try
            {
                if (ID != null && ID.ToString() != "")
                    entity.ID = Convert.ToInt32(ID);
                if (User_ID != null && User_ID.ToString() != "")
                    entity.User_ID = Convert.ToInt32(User_ID);
                if (Name != null && Name.ToString() != "")
                    entity.Name = Convert.ToString(Name);
                if (Family != null && Family.ToString() != "")
                    entity.Family = Convert.ToString(Family);
                if (Address != null && Address.ToString() != "")
                    entity.Address = Convert.ToString(Address);
                if (City != null && City.ToString() != "")
                    entity.City = Convert.ToInt32(City);
                if (Birthday != null && Birthday.ToString() != "")
                    entity.Birthday = Convert.ToString(Birthday);
                if (NationalCode != null && NationalCode.ToString() != "")
                    entity.NationalCode = Convert.ToString(NationalCode);
                if (PasPortCode != null && PasPortCode.ToString() != "")
                    entity.PasPortCode = Convert.ToString(PasPortCode);
                if (Tell != null && Tell.ToString() != "")
                    entity.Tell = Convert.ToString(Tell);
                if (PreCuontryTellCode != null && PreCuontryTellCode.ToString() != "")
                    entity.PreCuontryTellCode = Convert.ToString(PreCuontryTellCode);

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

        public DML.TBPassenger AddEntity(DML.TBPassenger entity)
        {
            if (entity.ID != null)
                this.dml.ID = entity.ID;
            if (entity.User_ID != null)
                this.dml.User_ID = entity.User_ID;
            if (entity.Name != null)
                this.dml.Name = entity.Name;
            if (entity.Family != null)
                this.dml.Family = entity.Family;
            if (entity.Address != null)
                this.dml.Address = entity.Address;
            if (entity.City != null)
                this.dml.City = entity.City;
            if (entity.Birthday != null)
                this.dml.Birthday = entity.Birthday;
            if (entity.NationalCode != null)
                this.dml.NationalCode = entity.NationalCode;
            if (entity.PasPortCode != null)
                this.dml.PasPortCode = entity.PasPortCode;
            if (entity.Tell != null)
                this.dml.Tell = entity.Tell;
            if (entity.PreCuontryTellCode != null)
                this.dml.PreCuontryTellCode = entity.PreCuontryTellCode;

            return this.dml;
        }
    }
}
