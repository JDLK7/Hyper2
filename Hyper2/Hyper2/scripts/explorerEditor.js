$(document).ready(function () {

    //Carga el contenido de messages.css después de cargar la página para no ser sobreescribido.
    $('head').append($('<link rel="stylesheet" type="text/css" />').attr('href', 'Content/explorador.css'));
    
});

function showBrowseDialog() {
    document.getElementById('<%=uploadControl.ClientID%>').click();
}