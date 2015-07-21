<%@ Page Title="" Language="C#" MasterPageFile="~/primaryMasterPage.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentHolder" Runat="Server">
    <h1>About</h1>
    <br/>
    <p>
        This site was created in 2014 to helps customer know about a store before they go in. This site allows users (that are registered) to post
        their bad experiences on to this site for other users to see. The site is moderated so any biased or rude experiences are removed. The site
        and the experiences can be viewed by anyone so registration is not required if your are just looking. 
    </p>
    <p>
        If you would like to contact the moderator for any queries, please go to the 
        <asp:LinkButton ID="contactLinkBtn" runat="server" OnClick="contactLinkBtn_Click">Contact Page</asp:LinkButton> 
        which has a form to contact the team directly (via email).
    </p>
    <br/>
</asp:Content>

