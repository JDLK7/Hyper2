<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="manageaccount.aspx.cs" Inherits="Hyper2.manageaccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-left: 3em;">
     <h1  style="color:darkblue;"><P ALIGN=center><b>Administración de la cuenta</b><br /></p></h1>
     <h3  style="color:black;"><b>Foto de perfil:</b></h3>
        <img src="http://www.razas-caballos.com/Imagenes/caballo-mustang-salvaje.jpg" width=280 height=210 border=0 />
        <form class="box" method="post" action="" enctype="multipart/form-data">
         <div class="box__input">
             <input class="box__file" type="file" name="files[]" id="file" data-multiple-caption="{count} files selected" multiple />
             <button class="box__button" type="submit">Subir archivo</button>
         </div>
    </div>
    <div style="margin-left: 3em;">
        <h3 style="color:black;"><b>Cambiar datos personales:</b><br /></h3>
            <fieldset>
                <input style="margin-bottom:1em;" class="form-control" placeholder="Nombre Completo" type="text" /><br />
                <input style="margin-bottom:1em;" class="form-control" placeholder="Nombre de usuario" type="text" /><br />
                <input style="margin-bottom:1em;" class="form-control" placeholder="E-mail" type="text" /><br />
                <input style="margin-bottom:1em;" class="form-control" placeholder="Contraseña" type="password" /><br />
                <input style="margin-bottom:1em;" class="form-control" placeholder="Confirmar contraseña" type="password" /><br />
                <input class="form-control" type="submit" value="Confirmar cambios" />
	        </fieldset>
     </div>
    <p></p>
	</form>
</asp:Content>
