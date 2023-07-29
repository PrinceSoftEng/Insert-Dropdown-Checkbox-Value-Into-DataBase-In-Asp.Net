using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Insert_Dropdown_Checkbox_Value_Into_DataBase_In_Asp.Net
{
    public class clsBalUsertoRole
    {
        private string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public DataTable BindUserDropdown()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Select UserId,UserName from UserRegTable", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public DataTable BindRolesCheckbox()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Select roleId,roleName from User_tblRole", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public DataTable BindGrid()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("select * from tblUserToRole", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public Int32 InsertUserToRole(clsDalUsertoRole objDalUTR)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Insert Into tblUserToRole (UserId,roleId) values (@UserId,@roleId)", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserId", objDalUTR.userId);
                    cmd.Parameters.AddWithValue("@roleId",objDalUTR.roleId);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    return i;                    
                }
            }
        }
    }
}