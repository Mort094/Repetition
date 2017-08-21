<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Oprethold.aspx.cs" Inherits="Oprethold" %>


            <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

          
       

                <table class="table" style="width:50%;">
                    <tr >
                        <td>Hold navn</td>
                        <td>
                            <asp:TextBox ID="tb_navn" runat="server"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>Beskrivelse</td>
                        <td>
                        <asp:TextBox ID="tb_beskri" runat="server" TextMode="MultiLine" Columns="50" Rows="5" Style="resize: none;"></asp:TextBox></td>
                    </tr>


                    <tr >
                        <td >Vælg stilart</td>
                            <td ><asp:DropDownList ID="dd_stilart" runat="server" DataTextField="stilartNavn" Style="color: black;" DataValueField="stilartId"></asp:DropDownList>
                        </td>
                        <td>Vælg aldersgruppe</td>

                        <td >
                            <asp:DropDownList ID="dd_alder" runat="server" DataTextField="alderNavn" Style="color: black;" DataValueField="alderId"></asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td>Vælg niveau</td>
                        <td>
                            <asp:DropDownList ID="dd_niveau" runat="server" DataTextField="niveauNavn" Style="color: black;" DataValueField="niveauId"></asp:DropDownList>

                        </td>

                        <td>Vælg indstruktør</td>
                        <td>
                            <asp:DropDownList ID="dd_instructor" runat="server" DataTextField="instruktorNavn" Style="color: black;" DataValueField="instruktorId"></asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button Text="Opret hold" runat="server" ID="btn_opretHold" OnClick="btn_opretHold_Click" />
                        </td>
                    </tr>
                </table>

</asp:Content>

