<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:Repeater runat="server" ID="showAllStilArt">
        <HeaderTemplate>
            <h2>Stilart oversigt</h2>
            <ul>
        </HeaderTemplate>

        <ItemTemplate>
            <li><a href="Stilart.aspx?stilartId=<%# Eval("stilartId") %>"><%# Eval("stilartNavn") %></a></li>
        </ItemTemplate>

        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater runat="server" ID="showAllTeams" OnItemDataBound="showAllTeams_ItemDataBound">
        <HeaderTemplate>
            <h2>Viser hold</h2>
            <table class="table">
                <tr>
                    <td>Holdnavn</td>
                    <td>Stilart</td>
                    <td>Niveau</td>
                    <td>Alder</td>
                    <td>Instruktor</td>
                    <td>Tilmelding</td>
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><%# Eval("holdNavn") %></td>
                <td><%# Eval("stilartNavn") %></td>
                <td><%# Eval("niveauNavn") %></td>
                <td><%# Eval("alderNavn") %></td>
                <td><%# Eval("instruktorNavn") %></td>
                <td><a href='Holdoversigt.aspx?Holdid=<%# Eval("holdId") %>'>Tilmeldte på hold</a></td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
                    <asp:Label Text="Der er ikke oprettet nogen hold" runat="server" ID="lbl_fail" Visible="false" />
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
