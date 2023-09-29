using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_City : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["CountryID"] != null)
            {
                DCL.TBCity dcl = new DCL.TBCity();
                if (!IsPostBack)
                {
                    if (Request.QueryString["EditId"] != null)
                    {
                        DataTable Dt = dcl.Select(dcl.CreateEntity(Request.QueryString["EditId"].ToString(), null, null));
                        if (Dt.Rows.Count > 0)
                        {
                            HdfID.Value = Dt.Rows[0]["ID"].ToString();
                            TxtName.Text = Dt.Rows[0]["Name"].ToString();
                        }
                    }
                    else if (Request.QueryString["DeleteId"] != null)
                    {
                        dcl.Delete(Request.QueryString["DeleteId"].ToString());
                    }
                }
                DataTable Dt1 = dcl.Select(dcl.CreateEntity(null, Request.QueryString["CountryID"].ToString(), null));
                DgvCity.DataSource = Dt1;
                DgvCity.DataBind();
            }
            else
            {
                Response.Redirect("Country.aspx");
            }
        }
        catch (Exception ex)
        {
            DivCityError.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " پیش آمده است .</span>";
        }
    }
    protected void HdfID_ValueChanged(object sender, EventArgs e)
    {

    }
    protected void BtnOk_Click(object sender, EventArgs e)
    {
        try
        {
            if(TxtName.Text == string.Empty)
                throw new Exception("عدم وجود نام ");
            DCL.TBCity dcl = new DCL.TBCity();
            if (HdfID.Value == "0")
            {
                dcl.Insert(dcl.CreateEntity(null,Request.QueryString["CountryID"].ToString(),TxtName.Text));
            }
            else
            {
                dcl.Update(dcl.CreateEntity(HdfID.Value,Request.QueryString["CountryID"].ToString(),TxtName.Text));
            }
            DivCityError.InnerHtml = "<span style='color:Green;'>اطلاعات ثبت گردید.</span>";
            DataTable Dt1 = dcl.Select(dcl.CreateEntity(null, Request.QueryString["CountryID"].ToString(), null));
            DgvCity.DataSource = Dt1;
            DgvCity.DataBind();
        }
        catch (Exception ex)
        {
            DivCityError.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " پیش آمده است .</span>";
        }
    }
}