<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="Hyper2.AboutHyper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>

        #listaDetalles{

            font-size:115%;

        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <body>

        <div id="divCentral" align="center">

            <!-- Dejo el código por si alguien no esta de acuerdo con las nuevas descripciones. Si no es así ya se borrará más adelante.

                    <p><br /><br /></p>

                    <div class="tabla"><table width="100%" cellspacing="0">
            <td width="30%" class ="titulo" ><b>Sin iniciar sesión</b></td>
            <td width="30%" class ="titulo"><b>Free</b></td>
            <td width="30%" class ="titulo"><b>Premium</b></td>
            </table></div>
   
                    <div class="tabla2"><table width="100%" cellspacing="0">
            <td width="30%" class ="ex1">Hyper te permite descargar archivos</td>
            <td width="30%" class ="ex1">Subida de archivos limitada</td>
            <td width="30%" class ="ex1">Subida de archivos limitada a 100GB, 500GB</td>
            </table></div>

                    <div class="tabla2"><table width="100%" cellspacing="0">
            <td width="30%" class ="ex1">públicos de otros usuarios.</td>
            <td width="30%" class ="ex1">a 10GB</td>
            <td width="30%" class ="ex1">o un 1TB, segun su subscripción.</td>
            </table></div>
                    <p><br /></p>
     
            <div align="right" style="margin-right:2cm"><p style=font-size:100%>  <br /><br /></p></div>
        
            -->

            <div align="center"><img src="IMG/logoHyper.png" alt ="LogoHyper" width=325 height=125 border=0/></div>

            <h1 align="center"><b>Acerca De Hyper</b></h1>
            <div align="center" style="font-size:120%" ><br /> Hyper es un servidor de cloud storage que permite tanto guardar archivos privados para uso personal,<br />
            como compartir archivos con permisos públicos para que todo el mundo pueda verlos y descargarlos.</div>

            <li style="list-style:none;padding:5em;" id="listaDetalles">

                <div style="max-width:20%;min-width:20%;display:inline-block;;vertical-align:middle;text-align:center">
                    <b>Descarga libremente</b><br /><br />
                    <ul style="list-style-type:disc">
                        <li>No hace falta iniciar sesión para descargar archivos.</li>
                        <li>Comparte archivos en segundos.</li>

                </div>

                <div style="max-width:20%;min-width:20%;display:inline-block;vertical-align:middle;text-align:center">

                    <b>Freemium</b><br /><br />
                    <ul style="list-style-type:disc">
                        <li>Subida de archivos limitada a 50GB.</li>
                        <li>Descarga de archivos ilimitada.</li>

                </div>

                <div style="max-width: 20%;min-width: 20%;display:inline-block;vertical-align:middle;text-align:center">
                    
                    <b>Premium</b><br /><br />
                    <ul style="list-style-type:disc">
                        <li>Subida de archivos según tarifa.</li>
                        <li>Descargad de archivos ilimitada.</li>

                </div>
                <div style="max-width: 20%;min-width: 20%;display:inline-block;vertical-align:middle;text-align:center">
                    
                    <b class="tituloLista">Suscripciones</b><br /><br />
                    <ul style="list-style-type:disc">
                        <li>100GB por 4,99€/mes.</li>
                        <li>500GB por 9,99€/mes.</li>
                        <li>1TB por 14,99€/mes.</li>
                </div>

            </li>


        </div>
</body>

</asp:Content>
