<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="Hyper2.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/suscripcion.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="registro_1">
        <h2 style="margin-bottom:1em;">Regístrate en Hyper gratis</h2>
        <ul class="input-group" style="list-style-type:none; width:25em">
            <li><input style="margin-bottom:1em; border-radius:4px;" type="text" class="form-control" placeholder="Nombre" aria-describedby="basic-addon1" /></li>
            <li><input style="margin-bottom:1em; border-radius:4px;" type="text" class="form-control" placeholder="Apellidos" aria-describedby="basic-addon1" /></li>
            <li><input style="margin-bottom:1em; border-radius:4px;" type="text" class="form-control" placeholder="Nombre de usuario" aria-describedby="basic-addon1" /></li>
            <li><input style="margin-bottom:1em; border-radius:4px;" type="text" class="form-control" placeholder="Email" aria-describedby="basic-addon1" /></li>
            <li><input style="margin-bottom:1em; border-radius:4px;" type="password" class="form-control" placeholder="Contraseña" aria-describedby="basic-addon1" /></li>
            <li><input style="margin-bottom:1em; border-radius:4px;" type="password" class="form-control" placeholder="Confirmar contraseña" aria-describedby="basic-addon1" /></li>
            <li style="margin-bottom:1em"><a href="#">Acepto los términos de Hyper</a></li>
            <li><button type="button" class="btn boton_registro">Registrar</button></li>
        </ul>
    </div>
    <div class="registro_2">
        <h3>La cuenta gratuita te ofrece hasta 10Gb</h3>
        <p>Con solo registrarte tendrás la posibilidad de subir hasta un total de 10Gb sin ningún tipo de gasto.
            Además podrás crear carpetas y archivos compartidos con otros usuarios e incluso publicar archivos que
            sean públicos para que todo el mundo pueda descargarlos.
        </p>
        <h3>Aun más ventajas con las cuentas premium de Hyper</h3>
        <p>Si necesitas más espacio, puedes contratar una suscripción a alguna de nuestras tarifas premium.
            Te ofrecemos mucho más espacio por muy poco precio.
            <a href="http://www.twitter.com/Jose_D_L">Más información.</a>
        </p>
        
    </div>

</asp:Content>
