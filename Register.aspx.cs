using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatApp
{
    public partial class Register : System.Web.UI.Page
    {
        ConnectionClass ConnC = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_ServerClick(object sender, EventArgs e)
        {
            string Query = "insert into tbl_Users(UserName,Password)Values('" + txtUserName.Value + "','" + txtPassword.Value + "')";
            string ExistQ = "select * from tbl_Users where UserName='" + txtUserName.Value + "'";
            if (!ConnC.IsExist(ExistQ))
            {
                if (ConnC.ExecuteQuery(Query))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Message", "alert('Congratulations!! You have successfully registered..');", true);
                    Session["UserName"] = txtUserName.Value;
                    Response.Redirect("Chat.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Message", "alert('UserName is already Exists!! Please Try Different User name..');", true);
            }
        }
    }

}
