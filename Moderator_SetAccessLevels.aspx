<%@ Page Title="" Language="C#" MasterPageFile="~/primaryMasterPage.master" AutoEventWireup="true" CodeFile="Moderator_SetAccessLevels.aspx.cs" Inherits="Moderator_SetAccessLevels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentHolder" Runat="Server">
    <h1>Moderator "Set User Access Level" Section</h1>
    <br />
    <p>
        When editing user access level, make sure you click save 
    </p>
    <asp:Button ID="saveBtnTop" runat="server" Text="Save" OnClick="saveBtn_Click"/>
    <br />
    <br />
    <asp:Table ID="mainTable" runat="server" CssClass="center">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>LoginID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Access Level</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <br />
    <asp:Button ID="saveBtnBottom" runat="server" Text="Save" OnClick="saveBtn_Click"/>
</asp:Content>

