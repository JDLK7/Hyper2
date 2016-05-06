<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="Hyper2.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>Regístrate en Hyper gratis</h3>
        <ul class="input-group" style="list-style-type:none;">
            <li><input type="text" class="form-control" placeholder="Nombre" aria-describedby="basic-addon1">
            <li><input type="text" class="form-control" placeholder="Apellidos" aria-describedby="basic-addon1"></li>
            <li><input type="text" class="form-control" placeholder="Nombre de usuario" aria-describedby="basic-addon1"></li>
            <li><input type="text" class="form-control" placeholder="Email" aria-describedby="basic-addon1"></li>
            <li><input type="password" class="form-control" placeholder="Contraseña" aria-describedby="basic-addon1"></li>
            <li><input type="password" class="form-control" placeholder="Confirmar contraseña" aria-describedby="basic-addon1"></li>
        </ul>
    </div>
</asp:Content>
