<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="subir.aspx.cs" Inherits="Hyper2.subir" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <link rel="stylesheet" type="text/css" href="Content/index.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--<asp:Button id="Button1" Text="Click here for greeting..." OnClick="clickSubir" runat="server"/>-->

        <div id="divCentral" align="center">

            <div align="center"><img src="IMG/logoHyper.png" alt ="LogoHyper" width=325 height=125 border=0/></div>

            <h1 align="center"><b>Sube tus archivos a hyper</b></h1><br />

            <asp:FileUpload id="FileUploadControl" runat="server" />
            <br /> 

            <b>Descripción:</b> <br /><br />
             <textarea rows="4" cols="50"></textarea>
            <br /><br />
            
            
            <form action="">
            ¿Archivo privado? <input type="checkbox" name="privado" value="Privado">
            </form>

            <br /><br />
            <asp:Button runat="server" id="UploadButton" text="Upload" onclick="UploadButton_Click" />
            <br /><br />
            <asp:Label runat="server" id="StatusLabel" text="Upload status: " />

        </div>

</asp:Content>
