jQuery(function () {
    //Registrar los botones para responder al evento click
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarComboCliente();
    LlenarTablaVehiculos();

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

async function LlenarComboCliente() {
    try {
        const Respuesta = await fetch("https://localhost:44367/api/clientes",
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                }
            });
        const Rpta = await Respuesta.json();
        //Se debe limpiar el combo
        $("#cboPropietario").empty();
        //Se recorre en un ciclo para llenar el select con la información
        for (i = 0; i < Rpta.length; i++) {
            $("#cboPropietario").append('<option value=' + Rpta[i].DOCUMENTO + '>' + Rpta[i].NOMBRE + '</option>');
        }
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
}

async function LlenarTablaVehiculos() {
    LlenarTablaXServicios("https://localhost:44367/api/Vehiculos", "#tblEmpleados");
}

async function Consultar() {
    let placa = $("#").val();
    try {
        const respuesta = await fetch("https://localhost:44367/api/Vehiculos?Placa=" + placa, {
            method: "GET",
            mode: "cors",
            headers: { "Content-type": "application/json" },
        });

        const resultado = await respuesta.json();

        $("#txtModelo").val(resultado.MODELO);
        $("#cboPropietario").val(resultado.PROPIETARIO);
        $("#cboTipoVehiculo").val(resultado.TIPO);

    } catch (error) {
        $("#dvMensaje").html(error);
    }
}


async function EjecutarComando(comando) {
    /*Se capturan los datos de entrada del formulario HTML. Los valores de los campos del formulario se obtienen utilizando
    jQuery y se asignan a variables locales.*/
    let placa = $("#txtPlaca").val();
    let modelo = $("#txtModelo").val();
    let propietarioVehiculo = $("#cboPropietario").val();
    let tipoVehiculo = $("#cboTipoVehiculo").val();

    //Construir la estructura JSON para enviar la información al servidor
    let datosVehiculo = {
        PLACA: placa,
        MODELO: modelo,
        PROPIETARIO: propietarioVehiculo,
        TIPO: tipoVehiculo
    }
    try {
        const respuesta = await fetch("https://localhost:44367/api/Vehiculos", {
            method: comando,
            mode: "cors",
            headers: { "Content-type": "application/json" },
            body: JSON.stringify(datosVehiculo)
        });
        //Leer la respuesta y presentarla en el div
        const resultado = await respuesta.json();
        $("#dvMensaje").html(resultado);
    } catch (error) {
        $("#dvMensaje").html(error);
    }
}
