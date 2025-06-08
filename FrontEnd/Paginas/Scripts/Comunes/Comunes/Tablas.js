async function LlenarTablaXServicios(URLServicio, TablaLlenar) {
    //Invocamos el servicio a través del fetch, usando el método fetch de javascript
    try {
        const Respuesta = await fetch(URLServicio,
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                }
            });
        let Rpta = await Respuesta.json();

        //Verifica si la respuesta no es un array o es un array vacio
        //Mantiene las columnas de la tabla, limpia los datos y redibuja la tabla (Sin datos)
        if (!Array.isArray(Rpta) || Rpta.length === 0) {
            const tabla = $(TablaLlenar).DataTable();
            tabla.clear().draw();
            return;
        }


        //Se recorre en un ciclo para llenar la tabla, con encabezados y los campos
        //Llena el encabezado
        var Columnas = [];
        NombreColumnas = Object.keys(Rpta[0]);
        for (var i in NombreColumnas) {
            Columnas.push({
                data: NombreColumnas[i],
                title: NombreColumnas[i]
            });
        }

        //Llena los datos
        $(TablaLlenar).DataTable({
            data: Rpta,
            columns: Columnas,
            destroy: true
        });
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
    }