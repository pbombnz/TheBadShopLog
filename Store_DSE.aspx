<%@ Page Title="" Language="C#" MasterPageFile="~/primaryMasterPage.master" AutoEventWireup="true" CodeFile="Store_DSE.aspx.cs" Inherits="Store_DSE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentHolder" Runat="Server">
    <h1>Dick Smith Electronics</h1>
    <br />
    <asp:Table ID="blogListTable" runat="server" CssClass="center"></asp:Table>
    <br />
    <asp:Button ID="showNextFiveBlogsBtn" runat="server" Text="Show Next 5 Blogs" style="margin:20px;" OnClick="showNextFiveBlogsBtn_Click" />
    <asp:Button ID="addBlogBtn" runat="server" Text="Add Blog Experience" style="margin:20px;" OnClick="addBlogBtn_Click" />
    <br />
    <br />
    <asp:Panel ID="addBlogSection" runat="server" Visible="False">
        <table class="center">
            <tr>
                <td>
                    <asp:TextBox ID="newBlogTextBox" runat="server" Height="200px" MaxLength="1024" TextMode="MultiLine" Width="100%" OnTextChanged="newBlogTextBox_TextChanged" AutoPostBack="True"></asp:TextBox>
                    <asp:Label ID="charLeftLabel" runat="server" Text="Characters Left: 1024" style="float:right;"></asp:Label>
                    <asp:Button ID="updateTextBoxBtn" runat="server" Text="Click Here after Every Modification of the above Text Box" Width="70%" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="sendBlogBtn" runat="server" Text="Post Blog" OnClick="sendBlogBtn_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

