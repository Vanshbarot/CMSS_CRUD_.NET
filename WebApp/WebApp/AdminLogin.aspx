<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="WebApp.App_Start.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="head" style="height:104px; border-bottom:solid;border-bottom-color:grey;">
            <h1 style="color:brown;position:fixed;top:24px;left:40px;">CMSS ADMIN LOGIN</h1>
            <asp:Image id="imageid" runat="server" ImageUrl="~/Images/cmsslogo.png" style="position:fixed;right:40px;top:10px;height:100px;"/>
        </div>
        <div>
            <asp:Panel id="panelid" runat="server" style="position:fixed; left:50%; top:50%; transform:translate(-50%, -50%); border:1px solid #808080; border-radius:8px; background-color:#fff; padding:20px; width:500px;">
                <h2 style="margin:20px; font-size:24px; color:#333; text-align:center;">Login</h2>
                <asp:Label ID="ValidationLabel" runat="server"></asp:Label>
                <table id="UserTable" style="width:100%; border-collapse:collapse;">
                    <tr>
                        <td style="padding:10px; font-size:larger;">Email</td>
                        <td><asp:TextBox ID="Email" TextMode="Email" runat="server" style="width:90%; margin:10px; padding:10px; border:1px solid #ddd; border-radius:4px;"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="padding:10px; font-size:larger">Password</td>
                        <td><asp:TextBox ID="Password" TextMode="Password" runat="server" style="width:90%; margin:10px; padding:10px; border:1px solid #ddd; border-radius:4px;"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding:30px; text-align:center;">
                        <asp:Button ID="SubmitBtn" runat="server" OnClick="SubmitBtn_Click" Text="Submit" Style="background-color: brown; color: white; padding: 10px 30px; border-radius: 4px; font-size: 16px; width: 100%;" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
