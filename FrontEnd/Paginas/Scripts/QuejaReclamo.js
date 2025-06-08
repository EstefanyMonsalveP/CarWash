jQuery(function () {
    //Registrar los botones para responder al evento click
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarComboCliente();
    LlenarTablaQuejas();

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
        $("#cboCedula").empty();
        //Se recorre en un ciclo para llenar el select con la información
        for (i = 0; i < Rpta.length; i++) {
            $("#cboCedula").append('<option value=' + Rpta[i].DOCUMENTO + '>' + Rpta[i].DOCUMENTO + ' - ' + Rpta[i].NOMBRE + ' ' + Rpta[i].APELLIDO + '</option>');
        }
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
}

async function LlenarTablaQuejas() {
    LlenarTablaXServicios("https://localhost:44367/api/Queja_Reclamos", "#tblQuejas");
}

async function Consultar() {
    let id_Queja = $("#txtIdQueja").val();
    try {
        const respuesta = await fetch("https://localhost:44367/api/Queja_Reclamos?idQueja=" + id_Queja, {
            method: "GET",
            mode: "cors",
            headers: { "Content-type": "application/json" },
        });

        const resultado = await respuesta.json();

        $("#txtIdQueja").val(resultado.ID_QUEJA);
        $("#cboCedula").val(resultado.CEDULA_CLIENTE);
        $("#txtIdQueja").val(resultado.DESCRIPCION_QUEJA);

    } catch (error) {
        $("#dvMensaje").html(error);
    }
}


async function EjecutarComando(comando) {
    /*Se capturan los datos de entrada del formulario HTML. Los valores de los campos del formulario se obtienen utilizando
    jQuery y se asignan a variables locales.*/
    let id_Queja = $("#txtIdQueja").val();
    let cliente = $("#cboCedula").val();
    let descripcion_Queja = $("#txtIdQueja").val();

    //Construir la estructura JSON para enviar la información al servidor
    let datosQueja = {
        ID_QUEJA: id_Queja,
        CEDULA_CLIENTE: cliente,
        DESCRIPCION_QUEJA: descripcion_Queja,
    }
    try {
        const respuesta = await fetch("https://localhost:44367/api/Queja_Reclamos", {
            method: comando,
            mode: "cors",
            headers: { "Content-type": "application/json" },
            body: JSON.stringify(datosQueja)
        });
        //Leer la respuesta y presentarla en el div
        const resultado = await respuesta.json();
        $("#dvMensaje").html(resultado);
    } catch (error) {
        $("#dvMensaje").html(error);
    }
}
