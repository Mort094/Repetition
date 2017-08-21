<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Holdoversigt.aspx.cs" Inherits="Holdoversigt" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <asp:Repeater runat="server" ID="repeater_data">
        <HeaderTemplate>
            <table class="table">
                <tr>
                    <th>Navn</th>
                    <th>Holdnavn</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("brugerNavn") %></td>
                <td><%# Eval("holdNavn") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
</asp:Content>
