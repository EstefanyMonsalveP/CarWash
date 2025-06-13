jQuery(function () {
    //Registrar los botones para responder al evento click
    $("#dvMenu").load("Menu.html");
    LlenarComboCliente();
    LlenarComboServicio();
    LlenarComboEmpleados()
    LlenarComboMetodoPago();
    LlenarTablaFactura();
    
    let today = new Date().toISOString()
    $('#txtFecha').val(today);

    $("#btnAñadir").on("click", function (event) {
        event.preventDefault();
        AñadirServicio();
    })

    //Remueve la clase seleccionado de todos los servicios y se agrega unicamente al seleccionado
    $("#listaServicios").on("click", ".servicio", function () {
        $(".servicio").removeClass("seleccionado");
        $(this).addClass("seleccionado");
    })

    $("#btnRetirar").on("click", function (event) {
        event.preventDefault();
        RetirarServicio();
    })

    $("#btnInsertar").on("click", function () {
        EjecutarComando("POST");
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
        $("#cboClientes").empty();
        //Se recorre en un ciclo para llenar el select con la información
        for (i = 0; i < Rpta.length; i++) {
            $("#cboClientes").append('<option value=' + Rpta[i].DOCUMENTO + '>' + Rpta[i].DOCUMENTO + "-" + Rpta[i].NOMBRE + " " + Rpta[i].APELLIDO + '</option>');
        }
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
}

async function LlenarComboServicio() {
    try {
        const Respuesta = await fetch("https://localhost:44367/api/Servicios",
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                }
            });
        const Rpta = await Respuesta.json();
        //Se debe limpiar el combo
        $("#cboServicios").empty();
        //Se recorre en un ciclo para llenar el select con la información
        for (let i = 0; i < Rpta.length; i++) {
            $("#cboServicios").append('<option value="' + Rpta[i].ID + '" data-precio="' + Rpta[i].VALOR + '">' + Rpta[i].DESCRIPCION + " - " + "VAL.UNIDAD: $ " + Rpta[i].VALOR + '</option>');
        }
    } catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
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

async function LlenarComboMetodoPago() {
    try {
        const Respuesta = await fetch("https://localhost:44367/api/FormasPago",
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                }
            });
        const Rpta = await Respuesta.json();
        //Se debe limpiar el combo
        $("#cboMetodoPago").empty();
        //Se recorre en un ciclo para llenar el select con la información
        for (i = 0; i < Rpta.length; i++) {
            $("#cboMetodoPago").append('<option value=' + Rpta[i].ID_PAGO + '>' + Rpta[i].DESCRIPCION_PAGO + '</option>');
        }
    } catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
}

async function LlenarTablaFactura() {
    LlenarTablaXServicios("https://localhost:44367/api/Facturas", "#tblFactura");
}

//Añade el servicio a la factura
async function AñadirServicio() {
    
    const $select = $("#cboServicios");//Captura el cbo
    const value = $select.val(); //captura el value
    const $option = $select.find('option:selected')
    const descripcion = $option.text() //Captura la opcion asociada al value
    const cantidad = $("#numCantidad").val();
    const precio = $option.data('precio'); 
    if (cantidad == "") {
        alert("seleccione la cantidad");
        return
    }
    
    const servicio = `${value} - ${descripcion} - CANT: ${cantidad} - VALOR_UNIDAD: ${precio}`; //Une el value y la opcion
    const $div = $('<div></div>') //Crea un div
        .addClass('servicio')//Agrega la clase 
        .text(servicio) //Agrega el texto en la variable del servicio
        .attr('data-id', value) //Crea el atributo para capturar el id 
        .attr('data-cantidad', cantidad)//Crea el atributo para capturar la cantidad 
        .attr('data-precio', precio);//Crea el atributo para capturar el precio

    $('#listaServicios').append($div);

    ValorApagar();
}

//Elimina el servicio de la factura
async function RetirarServicio() {
    $('.servicio.seleccionado').remove()
    ValorApagar();
}

async function ValorApagar() {
    let acumulador = 0;
    try {
        $("#listaServicios .servicio").each(function () {
            const cantidad = parseInt($(this).attr("data-cantidad"));
            const precio = parseInt($(this).attr("data-precio"));
            let valorTotal = cantidad * precio;
            acumulador += valorTotal;
        })
        $("#numValorTotal").val(acumulador);
        return acumulador;   
    }catch (error) {
        $("#dvMensaje").html(error);
    }
    
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
        $("#numValorTotal").val(resultado.VALOR_TOTAL);
        $("#cboEmpleados").val(resultado.EMPLEADO_ATENCION);

    } catch (error) {
        $("#dvMensaje").html(error);
    }
}

//Ejecuta los comandos PUT, POST, GET 
async function EjecutarComando(comando) {
    /*Se capturan los datos de entrada del formulario HTML. Los valores de los campos del formulario se obtienen utilizando
    jQuery y se asignan a variables locales.*/
    let factura = $("#txtFactura").val();
    let fecha = $("#txtFecha").val();
    let cliente = $("#cboClientes").val();
    let metodoPago = $("#cboMetodoPago").val();
    let valorTotal = $("#numValorTotal").val();
    let empleado = $("#cboEmpleados").val()

    //Datos de factura
    let facturacion = { 
        ID_FACTURA: factura,
        FECHA: fecha,
        CEDULA_CLIENTE: cliente,
        FORMA_PAGO: metodoPago,
        VALOR_TOTAL: valorTotal,
        EMPLEADO_ATENCION: empleado
    }

    //Datos de servicio
    let servicios = [];

    $("#listaServicios .servicio").each(function () {
        servicios.push({
            ID_SERVICIO: parseInt($(this).attr("data-id")),
            CANTIDAD: parseInt($(this).attr("data-cantidad"))
        })
    })

    //Objeto de datos 
    const datosFactura = {
        Factura: facturacion,
        Servicios: servicios
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