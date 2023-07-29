using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace Insert_Dropdown_Checkbox_Value_Into_DataBase_In_Asp.Net
{
    public class clsMasterUsertoRole
    {
        public DataTable BindGrid()
        {
            clsBalUsertoRole objBalUTR = new clsBalUsertoRole();
            return objBalUTR.BindGrid();
        }
        public DataTable BindUserDropdown()
        {
            clsBalUsertoRole objBalUTR= new clsBalUsertoRole();
            return objBalUTR.BindUserDropdown();
        }

        public DataTable BindRolesCheckbox()
        {
            clsBalUsertoRole objBalUTR = new clsBalUsertoRole();
            return objBalUTR.BindRolesCheckbox();
        }        
        public Int32 InsertUserToRole(clsDalUsertoRole objDalUTR)
        {
            clsBalUsertoRole objBalUTR = new clsBalUsertoRole();
            return  objBalUTR.InsertUserToRole(objDalUTR);
        }
    }
}