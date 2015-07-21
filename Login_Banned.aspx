<%@ Page Title="" Language="C#" MasterPageFile="~/primaryMasterPage.master" AutoEventWireup="true" CodeFile="Login_Banned.aspx.cs" Inherits="Login_Banned" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentHolder" Runat="Server">
    <h1>This account is banned</h1>
    <p>
        This account is banned due to not following the Terms and Conditions. If you feel you have been incorrectly banned, please 
        <asp:LinkButton ID="contactBtn" runat="server" OnClick="contactBtn_Click">Contact Us</asp:LinkButton>. Note, we reserve the rights
        to ban whoever we please with or without a valid reason.
    </p>
</asp:Content>

