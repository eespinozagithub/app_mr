
$(document).ready(function () {
	//ListadoMarcas();
	
	$("#cmbMarcas").change(function () {
		/*const valorSeleccionado = $(this).val();*/
		
		ListadoModelos($("#cmbMarcas").val());
	});
	

	
});

function ListadoModelos(IdMarca) {
	
	var cmbModelos = "#cmbModelos";
	$.ajax({
		/*contentType: "application/json",*/
		dataType: 'json',
		type: "POST",
		url: '../Camiones/getModelos',
		data: { 'IdMarca': IdMarca },
		success: function (data) {
			$(cmbModelos).html("");

			$(cmbModelos).html("<option value='0'> Seleccione un modelo </option>");

			$.each(data, function (i, data) {
				$(cmbModelos).append('<option value="' + data.value + '">' +
					data.text + '</option>');

			});

			$(cmbModelos).val("0");
			

		},

	});
}

function ListadoMarcas() {

	var cmbMarcas = "#cmbMarcas";
	$.ajax({
		/*contentType: "application/json",*/
		dataType: 'json',
		type: "POST",
		url: '../Camiones/TraeMarcas',
		data: {},
		success: function (data) {
			console.log(data);
			$(cmbMarcas).html("");
			console.log(data);
			$(cmbMarcas).html("<option value='0'> Seleccione una marca </option>");

			$.each(data, function (i, data) {
				$(cmbMarcas).append('<option value="' + data.value + '">' +
					data.text + '</option>');

			});

			$(cmbMarcas).val("0");


		},

	});
}
