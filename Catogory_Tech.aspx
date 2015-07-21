<%@ Page Title="" Language="C#" MasterPageFile="~/primaryMasterPage.master" AutoEventWireup="true" CodeFile="Catogory_Tech.aspx.cs" Inherits="Catogory_Tech" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentHolder" Runat="Server">
    <h1>Tech Stores</h1>
    <br />
    <p>
        Please select a technical store that you would like to read or post experiences from...
    </p>
    <br />
    <table class="center">
        <tr>
            <td>
                <asp:Button ID="dseBtn" runat="server" Text="Dick Smith Electronics" OnClick="dseBtn_Click" />
            </td>
            <td>
                <asp:Button ID="harveyNormanBtn" runat="server" Text="Harvey Norman" OnClick="harveyNormanBtn_Click" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

