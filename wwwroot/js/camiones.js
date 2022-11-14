
$(document).ready(function () {

	
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

//function ListadoModelos(IdMarca) {

//	var cmbModelos = "#cmbModelos";
//	$.ajax({
//		/*contentType: "application/json",*/
//		dataType: 'json',
//		type: "POST",
//		url: '../Camiones/getModelos',
//		data: { 'IdMarca': IdMarca },
//		success: function (data) {
//			//$(cmbModelos).html("");

//			//$(cmbModelos).html("<option value='0'> Seleccione un terminal </option>");

//			////$.each(data,
//			////	function (i,val) {
//			////		$(cmbModelos).append($('<option />', { value: val.IdModelo, text: Modelo }));
//			////	});


//			//$(cmbModelos).val("0");
//			$.each(data, function (key, registro) {
//				$("#Select").append('<option value=' + registro.id + '>' + registro.nombre + '</option>');
//			});

//		},

//	});
//}