<%@ Page Title="" Language="C#" MasterPageFile="~/primaryMasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentHolder" Runat="Server">
    <h1>Contact Us</h1>
    <br />
    <p>
        Fill the forms below and click the Send button to send an email to the moderators.
    </p>
    <table>
        <tr>
            <td>First Name:</td>
            <td>
                <asp:TextBox ID="firstNameTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td>
                <asp:TextBox ID="lastNameTestBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Your Contact Email Address:</td>
            <td>
                <asp:TextBox ID="emailAddressTextBox" runat="server" TextMode="Email"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Message:</td>
            <td>
                <asp:TextBox ID="messageTextBox" runat="server" CssClass="auto-style1" Height="200px" TextMode="MultiLine" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:center;"><asp:Label ID="sendConfirmationLabel" runat="server" Text=""></asp:Label></td>
            <td style="text-align:center;">
                <asp:Button ID="sendBtn" runat="server" Text="Send" Width="74px" OnClick="sendBtn_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

