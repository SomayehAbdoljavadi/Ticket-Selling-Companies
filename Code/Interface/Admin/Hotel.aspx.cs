using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Hotel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DCL.TBHotel dcl = new DCL.TBHotel();
            if (!IsPostBack)
            {
                DCL.TBHotelStars HSdcl = new DCL.TBHotelStars();
                DdlStars.DataSource = HSdcl.SelectAll();
                DdlStars.DataTextField = "Caption";
                DdlStars.DataValueField = "ID";
                DdlStars.DataBind();

                DCL.TBCountry Codcl = new DCL.TBCountry();
                DdlCountry.DataSource = Codcl.SelectAll();
                DdlCountry.DataTextField = "Name";
                DdlCountry.DataValueField = "ID";
                DdlCountry.DataBind();
                DdlCountry_SelectedIndexChanged(null, null);
                if (Request.QueryString["DeleteId"] != null)
                {
                    dcl.Delete(Request.QueryString["DeleteId"].ToString());
                }
                else if (Request.QueryString["EditId"] != null)
                {
                    DataTable Dt1 = dcl.Select(dcl.CreateEntity(Request.QueryString["EditId"].ToString(), null, null, null, null, null, null));
                    if (Dt1.Rows.Count > 0)
                    {
                        HdfID.Value = Dt1.Rows[0]["ID"].ToString();
                        TxtName.Text = Dt1.Rows[0]["Name"].ToString();
                        TxtAddress.Text = Dt1.Rows[0]["Address"].ToString();
                        TxtTell.Text = Dt1.Rows[0]["Tell"].ToString();
                        TxtDescription.Text = Dt1.Rows[0]["Description"].ToString();
                        for (int i = 0; i < DdlStars.Items.Count; i++)
                        {
                            DdlStars.SelectedIndex = i;
                            if (DdlStars.SelectedValue == Dt1.Rows[0]["Stars"].ToString())
                                break;
                        }
                        DCL.TBCity Cdcl = new DCL.TBCity();
                        String CoId = Cdcl.Select(Cdcl.CreateEntity(Dt1.Rows[0]["City"].ToString(), null, null)).Rows[0]["CountryID"].ToString();
                        for (int i = 0; i < DdlCountry.Items.Count; i++)
                        {
                            DdlCountry.SelectedIndex = i;
                            if (DdlCountry.SelectedValue == CoId)
                                break;
                        }
                        for (int i = 0; i < DdlCity.Items.Count; i++)
                        {
                            DdlCity.SelectedIndex = i;
                            if (DdlCity.SelectedValue == Dt1.Rows[0]["City"].ToString())
                                break;
                        }
                    }
                }
            }
            if (Request.QueryString["CityId"] != null)
            {
                DataTable Dt = dcl.Select(dcl.CreateEntity(null, null, null, null, Request.QueryString["CityId"].ToString(), null, null));
                DgvHotel.DataSource = Dt;
                DgvHotel.DataBind();
            }
            else if (Request.QueryString["StarsId"] != null)
            {
                DataTable Dt = dcl.Select(dcl.CreateEntity(null, null, Request.QueryString["StarsId"].ToString(), null, null, null, null));
                DgvHotel.DataSource = Dt;
                DgvHotel.DataBind();
            }
            else
            {
                DataTable Dt = dcl.SelectAll();
                DgvHotel.DataSource = Dt;
                DgvHotel.DataBind();
            }
        }
        catch (Exception ex)
        {
            DivHotelError.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " پیش آمده است .</span>";
        }
    }
    protected void DdlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DCL.TBCity dcl = new DCL.TBCity();
            DdlCity.DataSource = dcl.Select(dcl.CreateEntity(null,DdlCountry.SelectedValue.ToString(),null));
            DdlCity.DataTextField = "Name";
            DdlCity.DataValueField ="ID";
            DdlCity.DataBind();
        }
        catch (Exception ex)
        {
            DivHotelError.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " پیش آمده است .</span>";
        }
    }
    protected void Btn_Ok_Click(object sender, EventArgs e)
    {
        try
        {
            DCL.TBHotel dcl = new DCL.TBHotel();
            if (TxtName.Text == string.Empty)
                throw new Exception("عدم پر نمودن فیلد های اسلی ");
            if (HdfID.Value == "0")
            {
                dcl.Insert(dcl.CreateEntity(null, TxtName.Text, DdlStars.SelectedValue.ToString(), TxtAddress.Text, DdlCity.SelectedValue.ToString(), TxtTell.Text, TxtDescription.Text));
            }
            else
            {
                dcl.Update(dcl.CreateEntity(HdfID.Value, TxtName.Text, DdlStars.SelectedValue.ToString(), TxtAddress.Text, DdlCity.SelectedValue.ToString(), TxtTell.Text, TxtDescription.Text));
            }
            DataTable Dt1 = dcl.SelectAll();
            DgvHotel.DataSource = Dt1;
            DgvHotel.DataBind();
            DivHotelError.InnerHtml = "<span style='color:Green;'>عملیات انجام گردید .</span>";
        }
        catch (Exception ex)
        {
            DivHotelError.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " پیش آمده است .</span>";
        }
    }
}