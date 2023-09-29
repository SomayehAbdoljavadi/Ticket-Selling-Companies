using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ChangeProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    DCL.TBMembers dcl = new DCL.TBMembers();
                    DML.TBMembers dml = new DML.TBMembers();
                    dml.Username = Session["Username"].ToString();
                    DataTable Dt = dcl.Select(dml);
                    TxtUsername.Text = Session["Username"].ToString();
                    TxtDisplayName.Text = Dt.Rows[0]["DisplayName"].ToString();
                    TxtGoogleEmail.Text = Dt.Rows[0]["GoogleEmail"].ToString();
                    TxtMSNEmail.Text = Dt.Rows[0]["MSNEmail"].ToString();
                    TxtOtherEmail.Text = Dt.Rows[0]["OtherEmail"].ToString();
                    TxtYahooEmail.Text = Dt.Rows[0]["YahooEmail"].ToString();
                }
                else
                {
                    Response.Redirect("default.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            DivRegisterResPonds.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " پیش آمده است .</span>";
        }
    }
    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            String Password = "";
            int ID = 0;
            if (TxtPassword.Text == string.Empty || TxtUsername.Text == string.Empty)
                throw new Exception("عدم پر بودن فیلد های اجباری ");
            if (TxtPassword.Text != TxtConfirmPassword.Text)
                throw new Exception("عدم وجود تشابه بین پسورد و تکرارش ");
            Encoding En = new Encoding();
            DCL.TBMembers dcl = new DCL.TBMembers();
            DML.TBMembers dml = new DML.TBMembers();
            dml.Username = TxtUsername.Text;
            DataTable Dt = dcl.Select(dml);
            if (Dt.Rows.Count > 0)
            {
                ID = int.Parse(Dt.Rows[0][0].ToString());
                Password = Dt.Rows[0]["Password"].ToString();
            }
            else
            {
                Session.Clear();
                Response.Redirect("../default.aspx");
            }
            if (Password != En.EncodePassword(TxtLastPassword.Text))
                throw new Exception("عدم تطابق رمز قبلی و آنچه در سیستم موجود می باشد ");
            dml.ID = ID;
            dml.Username = TxtUsername.Text;
            dml.DisplayName = TxtDisplayName.Text;
            dml.GoogleEmail = TxtGoogleEmail.Text;
            dml.MSNEmail = TxtMSNEmail.Text;
            dml.OtherEmail = TxtOtherEmail.Text;
            dml.Password = En.EncodePassword(TxtPassword.Text);
            dml.YahooEmail = TxtYahooEmail.Text;
            dcl.Update(dml);
            DivRegisterResPonds.InnerHtml = "<span style='color:Green;'>مشخصات شما با صحت به روز رسانی گردید .</span>";
        }
        catch (Exception ex)
        {
            DivRegisterResPonds.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " پیش آمده است .</span>";
        }
    }
}