<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="messages.aspx.cs" Inherits="Hyper2.messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript" src='scripts/messagesEditor.js'></script>
    <link rel="stylesheet" type="text/css" href="Content/messages.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divCental">
        <div id="messagesMain">
            <asp:ListView ID="ListView1" runat="server">
                <LayoutTemplate>
                    <table runat="server" class="tablaDeUsers">
                        <tr>
                            <th>Conversaciones</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server" >
                        <td class="users"><asp:Label ID="DateLabel" runat="server" Text='<%#Eval("Username") %>' /></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div id="messagesText">
            <asp:ListView ID="ListView2" runat="server">
                <LayoutTemplate>
                    <table runat="server" class="tablaDeMensajes">
                        <tr>
                            <th>Mensajes</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td class="mensajesTD"><asp:Label ID="DateLabe2" runat="server" Text='<%#Eval("Name") %>' CssClass="mensajesText" /></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <div id="messageBox" align="center">
                <asp:TextBox ID="charBox" runat="server" class="form-control-messages" ></asp:TextBox>
                <asp:Button ID="buttonEnviar" runat="server" Text="Enviar" class="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
