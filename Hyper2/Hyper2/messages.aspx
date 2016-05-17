<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="messages.aspx.cs" Inherits="Hyper2.messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript" src='scripts/messagesEditor.js'></script>
    <link rel="stylesheet" type="text/css" href="Content/messages.css" />
    <title>Mensajes</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divCental">
        <div id="messagesMain">
            <asp:ListView ID="ListViewUsers" runat="server">
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
                        <td class="users"><asp:Button ID="DateLabel" runat="server" Text='<%#Eval("Username") %>' OnClick="mostrarMensajes" /></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div id="messagesText">
            <asp:ListView ID="ListViewMessages" runat="server">
                <LayoutTemplate>
                    <table runat="server" class="tablaDeMensajes">
                        <tr>
                            <th>Mensajes</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server" class='<%#Eval("propietario") %>'>
                        <td class="mensajesTD"><asp:Label ID="DateLabe2" runat="server" Text='<%#Eval("text") %>' CssClass="mensajesText" /></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <div id="messageBox" align="center">
                <asp:TextBox ID="chatBox" runat="server" class="form-control-messages" ></asp:TextBox>
                <asp:Button ID="buttonEnviar" runat="server" Text="Enviar" OnClick="mandarMensajes" class="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
