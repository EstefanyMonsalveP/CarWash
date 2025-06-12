var oTabla = $("#tblClientes").DataTable();


jQuery(function () {
    //Registrar los botones para responder al evento click
    $("#dvMenu").load("Menu.html");
    //Activar el evento de click en los botones que vamos a programar
    //Con jquery, los objetos se identifican con "$(#" al inicio del nombre del objeto
    LlenarTablaClientes()
   
    
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



async function LlenarTablaClientes() {
    LlenarTablaXServicios("https://localhost:44367/api/clientes", "#tblClientes");
}
async function Consultar() {
    let documento = $("#txtDocumento").val();
    try {
        const respuesta = await fetch("https://localhost:44367/api/clientes?Documento=" + documento, {
            method: "GET",
            mode: "cors",
            headers: { "Content-type": "application/json" },
        });

        const Resultado = await respuesta.json();
        $("#txtNombre").val(Resultado.NOMBRE);
        $("#txtApellido").val(Resultado.APELLIDO);
        $("#txtTelefono").val(Resultado.TELEFONO);
        $("#txtEmail").val(Resultado.EMAIL);
        $("#txtDireccion").val(Resultado.DIRECCION);
    } catch (error) {
        console.error("Error:", error);
        $("#dvMensaje").html('Error: ' + error.message);
    }
}


async function EjecutarComando(Comando) {
    //Capturar los datos de entrada
    let Documento = $("#txtDocumento").val();
    let Nombre = $("#txtNombre").val();
    let Apellido = $("#txtApellido").val();
    let Telefono = $("#txtTelefono").val();
    let Email = $("#txtEmail").val();
    let Direccion = $("#txtDireccion").val();

    let DatosCliente = {
        DOCUMENTO: Documento,
        NOMBRE: Nombre,
        APELLIDO: Apellido,
        TELEFONO: Telefono,
        EMAIL: Email,
        DIRECCION: Direccion,
    }

    try {
        const Respuesta = await fetch("https://localhost:44367/api/clientes",
            {
                method: Comando,
                mode: "cors",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(DatosCliente)
            });
        //Leer la respuesta y presentarla en el div
        const Resultado = await Respuesta.json();
        $("#dvMensaje").html(Resultado);
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}