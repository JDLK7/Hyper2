<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Hyper2.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/manage.css"/>
    <link rel="stylesheet" type="text/css" href="Content/registro.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <h1  style="color:darkblue;" align="center"><b>Mi perfil</b></h1>
    <div style="float:left; margin-left:1em;">
        <div style="float:right; margin-left:1em; margin-top:1em;">
            <p>Nombre del usuario</p>
            <p>Dirección de correo</p>
            <p>Plan contratado: (gratis, 100GB...)</p>
            <p>Idioma preferido</p>
        </div>
        <img style="margin-bottom:10em; float:left;" src="http://www.razas-caballos.com/Imagenes/caballo-mustang-salvaje.jpg" width="260" height="250" class="blockquote"/>
    </div>
    <div align="center">
        <h3>Gestión de memoria del usuario</h3>
        <div>
            <p>Espacio disponible:</p>
            <p>Espacio usado (música)</p>
            <p>Espacio usado (video)</p>
            <p>Espacio usado (texto)</p>
            <p>Espacio usado (imagen)</p>
        </div>
    </div>
</asp:Content>
