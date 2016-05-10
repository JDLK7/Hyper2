<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="Hyper2.AboutHyper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        div.tabla {
        margin-left:3cm;

        }
        div.tabla2 {
        margin-left:3.5cm;

        }
        td.ex1 {
            font-size: 120%;
        }
        td.titulo {
        font-size:200%
        }
</style>
    <body>

<div align="center"><img src="IMG/logoHyper.png" alt ="LogoHyper" width=325 height=125 border=0/></div>
        <h1 align="center"><b>Acerca De Hyper</b></h1>
        <div align="center" style="font-size:120%" ><br /> Hyper es un servidor de cloud storage que permite tanto guardar archivos privados para uso personal,<br />
                    como compartir archivos con permisos públicos para que todo el mundo pueda verlos y descargarlos.</div>
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
     
<div align="right" style="margin-right:2cm"><p style=font-size:100%> 100GB por 4,99€/mes. <br />500GB por 9,99€/mes.<br />1TB por 14,99€/mes.</p></div>
        


</body>

</asp:Content>
