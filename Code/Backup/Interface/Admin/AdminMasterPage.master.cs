using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_AdminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            LblUsername.Text = Session["DisplayName"].ToString();
            if (Session["Username"].ToString().ToLower() != "admin")
            {
                DivAdminMenus.Visible = false;
                Response.Redirect("../default.aspx");
            }
            DivAdminMenus.Visible = true;
            Login.Visible = false;
            Welcome.Visible = true;
            DivChangeProfile.Visible = true;
        }
        else
        {
            Session.Clear();
            DivAdminMenus.Visible = false;
            DivChangeProfile.Visible = false;
            Response.Redirect("../default.aspx");
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
            DML.TBMembers dml = new DML.TBMembers();
            dml.Username = TxtUsername.Text;
            dml.Password = En.EncodePassword(TxtPassword.Text);
            DataTable Dt = dcl.Select(dml);
            if (Dt.Rows.Count > 0)
            {
                Login.Visible = false;
                Welcome.Visible = true;
                LblUsername.Text = Dt.Rows[0]["DisplayName"].ToString();
                Session.Add("UserId", Dt.Rows[0]["ID"].ToString());
                Session.Add("Username", dml.Username);
                Session.Add("DisplayName", Dt.Rows[0]["DisplayName"].ToString());
                DivChangeProfile.Visible = true;
                if (Session["Username"].ToString().ToLower() != "admin")
                {
                    Response.Redirect("../default.aspx");
                }
            }
            else
            {
                Session.Clear();
                Login.Visible = true;
                Welcome.Visible = false; 
                DivChangeProfile.Visible = false;
                LoginRespond.InnerHtml = "<span style='color:Red;'>نام کاربری یا رمز عبور اشتباه می باشد .<span>";
            }
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
        DivChangeProfile.Visible = false;
        Response.Redirect("../default.aspx");
    }
}
