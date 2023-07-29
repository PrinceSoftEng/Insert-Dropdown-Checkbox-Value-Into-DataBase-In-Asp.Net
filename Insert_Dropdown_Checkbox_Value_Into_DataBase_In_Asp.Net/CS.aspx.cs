using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insert_Dropdown_Checkbox_Value_Into_DataBase_In_Asp.Net
{
    public partial class CS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindDropdown();
                this.BindCheckBox();
                this.BindGrid();
            }
        }       

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            clsMasterUsertoRole objMastUTR = new clsMasterUsertoRole();
            clsDalUsertoRole objDalUTR= new clsDalUsertoRole();
            objDalUTR.userId = Convert.ToInt32(ddlUserName.SelectedValue);
            objDalUTR.roleId = Convert.ToInt32(chkRoles.SelectedValue);
            int retvalue = objMastUTR.InsertUserToRole(objDalUTR);
            if (retvalue > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Data Inserted Successfully');", true);
                this.BindGrid();
            }
            else 
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Data Inserted Failed');", true);
            }            
        }

        private void BindGrid()
        {
            clsMasterUsertoRole objMastUTR = new clsMasterUsertoRole();
            DataTable dt = objMastUTR.BindGrid();
            if (dt.Rows.Count > 0)
            {
                gvGet.DataSource = dt;
                gvGet.DataBind();   
            }           
        }

        private void BindDropdown()
        {
            clsMasterUsertoRole objMastUTR = new clsMasterUsertoRole();
            DataTable dt = objMastUTR.BindUserDropdown();
            if (dt.Rows.Count > 0)
            {
                ddlUserName.DataSource = dt;
                ddlUserName.DataTextField = "UserName";
                ddlUserName.DataValueField = "UserId";
                ddlUserName.DataBind();
            }            
            ddlUserName.Items.Insert(0, new ListItem("--Select Name--", "0"));
        }

        private void BindCheckBox()
        {
            clsMasterUsertoRole objMastUTR = new clsMasterUsertoRole();
            DataTable dt = objMastUTR.BindRolesCheckbox();
            if (dt.Rows.Count > 0)
            {
                chkRoles.DataSource =dt;
                chkRoles.DataTextField = "roleName";
                chkRoles.DataValueField = "roleId";
                chkRoles.DataBind();
            }            
        }
    }
}