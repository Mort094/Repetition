<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Stilart.aspx.cs" Inherits="Stilart" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label Text="" ID="lbl_info" runat="server" Visible="false" />

    <asp:Repeater runat="server" ID="repeater_showStilArt">

        <ItemTemplate>
            <p>Du har valgt <%# Eval("stilartNavn") %></p>
        </ItemTemplate>
    </asp:Repeater>

    <asp:Repeater runat="server" ID="repeater_showTeams" OnItemDataBound="repeater_showTeams_ItemDataBound" OnItemCommand="repeater_showTeams_ItemCommand">
        <HeaderTemplate>
            <table class="table">
                <tr>
                    <td>Hold navn:</td>
                    <td>beskrivelse:</td>
                    <td>Stilart:</td>
                    <td>Niveau:</td>
                    <td>Alder:</td>
                    <td>Instruktor:</td>
                    <td></td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("holdNavn") %></td>
                <td><%# Eval("holdBeskr") %></td>
                <td><%# Eval("stilartNavn") %></td>
                <td><%# Eval("niveauNavn") %></td>
                <td><%# Eval("alderNavn") %></td>
                <td><%# Eval("instruktorNavn") %></td>
                <td>
                    <asp:LinkButton Text="Tilmeld" runat="server" CommandName="tilmeld" CommandArgument='<%# Eval("holdId") %>' /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
                      <asp:Label Text="Der er ikke oprettet nogen hold, med denne stilart tilknyttet" runat="server" ID="lbl_fail" Visible="false" />
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
