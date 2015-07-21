<%@ Page Title="" Language="C#" MasterPageFile="~/primaryMasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentHolder" Runat="Server">
    <h1>Login</h1>
    <p>
        Login with your LoginID and password (if applicable) or register
    </p>
    <table class="center">
        <tr>
            <th colspan="2">Login</th>
            <th>Register</th>
        </tr>
        <tr>
            <td>LoginID:</td>
            <td>
                <asp:TextBox ID="loginIDTextBox" runat="server"></asp:TextBox>
            </td>
            <td rowspan="3" style="text-align:center;">
                <asp:Button ID="registerBtn" runat="server" Text="Register" OnClick="registerBtn_Click" />
            </td>
        </tr>
        <tr>
            <td>Password:</td>
            <td>
                <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;">
                <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click" />
                <br />
                <br />
                <asp:Label ID="loginConfirmationLabel" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

