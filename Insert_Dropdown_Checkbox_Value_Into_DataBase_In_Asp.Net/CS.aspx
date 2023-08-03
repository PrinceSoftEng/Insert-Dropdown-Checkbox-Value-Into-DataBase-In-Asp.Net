<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CS.aspx.cs" Inherits="Insert_Dropdown_Checkbox_Value_Into_DataBase_In_Asp.Net.CS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />    
</head>
<body>
    <form id="form1" runat="server">
        <div>            
            <b><asp:Label ID ="lblUsers" runat="server" Text="Select Users:"></asp:Label></b>
            <asp:DropDownList ID="ddlUsers" runat="server" DataTextField="UserName" DataValueField="UserId" Width="12%"></asp:DropDownList>
            <script>
                $('#<%=ddlUsers.ClientID%>').chosen();
            </script>
            <br />
            <br />
            <b><asp:Label ID ="lblRoles" runat="server" Text="Select Roles:"></asp:Label></b>
            <asp:RadioButtonList ID ="rblRoles" runat="server" DataTextField="roleName" DataValueField="roleId"></asp:RadioButtonList>
            
            <br />
            <br />
            <asp:GridView ID ="gvUTR" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="UserId" HeaderText="User Id" />
                    <asp:BoundField DataField="roleId" HeaderText="Role Id" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
    </form>
</body>
</html>
