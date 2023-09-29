using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DCL.TBTour dcl = new DCL.TBTour();
            DivSelect.Visible = false;
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    DCL.TBTicket Tdcl = new DCL.TBTicket();
                    DgvReserves.DataSource = Tdcl.Select(Tdcl.CreateEntity(null, Session["UserId"].ToString(), null));
                    DgvReserves.DataBind();
                    if (Request.QueryString["SelectedId"] != null)
                    {
                        DivSelect.Visible = true;
                        DataTable Dt = dcl.Select(dcl.CreateEntity(Request.QueryString["SelectedId"].ToString(), null, null, null, null, null, null, null, null));
                        if (Dt.Rows.Count > 0)
                        {
                            HdfID.Value = Dt.Rows[0]["ID"].ToString();
                            DivTourName.InnerText = Dt.Rows[0]["Name"].ToString();
                            DivDays.InnerText = Dt.Rows[0]["LengthDays"].ToString();
                            DivNights.InnerText = Dt.Rows[0]["lengthNights"].ToString();
                            DivPrice.InnerText = Dt.Rows[0]["Price"].ToString() + " ریال";
                            DivDate.InnerText = Dt.Rows[0]["Date"].ToString();
                            DCL.TBCity Cdcl = new DCL.TBCity();
                            DCL.TBCountry Codcl = new DCL.TBCountry();
                            DataTable DtCity = Cdcl.Select(Cdcl.CreateEntity(Dt.Rows[0]["City"].ToString(), null, null));
                            DataTable DtCountry = Codcl.Select(Codcl.CreateEntity(DtCity.Rows[0]["CountryID"].ToString(), null, null));
                            DivPlace.InnerText = "کشور : " + DtCountry.Rows[0]["Name"].ToString() + " و شهر : " + DtCity.Rows[0]["Name"].ToString();
                            DCL.TBAirPlane APdcl = new DCL.TBAirPlane();
                            DataTable DtAirPlane = APdcl.Select(APdcl.CreateEntity(Dt.Rows[0]["AirPlane"].ToString(), null, null, null));
                            DivAirPlane.InnerText = "نام : " + DtAirPlane.Rows[0]["Name"].ToString() + " ساخت کشور : " + Codcl.Select(Codcl.CreateEntity(DtAirPlane.Rows[0]["MadeIn"].ToString(), null, null)).Rows[0]["Name"].ToString();
                            DCL.TBHotel Hdcl = new DCL.TBHotel();
                            DataTable DtHotel = Hdcl.Select(Hdcl.CreateEntity(Dt.Rows[0]["Hotel"].ToString(), null, null, null, null, null, null));
                            DCL.TBHotelStars HSdcl = new DCL.TBHotelStars();
                            DivHotel.InnerHtml = "نام هتل : " + DtHotel.Rows[0]["Name"].ToString() + " و آدرس : " + DtHotel.Rows[0]["Address"].ToString() + " شماره ی تماس : " + DtHotel.Rows[0]["Tell"].ToString() + "<br/>وضعیت هتل : " + HSdcl.Select(HSdcl.CreateEntity(DtHotel.Rows[0]["Stars"].ToString(), null)).Rows[0]["Caption"].ToString();
                        }
                    }
                    else if (Request.QueryString["DeleteId"] != null)
                    {
                        Tdcl.Delete(Request.QueryString["DeleteId"].ToString());
                        Response.Redirect("default.aspx");
                    }
                }
            }
            //DgvTour.DataSource = dcl.SelectAll();
            //DgvTour.DataBind();
            if (Session["Username"] == null)
            {
               // DgvTour.Columns[9].Visible = false;
            }
        }
        catch (Exception ex)
        {
            DivDefaultError.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " پیش آمده است .</span>";
        }
    }
    protected void BtnSelect_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["Username"] != null)
            {
                DCL.TBTicket dcl = new DCL.TBTicket();
                dcl.Insert(dcl.CreateEntity(null, Session["UserId"].ToString(), HdfID.Value.ToString()));
                DivDefaultError.InnerHtml = "<span style='color:Green;'>این رزرو برای شما به انجام رسید .</span>";
                DCL.TBTicket Tdcl = new DCL.TBTicket();
                DgvReserves.DataSource = Tdcl.Select(Tdcl.CreateEntity(null, Session["UserId"].ToString(), null));
                DgvReserves.DataBind();
            }
        }
        catch (Exception ex)
        {
            DivDefaultError.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " پیش آمده است .</span>";
        }
    }
}