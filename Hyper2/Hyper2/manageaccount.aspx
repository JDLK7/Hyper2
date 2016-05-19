<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="manageaccount.aspx.cs" Inherits="Hyper2.manageaccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/manageaccount.css"/>
    <title>Configuración</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divCentral">
        <h1  style="color:darkblue; padding-bottom:0.5em;" align="center"><b>Administración de la cuenta</b></h1>
        <div class="col_group">
            <div>
             <h3  style="color:black; padding-bottom:1em;"><b>Foto de perfil:</b></h3>
                <asp:Image ID="profilePic" runat="server" style="margin-bottom:1em;"  width="230" height="230" class="blockquote"/>
            
                 <div class="box__input">
                     <asp:FileUpload ID="uploadPic" runat="server" />
                     <asp:Button ID="buttonUpload" CssClass="btn btn-default" runat="server" Text="Cambiar" OnClick="buttonUpload_Click" />
                 </div>
            </div>
            <div>
                <h3 style="color:black; padding-bottom:1em;"><b>Cambiar datos personales:</b><br /></h3>
                 <ul class="input-group" style="list-style-type:none; width:25em;">
                    <li><asp:TextBox runat="server" style="margin-bottom:1em; border-radius:4px;" class="form-control" placeholder="Nombre" type="text" ID="TextBoxName" /></li>
                    <li><asp:TextBox runat="server" style="margin-bottom:1em; border-radius:4px;" class="form-control" placeholder="Apellidos" type="text" ID="TextBoxSurname" /></li>
                   <!-- <li><asp:TextBox runat="server" style="margin-bottom:1em; border-radius:4px;" class="form-control" placeholder="Nombre de usuario" type="text" ID="TextBoxUsername"/></li>-->
                    <li><asp:TextBox runat="server" style="margin-bottom:1em; border-radius:4px;" class="form-control" placeholder="E-mail" type="text" ID="TextBoxEmail"/></li>
                    <li><asp:TextBox runat="server" style="margin-bottom:1em; border-radius:4px;" class="form-control" placeholder="Contraseña" type="password" ID="TextBoxPassword"/></li>
                    <li><asp:TextBox runat="server" style="margin-bottom:1em; border-radius:4px;" class="form-control" placeholder="Confirmar contraseña" type="password" ID="TextBoxPassword2"/></li>
                    <!--<li><asp:TextBox runat="server" class="form-control" type="submit" value="Confirmar cambios" onclick="buttonCambiar"/></li>-->
                    <li><asp:Button ID="Button1" runat="server" class="form-control" Text="Confirmar cambios" onclick="buttonCambiar"/></li>
	            </ul>   
             </div>
        </div>
    </div>
</asp:Content>
