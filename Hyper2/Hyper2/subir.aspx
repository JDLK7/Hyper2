<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="subir.aspx.cs" Inherits="Hyper2.subir" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="Content/subir.css" />
    <title>Subir archivos</title>    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div id="divCentral" align="center">

            <div align="center"><img src="IMG/logoHyper.png" alt ="LogoHyper" width=325em height=125em border=0/></div>

            <h1 align="center"><b>Sube tus archivos a hyper</b></h1><br />
            <p>Seguro que alguna vez has intentado enviar un archivo por email
                pero era demasiado grande. Con la subida gratuita de Hyper podrás subir un archivo
                de hasta 1GB y automáticamente se generará un enlace que podrás compartir con el destinatario
                que eligas para que pueda descargarse el archivo. Una vez descargado el archivo expirará.<br /></p>

            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br /> 

            <b>Descripción:</b> <br /><br />
             <asp:TextBox runat="server" ID="description" CssClass="form-control"></asp:TextBox>
            <br /><br />

            <br /><br />
            <asp:Button runat="server" id="UploadButton" text="Upload" CssClass="btn btn-default" onclick="UploadButton_Click" />
            <br /><br />
            <asp:Label runat="server" id="StatusLabel" text="Upload status: " BorderColor="Blue" />

        </div>

</asp:Content>
