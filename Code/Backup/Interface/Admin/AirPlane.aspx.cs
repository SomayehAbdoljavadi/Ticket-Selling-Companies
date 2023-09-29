using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_AirPlane : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DCL.TBAirPlane dcl = new DCL.TBAirPlane();
            DCL.TBCountry codcl = new DCL.TBCountry();
            DataTable Dtco = codcl.SelectAll();
            DdlCountry.DataSource = Dtco;
            DdlCountry.DataTextField = "Name";
            DdlCountry.DataValueField = "ID";
            DdlCountry.DataBind();
            if (Request.QueryString["DeleteId"] != null)
            {
                dcl.Delete(Request.QueryString["DeleteId"].ToString());
            }
            else if (Request.QueryString["EditeId"] != null)
            {
                HdfID.Value = Request.QueryString["EditeId"].ToString();
                DataTable DtS = dcl.Select(dcl.CreateEntity(HdfID.Value, null, null, null));
                if (DtS.Rows.Count > 0)
                {
                    TxtName.Text = DtS.Rows[0]["Name"].ToString();
                    TxtDescription.Text = DtS.Rows[0]["Description"].ToString();
                    for (int i = 0; i < DdlCountry.Items.Count; i++)
                    {
                        DdlCountry.SelectedIndex = i;
                        if (DdlCountry.SelectedValue == DtS.Rows[0]["MadeIn"].ToString())
                            break;
                    }
                }
            }
            DataTable Dt = dcl.SelectAll();
            DgvAirPlane.DataSource = Dt;
            DgvAirPlane.DataBind();
        }
        catch (Exception ex)
        {
            AirPlaneError.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " پیش آمده است .</span>";
        }
    }
    protected void Btn_Ok_Click(object sender, EventArgs e)
    {
        try
        {
            if (TxtName.Text == string.Empty)
                throw new Exception("خالی بودن فیلد های حیاطی پیش آمده است .");
            DCL.TBAirPlane dcl = new DCL.TBAirPlane();
            if (HdfID.Value == "0")
            {
                dcl.Insert(dcl.CreateEntity(null, TxtName.Text, DdlCountry.SelectedValue.ToString(), TxtDescription.Text));
            }
            else
            {
                dcl.Update(dcl.CreateEntity(HdfID.Value, TxtName.Text, DdlCountry.SelectedValue.ToString(), TxtDescription.Text));
            }
            AirPlaneError.InnerHtml = "<span style='color:Green;'>اطلاعات مورد نظر به درستی ثبت گردید .</span>";
            DCL.TBCountry codcl = new DCL.TBCountry();
            DataTable Dtco = codcl.SelectAll();
            DdlCountry.DataSource = Dtco;
            DdlCountry.DataTextField = "Name";
            DdlCountry.DataValueField = "ID";
            DdlCountry.DataBind();
            DataTable Dt = dcl.SelectAll();
            DgvAirPlane.DataSource = Dt;
            DgvAirPlane.DataBind();
        }
        catch (Exception ex)
        {
            AirPlaneError.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " پیش آمده است .</span>";
        }
    }
}