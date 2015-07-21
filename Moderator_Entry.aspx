<%@ Page Title="" Language="C#" MasterPageFile="~/primaryMasterPage.master" AutoEventWireup="true" CodeFile="Moderator_Entry.aspx.cs" Inherits="Moderator_Entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentHolder" Runat="Server">
    <h1>Moderator's Entry</h1>
    <p>
        This is the page is where you (the moderator) can accept or decline blog entries.
    </p>
    <table>
        <tr>
            <td colspan="4">
                <asp:Label ID="blogLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align:center;">
                <asp:Label ID="blogStatusLabel" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">
                <asp:Button ID="prevBtn" runat="server" Text="Previous" OnClick="prevBtn_Click" />
            </td>
            <td style="text-align:center;">
                <asp:Button ID="acceptBtn" runat="server" Text="Accept" OnClick="acceptBtn_Click" />
            </td>
            <td style="text-align:center;">
                <asp:Button ID="rejectBtn" runat="server" Text="Reject" OnClick="rejectBtn_Click" />
            </td>
            <td style="text-align:center;">
                <asp:Button ID="nextBtn" runat="server" Text="Next" OnClick="nextBtn_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

