using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            if (TxtPassword.Text == string.Empty || TxtUsername.Text == string.Empty)
                throw new Exception("عدم پر بودن فیلد های اجباری ");
            if (TxtPassword.Text != TxtConfirmPassword.Text)
                throw new Exception("عدم وجود تشابه بین پسورد و تکرارش ");
            Encoding En = new Encoding();
            DCL.TBMembers dcl = new DCL.TBMembers();
            DML.TBMembers dml = new DML.TBMembers();
            dml.Username = TxtUsername.Text;
            dml.Password = En.EncodePassword(TxtConfirmPassword.Text);
            dml.GoogleEmail = TxtGoogleEmail.Text;
            dml.DisplayName = TxtDisplayName.Text;
            dml.MSNEmail = TxtMSNEmail.Text;
            dml.OtherEmail = TxtOtherEmail.Text;
            dml.YahooEmail = TxtYahooEmail.Text;
            dcl.Insert(dml);
            DivRegisterResPonds.InnerHtml = "<span style='color:Green;'>شما ثبت نام گردیدید .</span>";
            TxtConfirmPassword.Text = TxtDisplayName.Text = TxtGoogleEmail.Text = TxtMSNEmail.Text = TxtOtherEmail.Text = TxtPassword.Text = TxtUsername.Text = TxtYahooEmail.Text = string.Empty;
        }
        catch (Exception ex)
        {
            DivRegisterResPonds.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " روی داده است .</span>";
        }
    }
}