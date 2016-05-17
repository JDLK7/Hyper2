<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="iniciarSesion.aspx.cs" Inherits="Hyper2.iniciarSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/iniciarSesion.css"/>
    <title>Iniciar sesión</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col_group" id="divCentral">
        <div>
            <h2 style="margin-bottom:1em;">Iniciar sesión</h2>
            <ul class="input-group" style="list-style-type:none; width:25em;">
                <li><asp:TextBox ID="textBox_username" runat="server" style="margin-bottom:1em; border-radius:4px;" type="text" class="form-control" placeholder="Nombre de usuario" aria-describedby="basic-addon1" /></li>
                <li><asp:TextBox ID="textBox_password" runat="server" style="margin-bottom:1em; border-radius:4px;" type="password" class="form-control" placeholder="Contraseña" aria-describedby="basic-addon1" /></li>
                <li style="margin-bottom:1em;"><asp:Label ID="label_error" CssClass="label_error" runat="server"></asp:Label></li>
                <li><asp:Button ID="button_signIn" OnClick="button_logIn_Click" runat="server" type="button" class="btn boton_registro" Text="Iniciar sesión"/></li>
            </ul>
        </div>
        <div style="margin-top:2em;">
            <h3>La cuenta gratuita te ofrece hasta 10Gb</h3>
            <p>Con solo registrarte tendrás la posibilidad de subir hasta un total de 10Gb sin ningún tipo de gasto.
                Además podrás crear carpetas y archivos compartidos con otros usuarios e incluso publicar archivos que
                sean públicos para que todo el mundo pueda descargarlos.
            </p>
        </div>
    </div>
</asp:Content>
