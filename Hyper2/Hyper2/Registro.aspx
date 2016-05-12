<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="Hyper2.Registro" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/registro.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col_group" id="divCentral">
        <div>
            <h2 style="margin-bottom:1em;">Regístrate en Hyper gratis</h2>
            <ul class="input-group" style="list-style-type:none; width:25em;">
                <!--El texto de los label se puede programar con C# para que cambie según el tipo de error-->
                <li><asp:TextBox ID="textBox_firstName" runat="server" style="margin-bottom:1em; border-radius:4px;" type="text" class="form-control" placeholder="Nombre" aria-describedby="basic-addon1" /></li>
                <li><asp:TextBox ID="textBox_lastName" runat="server" style="margin-bottom:1em; border-radius:4px;" type="text" class="form-control" placeholder="Apellidos" aria-describedby="basic-addon1" /></li>
                <li><asp:TextBox ID="textBox_username" runat="server" style="margin-bottom:1em; border-radius:4px;" type="text" class="form-control" placeholder="Nombre de usuario" aria-describedby="basic-addon1" /></li>

                <li style="margin-bottom:1em;"><asp:Label ID="label_username" CssClass="label_error" runat="server"></asp:Label></li>

                <li><asp:TextBox ID="textBox_email" runat="server" style="margin-bottom:1em; border-radius:4px;" type="text" class="form-control" placeholder="Email" aria-describedby="basic-addon1" /></li>

                <li style="margin-bottom:1em;"><asp:Label ID="label_email" CssClass="label_error" runat="server"></asp:Label></li>

                <li><asp:TextBox ID="textBox_password" runat="server" style="margin-bottom:1em; border-radius:4px;" type="password" class="form-control" placeholder="Contraseña" aria-describedby="basic-addon1" /></li>
                <li><asp:TextBox ID="textBox_passwordConf" runat="server" style="border-radius:4px;" type="password" class="form-control" placeholder="Confirmar contraseña" aria-describedby="basic-addon1" /></li>
                <li style="margin-bottom:1em;"><asp:Label ID="label_password" CssClass="label_error" runat="server"></asp:Label></li>
                <li style="margin-bottom:1em"><a href="#"><br />Acepto los términos de Hyper</a></li>
                <li><asp:Button ID="button_signIn" OnClick="button_signIn_Click" runat="server" type="button" class="btn boton_registro" Text="Registrar"/></li>
            </ul>
        </div>
        <div style="margin-top:2em;">
            <h3>La cuenta gratuita te ofrece hasta 10Gb</h3>
            <p>Con solo registrarte tendrás la posibilidad de subir hasta un total de 10Gb sin ningún tipo de gasto.
                Además podrás crear carpetas y archivos compartidos con otros usuarios e incluso publicar archivos que
                sean públicos para que todo el mundo pueda descargarlos.
            </p>
            <h3>Aun más ventajas con las cuentas premium de Hyper</h3>
            <p>Si necesitas más espacio, puedes contratar una suscripción a alguna de nuestras tarifas premium.
                Te ofrecemos mucho más espacio por muy poco precio.
                <a href="#">Más información.</a>
            </p>
        </div>
    </div>
</asp:Content>
