<%@ Page Title="" Language="C#" MasterPageFile="~/primaryMasterPage.master" AutoEventWireup="true" CodeFile="UserPanel.aspx.cs" Inherits="UserPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentHolder" Runat="Server">
    <h1><asp:Label ID="contentTitle" runat="server"></asp:Label>'s User Panel</h1>
    <br/>
    <p>
        This shows "Read-Only" information on you and some interactions that the user may perform depending on their access level.
    </p>
    <br/>
    <h2>User Information</h2>
    <br/>
    <table class="center">
        <tr>
            <th>Name:</th>
            <td>
                <asp:Label ID="nameLabel" runat="server" ForeColor="Black"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>Email Address:</th>
            <td>
                <asp:Label ID="emailLabel" runat="server" ForeColor="Black"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>LoginID:</th>
            <td>
                <asp:Label ID="loginIDLabel" runat="server" ForeColor="Black"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>Password:</th>
            <td>
                <asp:Label ID="passwordLabel" runat="server" ForeColor="Black"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>Access Level:</th>
            <td>
                <asp:Label ID="accessLevelLabel" runat="server" ForeColor="Black"></asp:Label>
            </td>
        </tr>
    </table>
    <br/>
    <asp:Panel ID="moderatorSection" runat="server" Visible="false">
        <h2>User Interaction</h2>
        <br />
        <table class="center">
            <tr>
                <td style="text-align:center;"><asp:Button ID="setMembersAccessLevelBtn" runat="server" Text="Set Members Access Level" OnClick="setMembersAccessLevelBtn_Click"/></td>
                <td style="text-align:center;"><asp:Button ID="moderateEntryBtn" runat="server" Text="Moderate Entry For Blogs" OnClick="moderateEntryBtn_Click" /></td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

