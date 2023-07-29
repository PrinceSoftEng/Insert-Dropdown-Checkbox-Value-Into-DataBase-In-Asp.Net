<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CS.aspx.cs" Inherits="Insert_Dropdown_Checkbox_Value_Into_DataBase_In_Asp.Net.CS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Select UserName:</h2>
            <asp:DropDownList ID="ddlUserName" runat="server">
            </asp:DropDownList>
            <br />
            <h2>Select Roles:</h2>
            <asp:CheckBoxList ID="chkRoles" runat="server">
            </asp:CheckBoxList>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <br />
            <hr />
            <asp:GridView ID="gvGet" runat="server" AutoGenerateColumns="true">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
