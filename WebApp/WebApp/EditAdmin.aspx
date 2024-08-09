<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditAdmin.aspx.cs" Inherits="WebApp.EditAdmin" Debug="true" %>

<!DOCTYPE html>
<style>
    .table-td{
        width:200px;
    }
</style>  
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Edit</title>
</head>   
<body>
    <form id="form1" runat="server">
        <div id="head" style="height:104px; border-bottom:solid;border-bottom-color:grey;">
            <h1 style="color:brown;position:fixed;top:24px;left:40px;">CMSS ADMIN EDIT</h1>
            <asp:Image id="imageid" runat="server" ImageUrl="~/Images/cmsslogo.png" style="position:fixed;right:40px;top:10px;height:100px;"/>
        </div>
        <div>
            <center>
              <div>
                <asp:TextBox id="SearchBox" TextMode="Email" placeholder="Search email" runat="server" style="width: 300px; height: 40px;margin:10px 5px 40px 5px; padding: 10px; border: 1px solid #ccc; border-radius: 20px; font-size: 16px; outline: none; box-sizing: border-box; transition: border-color 0.3s ease;" onfocus="this.style.borderColor='#007bff';" onblur="this.style.borderColor='#ccc';" />
                <asp:Button id="SearchBtn" runat="server" OnClick="SearchBtn_Click" Text="Search" style="height: 40px; padding: 0 20px; border: none; border-radius: 20px; background-color:brown; color: white; font-size: 16px; cursor: pointer; transition: background-color 0.3s ease;" />
                <asp:Label ID="Label1" runat="server" style="margin-top: 10px; color: red; font-size: 14px;" /> 
              </div>

                <!-- User Information View Panel -->
                <asp:Panel ID="UserInfoView" runat="server" style="position:fixed; left:50%; top:60%; transform:translate(-50%, -50%); border:1px solid #808080; border-radius:8px; background-color:#fff; padding:20px; width:500px;" >
                <h2 style="margin:20px; font-size:24px; color:#333; text-align:center;">Edit/Update User Details</h2>
                    <table style="width:100%; border-collapse:collapse;">
                        <tr>
                            <td style="padding:10px; font-size:larger;">Email</td>
                            <td style="padding:10px; font-size:larger;"><asp:Label ID="EmailLabel" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="padding:10px; font-size:larger;">Gender</td>
                            <td style="padding:10px; font-size:larger;"><asp:Label ID="GenderLabel" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="padding:10px; font-size:larger;">Name</td>
                            <td style="padding:10px; font-size:larger;"><asp:Label ID="NameLabel" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="padding:10px; font-size:larger;">Password</td>
                            <td style="padding:10px; font-size:larger;"><asp:Label ID="PasswordLabel" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="padding:10px; font-size:larger;">Qualification</td>
                            <td style="padding:10px; font-size:larger;"><asp:Label ID="QualificationLabel" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding:20px; text-align:center;">
                                <asp:Button ID="DeleteBtn" Text="DELETE" OnClick="DeleteBtn_Click" runat="server" OnClientClick="return confirm('Are you sure you want to delete?')" style="background-color: #d9534f; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px; width: 45%; margin-right: 10px;" />
                                <asp:Button ID="EditBtn" Text="EDIT" OnClick="EditBtn_Click" runat="server" style="background-color: #5bc0de; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px; width: 45%;" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <!-- User Information Edit Panel -->
                <asp:Panel ID="UserInfoEdit" runat="server" style="display:none; position:fixed; left:50%; top:60%; transform:translate(-50%, -50%); border:1px solid #808080; border-radius:8px; background-color:#fff; padding:20px; width:500px;">
                <h2 style="margin:20px; font-size:24px; color:#333; text-align:center;">Edit/Update User Details</h2>
                    <table style="width:100%; border-collapse:collapse;">
                        <tr>
                            <td style="padding:10px; font-size:larger;">Email</td>
                            <td style="padding:10px; font-size:larger;"><asp:Label ID="EmailEdit" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="padding:10px; font-size:larger;">Gender</td>
                            <td style="padding:10px; font-size:larger;"><asp:Label ID="GenderEdit" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="padding:10px; font-size:larger;">Name</td>
                            <td style="padding:10px; font-size:larger;"><asp:TextBox ID="NameEdit" runat="server" style="width:90%; padding:10px; border:1px solid #ddd; border-radius:4px;"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="padding:10px; font-size:larger;">Password</td>
                            <td style="padding:10px; font-size:larger;"><asp:TextBox ID="PasswordEdit" runat="server" style="width:90%; padding:10px; border:1px solid #ddd; border-radius:4px;"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="padding:10px; font-size:larger;">Qualification</td>
                            <td style="padding:10px; font-size:larger;">
                                <asp:RadioButton ID="Graduate" Text="Graduate" GroupName="Qualification" runat="server"/>
                                <asp:RadioButton ID="Postgraduate" Text="Postgraduate" GroupName="Qualification" runat="server"/>
                                <asp:RadioButton ID="Doctrate" Text="Doctrate" GroupName="Qualification" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding:20px; text-align:center;">
                                <asp:Button id="SubmitOnEdit" Text="SUBMIT" OnClick="SubmitOnEdit_Click" runat="server" style="background-color: #5bc0de; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px; width: 40%;" />
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="PasswordValidationLabel" runat="server" style="display:block; margin-top:10px;"></asp:Label>
                </asp:Panel>
                <asp:Label id="ValidationLabel" runat="server" style="display:block; text-align:center; margin-top:20px;"></asp:Label>    
            </center>
        </div>
    </form>
</body>

</html>
