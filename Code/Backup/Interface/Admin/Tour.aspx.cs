using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Tour : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DCL.TBTour dcl = new DCL.TBTour();
        if (!IsPostBack)
        {
            DCL.TBCountry Codcl = new DCL.TBCountry();
            DdlCountry.DataSource = Codcl.SelectAll();
            DdlCountry.DataTextField = "Name";
            DdlCountry.DataValueField = "ID";
            DdlCountry.DataBind();
            DdlCountry_SelectedIndexChanged(null, null);
            DCL.TBAirPlane APdcl = new DCL.TBAirPlane();
            DdlAirPlane.DataSource = APdcl.SelectAll();
            DdlAirPlane.DataTextField = "Name";
            DdlAirPlane.DataValueField = "ID";
            DdlAirPlane.DataBind();
            if (Request.QueryString["DeleteId"] != null)
            {
                dcl.Delete(Request.QueryString["DeleteId"].ToString());
            }
            else if (Request.QueryString["EditeId"] != null)
            {
                HdfID.Value = Request.QueryString["EditeId"].ToString();
                DataTable Dt = dcl.Select(dcl.CreateEntity(HdfID.Value, null, null, null, null, null, null, null, null));
                if (Dt.Rows.Count > 0)
                {
                    TxtName.Text = Dt.Rows[0]["Name"].ToString();
                    TxtDate.Text = Dt.Rows[0]["Date"].ToString();
                    TxtLengthDays.Text = Dt.Rows[0]["LengthDays"].ToString();
                    TxtlengthNights.Text = Dt.Rows[0]["lengthNights"].ToString();
                    TxtPrice.Text = Dt.Rows[0]["Price"].ToString();
                    for (int i = 0; i < DdlAirPlane.Items.Count; i++)
                    {
                        DdlAirPlane.SelectedIndex = i;
                        if (DdlAirPlane.SelectedValue == Dt.Rows[0]["AirPlane"].ToString())
                            break;
                    }
                    DCL.TBCity Cdcl = new DCL.TBCity();
                    String CoId = Cdcl.Select(Cdcl.CreateEntity(Dt.Rows[0]["City"].ToString(), null, null)).Rows[0]["CountryID"].ToString();
                    for (int i = 0; i < DdlCountry.Items.Count; i++)
                    {
                        DdlCountry.SelectedIndex = i;
                        if (DdlCountry.SelectedValue == CoId)
                            break;
                    }
                    for (int i = 0; i < DdlCity.Items.Count; i++)
                    {
                        DdlCity.SelectedIndex = i;
                        if (DdlCity.SelectedValue == Dt.Rows[0]["City"].ToString())
                            break;
                    }
                    DdlCity_SelectedIndexChanged(null, null);
                    for (int i = 0; i < DdlHotel.Items.Count; i++)
                    {
                        DdlHotel.SelectedIndex = i;
                        if (DdlHotel.SelectedValue == Dt.Rows[0]["Hotel"].ToString())
                            break;
                    }
                }
            }

        }
        DgvTour.DataSource = dcl.SelectAll();
        DgvTour.DataBind();
    }
    protected void DdlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DCL.TBCity dcl = new DCL.TBCity();
            DdlCity.DataSource = dcl.Select(dcl.CreateEntity(null, DdlCountry.SelectedValue.ToString(), null));
            DdlCity.DataTextField = "Name";
            DdlCity.DataValueField = "ID";
            DdlCity.DataBind();
            DdlCity_SelectedIndexChanged(null, null);
        }
        catch (Exception ex)
        {
            DivTourError.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " پیش آمده است .</span>";
        }
    }
    protected void DdlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DCL.TBHotel Hdcl = new DCL.TBHotel();
            DdlHotel.DataSource = Hdcl.Select(Hdcl.CreateEntity(null, null, null, null, DdlCity.SelectedValue.ToString(), null, null));
            DdlHotel.DataTextField = "Name";
            DdlHotel.DataValueField = "ID";
            DdlHotel.DataBind();
        }
        catch (Exception ex)
        {
            DivTourError.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " پیش آمده است .</span>";
        }
    }
    protected void BtnOk_Click(object sender, EventArgs e)
    {
        try
        {
            if (TxtName.Text == string.Empty || TxtDate.Text == string.Empty)
                throw new Exception("پر نکردن فیلد های حیاطی");
            DCL.TBTour dcl = new DCL.TBTour();
            if (HdfID.Value == "0")
            {
                dcl.Insert(dcl.CreateEntity(null, TxtName.Text, DdlHotel.SelectedValue.ToString(), DdlAirPlane.SelectedValue.ToString(), TxtPrice.Text, TxtLengthDays.Text, TxtlengthNights.Text, DdlCity.SelectedValue.ToString(), TxtDate.Text));
            }
            else
            {
                dcl.Update(dcl.CreateEntity(HdfID.Value, TxtName.Text, DdlHotel.SelectedValue.ToString(), DdlAirPlane.SelectedValue.ToString(), TxtPrice.Text, TxtLengthDays.Text, TxtlengthNights.Text, DdlCity.SelectedValue.ToString(), TxtDate.Text));
            }
            DivTourError.InnerHtml = "<span style='color:Green;'>اطلاعات به درستی ثبت گردید .</span>";
            DgvTour.DataSource = dcl.SelectAll();
            DgvTour.DataBind();
        }
        catch (Exception ex)
        {
            DivTourError.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " پیش آمده است .</span>";
        }
    }
}