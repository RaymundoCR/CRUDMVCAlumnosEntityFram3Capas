//cunado el tipo de dato a enviar es un html no se selecciona nada en el data: de la funcion llamadoAjaxGEThtml
function llamadaAjaxGEThtml(urlAction, funcExito) {
    $.ajax({
        type: 'GET',
        url: urlAction,
        data: {},
        contenType: "application/json; charset=utf-8",
        dataType: "html",
        success: funcExito,
        error: errorGenerico
    });
}

function errorGenerico(jqXHR, exception) {
    var msg = '';
    if (jqXHR.status === 0) {
        msg = 'No está conectado, favor de verificar su conexión.';
    }
    else if (jqXHR.status === 404) {
        msg = 'Página no encontrada [404]';
    }
    else if (jqXHR.status === 500) {
        msg = 'Error en el servidor [500]';
    }
    else if (jqXHR.status === 'parseerror') {
        msg = 'El parseo del JSON es erróneo.';
    }
    else if (jqXHR.status === 'timeout') {
        msg = 'Error por tiempo de espera.';
    }
    else if (jqXHR.status === 'abort') {
        msg = 'La petición Ajax fue abortada.';
    }
    else {
        msg = 'Error no conocido. ' + jqXHR.responseText;
    }
    alert("Ajax error: " + msg);
}