using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insert_Dropdown_Checkbox_Value_Into_DataBase_In_Asp.Net
{
    public partial class CS : System.Web.UI.Page
    {
        clsMasterUsertoRole objMastUTR = new clsMasterUsertoRole();
        
        private string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindUserDropDownList();
                this.BindRolesCheckBoxList();
                this.BindGridViewUTR();
            }
        }

        private void BindUserDropDownList()
        {
            clsMasterUsertoRole objMastUTR = new clsMasterUsertoRole();
            DataTable dt = objMastUTR.BindUserDropdown();
            if (dt.Rows.Count > 0)
            {
                ddlUsers.DataSource = dt;
                ddlUsers.DataBind();
            }            
            ddlUsers.Items.Insert(0, new ListItem("--Select User--", "0"));
        }

        private void BindRolesCheckBoxList()
        {
            clsMasterUsertoRole objMastUTR = new clsMasterUsertoRole();
            DataTable dt =objMastUTR.BindRolesCheckbox();
            if (dt.Rows.Count > 0)
            {
                rblRoles.DataSource = dt;
                rblRoles.DataBind();
            }            
        }

        private void BindGridViewUTR()
        {
            clsMasterUsertoRole objMastUTR=new clsMasterUsertoRole();
            DataTable dt = objMastUTR.BindGrid();
            if (dt.Rows.Count > 0)
            {
                gvUTR.DataSource = dt;
                gvUTR.DataBind();
            }
        }

        private bool CheckIfMappingExists(int userId)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Select Count(*) from tblUserToRole where UserId=@UserId", con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        
        private void UpdateUserToRoleMapping(int roleId, int userId)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Update tblUserToRole set roleId=@roleId where UserId=@UserId", con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@roleId", roleId);                  
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        private void InsertUserToRoleMapping(int userId, int roleId)
        {
            clsMasterUsertoRole objMastUTR=new clsMasterUsertoRole();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Insert into tblUserToRole(UserId,roleId) values(@UserId,@roleId) ", con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@roleId", roleId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int selectedUserId = Convert.ToInt32(ddlUsers.SelectedValue);
            int selectedRoleId = Convert.ToInt32(rblRoles.SelectedValue);
            bool existingRecord = CheckIfMappingExists(selectedUserId);
            if (existingRecord)
            {
                UpdateUserToRoleMapping(selectedRoleId, selectedUserId);
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Data Updating SuccessFully..!')", true);                
            }            
            else
            {
                foreach (ListItem roleItem in rblRoles.Items)
                {
                    if (roleItem.Selected)
                    {
                        int roleId = Convert.ToInt32(roleItem.Value);
                        InsertUserToRoleMapping(selectedUserId, roleId);
                        ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Data Inserted Successfully..!')", true);
                    }
                }
            }            
            ddlUsers.ClearSelection();
            rblRoles.ClearSelection();
            this.BindGridViewUTR();
        }
    }
}