<%@ Page Title="" Language="C#" MasterPageFile="~/primaryMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="main.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentHolder" Runat="Server">
    
    <h1>The Bad Shop Blog</h1>
    <p>
        This website contains bad experiences and negative feedback for various shopping retail stores.<br />
        Anyone can read and write entries. Select one of the categories below.
    </p>
    <br />
    <table class="center">
        <tr>
            <th colspan="2">Catogories</th>
        </tr>
        <tr>
            <td>Clothing Stores - Any retail store that sells any sort of clothing (eg. Farmers and Just Jeans etc,)</td>
            <td>
                <asp:Button ID="catogoryClothesBtn" runat="server" Text="Got to Clothing Section" OnClick="catogoryClothesBtn_Click" />
            </td>
        </tr>
        <tr>
            <td>Technical Stores - All technological companies will be catorgrised (eg. Dick Smith Electronics and Noel Leemings)</td>
            <td>
                <asp:Button ID="catogoryTechBtn" runat="server" Text="Go to Techical Section" OnClick="catogoryTechBtn_Click" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

