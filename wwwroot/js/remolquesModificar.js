$(document).ready(function ()
{
	$("#idMarca").change(function ()
	{
		ListadoModelos($("#idMarca").val());
	});
});

function ListadoModelos(IdMarca)
{		
	var idModelo = "#cmbModelos";	
	$.ajax({		
		dataType: 'json',
		type: "POST",
		url: '../getModelos',
		data: { 'IdMarca': IdMarca },
		success: function (data) {
			
			$(idModelo).html("");

			$(idModelo).html("<option value='' selected>[Seleccione]</option>");

			$.each(data, function (i, data) {
				$(idModelo).append('<option value="' + data.value + '">' + data.text + '</option>');
			});			
		},		
	});
}