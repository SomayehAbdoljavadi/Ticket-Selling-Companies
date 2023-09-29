using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Country : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DCL.TBCountry dcl = new DCL.TBCountry();
        if (!IsPostBack)
        {
            DataTable Dt;
            if (Request.QueryString["EditId"] != null)
            {
                object obj = (Object)Request.QueryString["EditId"].ToString();
                Dt = dcl.Select(dcl.CreateEntity(obj,null,null));
                if (Dt.Rows.Count > 0)
                {
                    String Captial = Dt.Rows[0]["Capital"].ToString();
                    HdfID.Value = Dt.Rows[0]["ID"].ToString();
                    txt_Name.Text = Dt.Rows[0]["Name"].ToString();
                    DCL.TBCity cdcl = new DCL.TBCity();
                    Dt = cdcl.Select(cdcl.CreateEntity(null,Dt.Rows[0]["ID"].ToString(),null));
                    DdlCity.DataSource = Dt;
                    DdlCity.DataTextField = "Name";
                    DdlCity.DataValueField = "ID";
                    DdlCity.DataBind();
                    for (int i = 0; i < DdlCity.Items.Count; i++)
                    {
                        DdlCity.SelectedIndex = i;
                        if (DdlCity.SelectedValue == Captial)
                        {
                            break;
                        }
                    }
                }
            }
            else if (Request.QueryString["DeleteId"] != null)
            {
                 object obj = (Object)Request.QueryString["DeleteId"].ToString();
                 dcl.Delete(obj);
            }
        }
        DataTable Dt1;
        Dt1 = dcl.SelectAll();
        DgvCountry.DataSource = Dt1;
        DgvCountry.DataBind();
    }
    protected void BtnOk_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Name.Text == string.Empty)
                throw new Exception("عدم وجود نام ");
            DCL.TBCountry dcl = new DCL.TBCountry();
            if (HdfID.Value == "0")
            {
                dcl.Insert(dcl.CreateEntity(null, txt_Name.Text, DdlCity.SelectedValue.ToString()));
            }
            else
            {
                dcl.Update(dcl.CreateEntity(HdfID.Value, txt_Name.Text, DdlCity.SelectedValue.ToString()));
            }
            DivCountryError.InnerHtml = "<span style='color:Green;'>تغییرات به درستی انجام پذیرفت .</span>";
            DataTable Dt1;
            Dt1 = dcl.SelectAll();
            DgvCountry.DataSource = Dt1;
            DgvCountry.DataBind();
        }
        catch (Exception ex)
        {
            DivCountryError.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " پیش آمده است .</span>";
        }
    }
}