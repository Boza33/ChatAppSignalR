using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatApp
{
    public partial class Login : System.Web.UI.Page
    {

        ConnectionClass ConnC = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            string Query = "select * from tbl_Users where UserName='" + txtUserName.Value + "' and Password='" + txtPassword.Value + "'";
            if (ConnC.IsExist(Query))
            {
                string UserName = ConnC.GetColumnVal(Query, "UserName");
                Session["UserName"] = UserName;
                Response.Redirect("Chat.aspx");
            }
            else
                txtUserName.Value = "Invalid UserName or Password!!";
        }
    }
}