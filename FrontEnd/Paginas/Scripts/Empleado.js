jQuery(function () {
    //Registrar los botones para responder al evento click
    $("#dvMenu").load("Menu.html");
    //Activar el evento de click en los botones que vamos a programar
    //Con jquery, los objetos se identifican con "$(#" al inicio del nombre del objeto
    /*LlenarTablaEmpleados();*/
    LlenarComboCargo();
    LlenarComboTurno();
    LlenarTablaEmpleados();

    $("#btnInsertar").on("click", function () {
        EjecutarComando("POST");
    });
    $("#btnActualizar").on("click", function () {
        EjecutarComando("PUT");
    });

    $("#btnEliminar").on("click", function () {
        EjecutarComando("DELETE");
    });

    $("#btnBuscar").on("click", function (event) {
        event.preventDefault();
        Consultar();
    });
});

async function LlenarComboCargo() {
    LlenarComboXServicios("https://localhost:44367/api/Cargos", "#cboEmpleado");
}

async function LlenarComboTurno() {
    try {
        const Respuesta = await fetch("https://localhost:44367/api/Turnos",
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                }
            });
        const Rpta = await Respuesta.json();
        //Se debe limpiar el combo
        $("#cboTurnos").empty();
        //Se recorre en un ciclo para llenar el select con la información
        for (i = 0; i < Rpta.length; i++) {
            $("#cboTurnos").append('<option value=' + Rpta[i].ID_TURNO + '>' + Rpta[i].DESCRIPCION_TURNO + '</option>');
        }
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
}

async function LlenarTablaEmpleados() {
    LlenarTablaXServicios("https://localhost:44367/api/empleados", "#tblEmpleados");
}

async function Consultar() {
    let documento = $("#txtDocumento").val();
    try {
        const respuesta = await fetch("https://localhost:44367/api/empleados?cedula=" + documento, {
            method: "GET",
            mode: "cors",
            headers: { "Content-type": "application/json" },
        });

        const resultado = await respuesta.json();

        $("#txtNombre").val(resultado.NOMBRE);
        $("#txtApellido").val(resultado.APELLIDO);
        $("#txtTelefono").val(resultado.TELEFONO);
        $("#txtDireccion").val(resultado.DIRECCION);
        $("#cboEmpleado").val(resultado.CARGO);
        $("#cboTurnos").val(resultado.TURNO);
    } catch (error) {
        console.error("Error:", error);
        $("#dvMensaje").html('Error: ' + error.message);
    }
}


async function EjecutarComando(comando) {
    /*Se capturan los datos de entrada del formulario HTML. Los valores de los campos del formulario se obtienen utilizando
    jQuery y se asignan a variables locales.*/
    let cedulaEmpleado = $("#txtDocumento").val();
    let nombreEmpleado = $("#txtNombre").val();
    let apellidoEmpleado = $("#txtApellido").val();
    let telefonoEmpleado = $("#txtTelefono").val();
    let direccionEmpleado = $("#txtDireccion").val();
    let cargoEmpleado = $("#cboEmpleado").val();
    let turnoEmpleado = $("#cboTurnos").val();

    //Construir la estructura JSON para enviar la información al servidor
    let datosEmpleado = {
        CEDULA: cedulaEmpleado,
        NOMBRE: nombreEmpleado,
        APELLIDO: apellidoEmpleado,
        TELEFONO: telefonoEmpleado,
        DIRECCION: direccionEmpleado,
        CARGO: cargoEmpleado,
        TURNO: turnoEmpleado
    }
    try {
        const respuesta = await fetch("https://localhost:44367/api/empleados", {
            method: comando,
            mode: "cors",
            headers: { "Content-type": "application/json" },
            body: JSON.stringify(datosEmpleado)
        });
        //Leer la respuesta y presentarla en el div
        const resultado = await respuesta.json();
        $("#dvMensaje").html(resultado);
    } catch (error) {
        $("#dvMensaje").html(error);
    }
}
