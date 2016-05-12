<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Hyper2.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/profile.css"/>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divCentral">
        <h1 id="barraTitulo" style="color:darkblue; margin-bottom:2em;" align="center"><b>Mi perfil</b></h1>
        <div style="float:left; margin-left:1em;" id="datosUser">
            <div style="float:right; margin-left:10em; margin-top:1em;">
                <p><strong>Nombre del usuario</strong></p>
                <p><strong>Dirección de correo</strong></p>
                <p><strong>Plan contratado: (gratis, 100GB...)</strong></p>
                <p><strong>Idioma preferido</strong></p>
            </div>
            <img style="margin-bottom:10em; float:left;" src="http://www.razas-caballos.com/Imagenes/caballo-mustang-salvaje.jpg" width="260" height="250" class="blockquote"/>
        </div>
        <div align="center">
            <h3>Gestión de memoria del usuario</h3>
            <div>
                <p>Espacio disponible:</p>
                <p style ="color:blue">Espacio usado (música)</p>
                <p style ="color:red">Espacio usado (video)</p>
                <p style ="color:green">Espacio usado (texto)</p>
                <p style ="color:yellow">Espacio usado (imagen)</p>
                <div class="grafico">
                     <div class="sombra"></div>
                     <div id="porcion1" class="recorte"><div class="quesito" data-rel="70MB"></div></div>
                     <div id="porcion2" class="recorte"><div class="quesito" data-rel="120MB"></div></div>
                     <div id="porcion3" class="recorte"><div class="quesito" data-rel=" 25MB"></div></div>
                     <div id="porcionFin" class="recorte"><div class="quesito" data-rel="145MB"></div></div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
