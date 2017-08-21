<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <p>Login</p>
    <table class="table">
        <tr>
            <td>
                <asp:Button Text="Login som test person" ID="btn_testbruger" OnClick="btn_testbruger_Click" runat="server" /></td>
        </tr>
        <tr>
            <td>
                <asp:Button Text="Login som Admin" ID="btn_admin" OnClick="btn_admin_Click" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button Text="Login som test person2" ID="Button2" OnClick="Button2_Click" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
