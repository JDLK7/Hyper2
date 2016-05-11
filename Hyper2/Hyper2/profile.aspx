<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Hyper2.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/manage.css"/>
    <link rel="stylesheet" type="text/css" href="Content/registro.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
* {
    box-sizing: border-box;   
}
.grafico {
    height: 200px;
    margin: 1rem auto;
    position: relative;
    width: 200px;
      }
.recorte {
    border-radius: 50%;
    clip: rect(0px, 200px, 200px, 100px);
    height: 100%;
    position: absolute;
    width: 100%;
     }
.quesito {
    border-radius: 50%;
    clip: rect(0px, 100px, 200px, 0px);
    height: 100%;
    position: absolute;
    width: 100%;
    font-family: monospace;
    font-size: 1.5rem;
     }
.sombra {
    background-color: #fff;
    border-radius: 50%;
    box-shadow: 0 4px 7px rgba(0, 0, 0, 0.3);
    border: 5px solid #000;
    height: 100%;
    position: absolute;
    width: 100%;
     }

#porcion1 {
    transform: rotate(0deg);
     }

#porcion1 .quesito {
    background-color: rgba(0,0,255,.7);
    transform: rotate(70deg);
     }
#porcion2 {
    transform: rotate(70deg);
     }
#porcion2 .quesito {
    background-color: rgba(255,255,0,.7);
    transform: rotate(120deg);
     }
#porcion3 {
    transform: rotate(-170deg);
     }
#porcion3 .quesito {
    background-color: rgba(0,128,0,.7);
    transform: rotate(25deg);
     }
#porcionFin {
    transform:rotate(-145deg);
     }
#porcionFin .quesito {
    background-color: rgba(255,0,0,.7);
    transform: rotate(145deg);
     }
#porcion1 .quesito:after {
    content: attr(data-rel);
    left: 25%;
    line-height: 5;
    position: absolute;
    top: 0;
    transform: rotate(-70deg);
}
#porcion2 .quesito:after {
    content: attr(data-rel);
    left: 15%;
    position: absolute;
    top: 30%;
    transform: rotate(-190deg);
}
#porcion3 .quesito:after {
    content: attr(data-rel);
    left: 35%;
    position: absolute;
    top: 4%;
    transform: rotate(70deg);
}
#porcionFin .quesito:after {
   content: attr(data-rel);
   left: 10%;
   position: absolute;
   top: 30%;
}

</style>
       <h1  style="color:darkblue;" align="center"><b>Mi perfil</b></h1>
    <div style="float:left; margin-left:1em;">
        <div style="float:right; margin-left:1em; margin-top:1em;">
            <p>Nombre del usuario</p>
            <p>Dirección de correo</p>
            <p>Plan contratado: (gratis, 100GB...)</p>
            <p>Idioma preferido</p>
        </div>
        <img style="margin-bottom:10em; float:left;" src="http://www.razas-caballos.com/Imagenes/caballo-mustang-salvaje.jpg" width="260" height="250" class="blockquote"/>
    </div>
    <div align="center">
        <h3>Gestión de memoria del usuario</h3>
        <div>
            <p>Espacio disponible:</p>
            <p>Espacio usado (música)</p>
            <p>Espacio usado (video)</p>
            <p>Espacio usado (texto)</p>
            <p>Espacio usado (imagen)</p>
            <div class="grafico">
                 <div class="sombra"></div>
                 <div id="porcion1" class="recorte"><div class="quesito" data-rel="70"></div></div>
                 <div id="porcion2" class="recorte"><div class="quesito" data-rel="120"></div></div>
                 <div id="porcion3" class="recorte"><div class="quesito" data-rel="25"></div></div>
                 <div id="porcionFin" class="recorte"><div class="quesito" data-rel="145"></div></div>
            </div>
        </div>
    </div>
</asp:Content>
