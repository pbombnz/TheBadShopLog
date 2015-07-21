<%@ Page Title="" Language="C#" MasterPageFile="~/primaryMasterPage.master" AutoEventWireup="true" CodeFile="Catogory_Clothes.aspx.cs" Inherits="Catogory_Clothes"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentHolder" Runat="Server">
    <h1>Clothing Stores</h1>
    <br />
    <p>
        Please select a clothing store that you would like to read or post experiences from
    </p>
    <br />
    <table class="center">
        <tr>
            <td>
                <asp:Button ID="farmersBtn" runat="server" Text="Farmers" OnClick="farmersBtn_Click" />
            </td>
            <td>
                <asp:Button ID="kmartBtn" runat="server" Text="K-Mart" OnClick="kmartBtn_Click" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

