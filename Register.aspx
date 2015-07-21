<%@ Page Title="" Language="C#" MasterPageFile="~/primaryMasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentHolder" Runat="Server">
    <h1>Register</h1>
    <p>
        Use this page to register to the website so you can create posts
    </p>
    <table style="width: 100%;">
        <tr>
            <td>Full Name (The name that will be displayed with your blogs):</td>
            <td>
                <asp:TextBox ID="fullNameTextBox" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="fullNameConfirmationLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Email:</td>
            <td>
                <asp:TextBox ID="emailAddressTextBox" runat="server" TextMode="Email"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="emailAddressConfirmationLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Login ID (User Name):</td>
            <td>
                <asp:TextBox ID="loginIDTextBox" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="loginIDConfirmationLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Password (Leave empty for no password):</td>
            <td>
                <asp:TextBox ID="passwordTextBox" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="passwordConfirmationLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Accept <asp:LinkButton ID="openTCBtn" runat="server" OnClick="openTCBtn_Click">Terms and Conditions</asp:LinkButton>
            </td>
            <td>
                <asp:RadioButton ID="acceptTCBtn" runat="server" Text="Accept" GroupName="TAndCRadioBtns"/>
                <asp:RadioButton ID="declineTCBtn" runat="server" Text="Decline" GroupName="TAndCRadioBtns"/>
            </td>
            <td>          
                <asp:Label ID="TCConfirmationLabel" runat="server"></asp:Label>              
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align:center;"><asp:Button ID="submitBtn" runat="server" Text="Submit" OnClick="submitBtn_Click" /></td>
        </tr>
    </table>
</asp:Content>

