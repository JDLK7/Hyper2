<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="manageaccount.aspx.cs" Inherits="Hyper2.manageaccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <h1><P ALIGN=center>Administración de la cuenta<br /></p></h1>
     <p><blockquote>Foto de perfil:<br />
         <img src="http://www.razas-caballos.com/Imagenes/caballo-mustang-salvaje.jpg" width=280 height=210 border=0 alt="Un caballo con mucho flow" />
        <form class="box" method="post" action="" enctype="multipart/form-data">
         <div class="box__input">
             <input class="box__file" type="file" name="files[]" id="file" data-multiple-caption="{count} files selected" multiple />
             <button class="box__button" type="submit">Subir archivo</button>
        </div>
        <br />
        <h3 align="justify"><b>Cambiar datos personales:</b><br /></h3>
	    <fieldset>
            <input class="form-control" placeholder="Nombre Completo" type="text" /><br />
            <input class="form-control" placeholder="Nombre de usuario" type="text" /><br />
            <input class="form-control" placeholder="E-mail" type="text" /><br />
            <input class="form-control" placeholder="Contraseña" type="password" /><br />
            <input class="form-control" placeholder="Confirmar contraseña" type="password" /><br />
	        <input class="form-control" type="submit" value="Confirmar cambios" />
	    </fieldset>
	</form>
</asp:Content>
