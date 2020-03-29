
$(function () {
    'use strict';

    const url = "/Home/ObtenerMesEnLetras";
    let fechaDeposito = $('#ultimo-deposito').val().slice(3, 5);
    const data = { numero: fechaDeposito };

    insertarNombreMes(url, data);

    function insertarNombreMes(url, data) {
        $.get(url, data).done(function (data) {
            $('td#mes-ultimo-deposito').append(data);
        })
    }

    const urlNeto = "/Home/ObtenerNumeroEnLetras";
    const neto = $('#neto-numero').val();
    const dataNeto = { numero: neto };

    insertarNetoLetras(urlNeto, dataNeto);

    function insertarNetoLetras(urlNeto, dataNeto) {
        $.get(urlNeto, dataNeto).done(function (data) {
            $('td#neto-letras').append(data);
        })
    }

    //const urlAntiguedad = "/Home/ObtenerAntiguedad";
    //const fechaAntiguedad = $('#fechaAntiguedad').val();
    //const dataAntiguedad = { fecha: fechaAntiguedad };

    //insertarPorcentajeAntiguedad(urlAntiguedad, dataAntiguedad);

    //function insertarPorcentajeAntiguedad(urlAntiguedad, dataAntiguedad) {
    //    $.get(urlAntiguedad, dataAntiguedad).done(function (data) {
    //        $('td#antiguedad span').before(data);
    //        $('#antiguedad span').append("%");
    //    })
    //}
})