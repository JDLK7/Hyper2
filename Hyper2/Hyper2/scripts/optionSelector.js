$(document).ready(function() 
 {
	$('.optionsEtiqueta').click(function(event) 
	{
		$('#todosMenu').text($(event.target).text() + " ");
		$('#todosMenu').append("<b class=\"caret\"></b>");
    });
 });