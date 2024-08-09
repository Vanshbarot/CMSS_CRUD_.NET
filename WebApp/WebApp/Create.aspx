<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="WebApp.Create" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div id="head" style="height:104px; border-bottom:solid;border-bottom-color:grey;">
             <h1 style="color:brown;position:fixed;top:24px;left:40px;">CMSS USER LOGIN</h1>
             <asp:Image id="imageid" runat="server" ImageUrl="~/Images/cmsslogo.png" style="position:fixed;right:40px;top:10px;height:100px;"/>
         </div>
         <div>
            <asp:Panel id="panelid" runat="server" style="position:fixed; left:50%; top:60%; transform:translate(-50%, -50%); border:1px solid #808080; border-radius:8px; background-color:#fff; padding:20px; width:500px;">
                <h2 style="margin:20px; font-size:24px; color:#333; text-align:center;">Please enter your Credentials</h2>
                <asp:Label id="ValidationLabel" runat="server" ></asp:Label>
                <table style="width:100%; border-collapse:collapse;">
                    <tr>
                        <td style="padding:10px; font-size:larger;">Name</td>
                        <td><asp:TextBox ID="Name" runat="server" style="width:90%; padding:10px; border:1px solid #ddd; border-radius:4px;"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="padding:10px; font-size:larger;">Email</td>
                        <td><asp:TextBox ID="Email" TextMode="Email" runat="server" style="width:90%; padding:10px; border:1px solid #ddd; border-radius:4px;"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="padding:10px; font-size:larger;">Gender</td>
                        <td>
                            <asp:RadioButton ID="MaleRadioBtn" Text="Male" GroupName="Gender" runat="server"/>
                            <asp:RadioButton ID="FemaleRadioBtn" Text="Female" GroupName="Gender" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding:10px; font-size:larger;">Qualification</td>
                        <td>
                            <asp:RadioButton ID="Graduate" Text="Graduate" GroupName="Qualification" runat="server"/>
                            <asp:RadioButton ID="Postgraduate" Text="Postgraduate" GroupName="Qualification" runat="server"/>
                            <asp:RadioButton ID="Doctrate" Text="Doctrate" GroupName="Qualification" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding:10px; font-size:larger;">Password</td>
                        <td>
                            <asp:TextBox ID="Password" TextMode="Password" OnTextChanged="Password_TextChanged" runat="server" style="width:90%; padding:10px; border:1px solid #ddd; border-radius:4px;"></asp:TextBox>
                            <asp:Label ID="PasswordValidationLabel" runat="server" Text="" style="margin-top:10px;"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding:10px; font-size:larger;">Confirm Password</td>
                        <td>
                            <asp:TextBox ID="ConfirmPass" OnTextChanged="Confirm_Password" runat="server" style="width:90%; padding:10px; border:1px solid #ddd; border-radius:4px;"></asp:TextBox>
                            <asp:Label ID="ConfirmValidationLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding:20px; text-align:center;">
                            <asp:Button ID="CreateBtn" Text="Submit" runat="server" OnClick="CreateBtn_Click" Style="background-color: brown; color: white; padding: 10px 30px; border-radius: 4px; font-size: 16px; width: 100%;" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
