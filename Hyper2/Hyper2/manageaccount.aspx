<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="manageaccount.aspx.cs" Inherits="Hyper2.manageaccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/manage.css"/>
    <link rel="stylesheet" type="text/css" href="Content/registro.css"/>
    <title>Configuración</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1  style="color:darkblue;" align="center"><b>Administración de la cuenta</b></h1>
    <div class="col_group">
        <div>
         <h3  style="color:black;"><b>Foto de perfil:</b></h3>
            <asp:Image ID="profilePic" runat="server" style="margin-bottom:1em;" src="IMG/defaultPic.png" width="230" height="230" class="blockquote"/>
            
             <div class="box__input">
                 <asp:FileUpload ID="uploadPic" runat="server" />
                 <asp:Button ID="buttonUpload" CssClass="btn btn-default" runat="server" Text="Cambiar" OnClick="buttonUpload_Click" />
             </div>
        </div>
        <div>
            <h3 style="color:black;"><b>Cambiar datos personales:</b><br /></h3>
             <ul class="input-group" style="list-style-type:none; width:25em;">
                <li><asp:TextBox runat="server" style="margin-bottom:1em; border-radius:4px;" class="form-control" placeholder="Nombre Completo" type="text" /></li>
                <li><asp:TextBox runat="server" style="margin-bottom:1em; border-radius:4px;" class="form-control" placeholder="Nombre de usuario" type="text" /></li>
                <li><asp:TextBox runat="server" style="margin-bottom:1em; border-radius:4px;" class="form-control" placeholder="E-mail" type="text" /></li>
                <li><asp:TextBox runat="server" style="margin-bottom:1em; border-radius:4px;" class="form-control" placeholder="Contraseña" type="password" /></li>
                <li><asp:TextBox runat="server" style="margin-bottom:1em; border-radius:4px;" class="form-control" placeholder="Confirmar contraseña" type="password" /></li>
                <li><asp:TextBox runat="server" class="form-control" type="submit" value="Confirmar cambios" /></li>
	        </ul>   
         </div>
    </div>
</asp:Content>
