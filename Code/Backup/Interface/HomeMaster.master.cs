using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HomeMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            LblUsername.Text = Session["DisplayName"].ToString();
            if (Session["Username"].ToString().ToLower() == "admin")
                DivAdminMenus.Visible = true;
            Login.Visible = false;
            Welcome.Visible = true;
            DivChangeProfile.Visible = true;
        }
        else
        {
            Session.Clear();
            Login.Visible = true;
            Welcome.Visible = false;
            DivAdminMenus.Visible = false;
            DivChangeProfile.Visible = false;
        }
        if (!IsPostBack)
        {

        }
    }
    protected void BtnEnter_Click(object sender, EventArgs e)
    {
        try
        {
            if (TxtPassword.Text == string.Empty || TxtUsername.Text == string.Empty)
                throw new Exception("عدم پر بودن فیلد های اجباری ");
            Encoding En = new Encoding();
            DCL.TBMembers dcl = new DCL.TBMembers();
            DataTable Dt = dcl.Select(dcl.CreateEntity(null,TxtUsername.Text,En.EncodePassword(TxtPassword.Text),null,null,null,null,null));
            if (Dt.Rows.Count > 0)
            {
                Login.Visible = false;
                Welcome.Visible = true;
                LblUsername.Text = Dt.Rows[0]["DisplayName"].ToString();
                Session.Add("UserID", Dt.Rows[0]["ID"].ToString());
                Session.Add("Username", dcl.dml.Username);
                Session.Add("DisplayName", Dt.Rows[0]["DisplayName"].ToString());
                DivChangeProfile.Visible = true;
            }
            else
            {
                Session.Clear();
                Login.Visible = true;
                Welcome.Visible = false;
                DivChangeProfile.Visible = false;
                throw new Exception("نام کاربری یا رمز عبور اشتباه می باشد .");
            }
            Response.Redirect("default.aspx");
        }
        catch (Exception ex)
        {
            LoginRespond.InnerHtml = "<span style='color:Red;'>خطای : " + ex.Message + " روی داده است .<span>";
        }
        if (Session["Username"] != null)
            if (Session["Username"].ToString().ToLower() == "admin")
                DivAdminMenus.Visible = true;
    }
    protected void BtnExit_Click(object sender, EventArgs e)
    {
        Session.Clear();
        DivAdminMenus.Visible = false;
        Login.Visible = true;
        Welcome.Visible = false;
        DivChangeProfile.Visible = false;
        Response.Redirect("default.aspx");
    }
}
