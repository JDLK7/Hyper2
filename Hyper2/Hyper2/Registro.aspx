<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="Hyper2.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/suscripcion.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="registro">
        <h3 style="margin-bottom:1em;">Regístrate en Hyper gratis</h3>
        <ul class="input-group" style="list-style-type:none;">
            <li><input style="margin-bottom:1em;" type="text" class="form-control" placeholder="Nombre" aria-describedby="basic-addon1" /></li>
            <li><input style="margin-bottom:1em;" type="text" class="form-control" placeholder="Apellidos" aria-describedby="basic-addon1" /></li>
            <li><input style="margin-bottom:1em;" type="text" class="form-control" placeholder="Nombre de usuario" aria-describedby="basic-addon1" /></li>
            <li><input style="margin-bottom:1em;" type="text" class="form-control" placeholder="Email" aria-describedby="basic-addon1" /></li>
            <li><input style="margin-bottom:1em;" type="password" class="form-control" placeholder="Contraseña" aria-describedby="basic-addon1" /></li>
            <li><input style="margin-bottom:1em;" type="password" class="form-control" placeholder="Confirmar contraseña" aria-describedby="basic-addon1" /></li>
        </ul>
    </div>
</asp:Content>
