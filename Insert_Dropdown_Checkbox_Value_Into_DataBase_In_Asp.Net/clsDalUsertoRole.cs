using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insert_Dropdown_Checkbox_Value_Into_DataBase_In_Asp.Net
{
    public class clsDalUsertoRole
    {
        private int str_RoleId;
        private string str_RoleName;
        private int str_UserId;
        private string str_UserName;

        public int roleId { get { return str_RoleId; }set { str_RoleId = value; } }
        public string roleName { get { return str_RoleName; }set { str_RoleName = value; } }
        public int userId { get { return str_UserId; }set { str_UserId = value; } }
        public string userName { get { return str_UserName; }set{ str_UserName = value; } }
    }
}