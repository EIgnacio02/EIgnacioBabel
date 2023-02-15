$(document).ready(function () {
    GetAll();
    PlanGetAll();
    CoberturaGetAll();
});


function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:64703/api/Cliente/GetAll',
        success: function (result) {
            $("#tblCliente tbody").empty();
            $.each(result.Objects, function (i, Cliente) {
                var fila =
                    '<tr>'
                    + '<td class="text-center hidden" style="display :none;">' + Cliente.IdCliente + '</td>'
                    + '<td class="text-center">' + Cliente.Nombre + '</td>'
                    + '<td class="text-center">' + Cliente.ApellidoPaterno + '</td>'
                    + '<td class="text-center">' + Cliente.ApellidoMaterno + '</td>'
                    + '<td class="text-center">' + Cliente.FechaModificacion + '</td>'
                    + '<td class="text-center" style="display :none;">' + Cliente.Planes.IdPlanes + '</td>'
                    + '<td class="text-center">' + Cliente.Planes.Descripcion + '</td>'
                    //+ '<td class="text-center">' + Cliente.Planes.FechaModicacionPlanes + '</td>'
                    + '<td class="text-center" style="display :none;">' + Cliente.Coberturas.IdCobertura + '</td>'
                    + '<td class="text-center">' + Cliente.Coberturas.Descripcion + '</td>'
                    //+ '<td class="text-center">' + Cliente.Coberturas.FechaModicacionCobertura + '</td>'
                    + '</tr>';
                $("#tblCliente tbody").append(fila);
            });
        },
        error: function (result) {
            alert('Error en la consulta');
        }
    });
};


function Modal() {
    var mostrar = $('#ModalUpdate').modal('show');
}

function ModalCerrar() {
    var cerrar = $('#ModalUpdate').modal('hide');
    GetAll();
}

function PlanGetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:64703/api/Plan/GetAll',
        success: function (result) {
            $("#ddlNombrePlan").append('<option disabled="disabled" value="' + 0 + '">' + 'Seleccion un plan' + '</option>');
            $.each(result.Objects, function (i, planes) {
                $("#ddlNombrePlan").append('<option value="' + planes.IdPlanes + '" >'
                    + planes.Descripcion + '</option>');
            });
        }
    });
}

function CoberturaGetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:64703/api/Cobertura/GetAll',
        success: function (result) {
            $("#ddlNombreCobertura").append('<option disabled="disabled" value="' + 0 + '">' + 'Seleccion un plan' + '</option>');
            $.each(result.Objects, function (i, cobertura) {
                $("#ddlNombreCobertura").append('<option value="' + cobertura.IdCobertura + '" >'
                    + cobertura.Descripcion + '</option>');
            });
        }
    });
}


function Add(empleado) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:64703/api/Cliente/Add',
        dataType: 'json',
        data: JSON.stringify(empleado),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
}





function Aceptar() {
    var cliente = {
        IdCliente: $('#txtIdEmpleado').val(),
        Nombre: $('#txtNombreEmpleado').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val(),
        Edad: $('#txtEdad').val(),
        Planes: {
            IdPlanes: $('#ddlNombrePlan').val()
        },
        Coberturas: {
            IdCobertura: $('#ddlNombreCobertura').val()
        }
    }

    if (cliente.IdCliente == '') {
        cliente.IdCliente = 0; //Para que no llegue como vacio a add
        Add(cliente);

    }
    //else {
    //    Update(cliente);
    //}
}