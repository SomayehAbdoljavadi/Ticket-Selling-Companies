using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DCL.TBMembers dcl = new DCL.TBMembers();
            if (Request.QueryString["DeleteId"] != null)
            {
                dcl.Delete(Request.QueryString["DeleteId"].ToString());
            }
            DataTable Dt = dcl.SelectAll();
            DgvMembers.DataSource = Dt;
            DgvMembers.DataBind();
        }
    }
}