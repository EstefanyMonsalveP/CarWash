jQuery(function () {
    //Registrar los botones para responder al evento click
    $("#dvMenu").load("Menu.html");
    LlenarComboCliente();
    LlenarComboServicio();
    LlenarComboEmpleados()
    LlenarTablaFactura();
    let today = new Date().toISOString()
    $('#txtFecha').val(today);
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

    $("#btnAñadir").on("click", function (event) {
        event.preventDefault();
        AñadirServicio();
    })
    
});

async function AñadirServicio() {
    //Captura el valor del servicio 
    const $select = $("#cboServicios");
    const value = $select.val(); //captura el value
    const descripcion = $select.find('option:selected').text()

    //Captura el txtArea
    let serviciosSeleccionados = $("#txtServicesSelected");

    const servicio = `${value} - ${descripcion}`;

    //Captura el valor actual del txtArea
    let textoActual = serviciosSeleccionados.val();

    //Agrega el nuevo servicio
    let nuevoTexto = textoActual ? textoActual + ";"+ '\n' + servicio : servicio;



    serviciosSeleccionados.val(nuevoTexto);
}

async function LlenarComboServicio() {
    LlenarComboXServicios("https://localhost:44367/api/Servicios", "#cboServicios")
}

async function LlenarComboEmpleados() {
    try {
        const Respuesta = await fetch("https://localhost:44367/api/empleados",
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                }
            });
        const Rpta = await Respuesta.json();
        //Se debe limpiar el combo
        $("#cboEmpleados").empty();
        //Se recorre en un ciclo para llenar el select con la información
        for (i = 0; i < Rpta.length; i++) {
            $("#cboEmpleados").append('<option value=' + Rpta[i].CEDULA + '>' + Rpta[i].CEDULA + "-" + Rpta[i].NOMBRE + " " + Rpta[i].APELLIDO + '</option>');
        }
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
}

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
        $("#cboClientes").empty();
        //Se recorre en un ciclo para llenar el select con la información
        for (i = 0; i < Rpta.length; i++) {
            $("#cboClientes").append('<option value=' + Rpta[i].DOCUMENTO + '>' + Rpta[i].DOCUMENTO + "-" + Rpta[i].NOMBRE + " " + Rpta[i].APELLIDO +'</option>');
        }
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
}

async function LlenarTablaFactura() {
    LlenarTablaXServicios("https://localhost:44367/api/Facturas", "#tblFactura");
}

async function Consultar() {
    let factura = $("#txtFactura").val();
    try {
        const respuesta = await fetch("https://localhost:44367/api/Facturas?idFactura=" + factura, {
            method: "GET",
            mode: "cors",
            headers: { "Content-type": "application/json" },
        });

        const resultado = await respuesta.json();

        $("#txtFecha").val(resultado.FECHA);
        $("#cboClientes").val(resultado.CEDULA_CLIENTE);
        $("#txtServicesSelected").val(resultado.SERVICIOS);
        $("#cboEmpleados").val(resultado.EMPLEADO_ATENCION);

    } catch (error) {
        $("#dvMensaje").html(error);
    }
}


async function EjecutarComando(comando) {
    /*Se capturan los datos de entrada del formulario HTML. Los valores de los campos del formulario se obtienen utilizando
    jQuery y se asignan a variables locales.*/
    let factura = $("#txtFactura").val();
    let fecha = $("#txtFecha").val();
    let cliente = $("#cboClientes").val();
    let servicios = $("#txtServicesSelected").val();
    let empleado = $("#cboEmpleados").val()

    //Construir la estructura JSON para enviar la información al servidor
    let datosFactura = {
        ID_FACTURA: factura,
        FECHA: fecha,
        CEDULA_CLIENTE: cliente,
        servicios: servicios,
        EMPLEADO_ATENCION: empleado
    }
    try {
        const respuesta = await fetch("https://localhost:44367/api/Facturas", {
            method: comando,
            mode: "cors",
            headers: { "Content-type": "application/json" },
            body: JSON.stringify(datosFactura)
        });
        //Leer la respuesta y presentarla en el div
        const resultado = await respuesta.json();
        $("#dvMensaje").html(resultado);
    } catch (error) {
        $("#dvMensaje").html(error);
    }
}