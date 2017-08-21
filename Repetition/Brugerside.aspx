<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Brugerside.aspx.cs" Inherits="Brugerside" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <asp:Repeater runat="server" ID="repeater_brugerInfo">

        <ItemTemplate>
            <h2><%# Eval("brugerNavn") %></h2>
        </ItemTemplate>

    </asp:Repeater>

    <asp:Repeater runat="server" ID="repeater_holdInfo" OnItemDataBound="repeater_holdInfo_ItemDataBound" OnItemCommand="repeater_holdInfo_ItemCommand">
        <HeaderTemplate>
            <table class="table">
                <tr>
                    <td>Holdnavn</td>
                    <td>Stilart</td>
                    <td>Niveau</td>
                    <td>Alder</td>
                    <td>Instruktor</td>
                    <td>Framelding</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("holdNavn") %></td>
                <td><%# Eval("stilartNavn") %></td>
                <td><%# Eval("niveauNavn") %></td>
                <td><%# Eval("alderNavn") %></td>
                <td><%# Eval("instruktorNavn") %></td>
                <td>
                    <asp:LinkButton Text="Frameld hold" runat="server" CommandArgument='<%# Eval("holdId") %>' CommandName="frameld" /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
                <asp:Label Text="Du er ikke tilmeldt et hold" runat="server" ID="lbl_fail" Visible="false" />
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
