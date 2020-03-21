
$(function () {
    'use strict';

    const sectores = {
        maestranza: 1,
        administrativo: 2,
        cajero: 3,
        personal: 4,
        auxiliar: 4,
        vendedor: 6
    };

    $('input#maestranza').on('click', function () {
        $('#categorias').removeData();

        var url = "/Home/ObtenerCategorias";
        var data = { idSector: sectores.maestranza };

        insertarCategorias(url, data);

    })

    $('input#administrativo').on('click', function () {
        quitarChecked();

        $('select#categorias').remove();

        var url = "/Home/ObtenerCategorias";
        var data = { idSector: sectores.administrativo };

        insertarCategorias(url, data);
    })

    $('input#cajero').on('click', function () {
        quitarChecked();

        $('select#categorias').remove();

        var url = "/Home/ObtenerCategorias";
        var data = { idSector: sectores.cajero };

        insertarCategorias(url, data);
    })

    $('input#personal').on('click', function () {
        quitarChecked();

        $('select#categorias').remove();

        var url = "/Home/ObtenerCategorias";
        var data = { idSector: sectores.personal };

        insertarCategorias(url, data);
    })

    $('input#auxiliar').on('click', function () {
        quitarChecked();

        $('select#categorias').remove();

        var url = "/Home/ObtenerCategorias";
        var data = { idSector: sectores.auxiliar };

        insertarCategorias(url, data);
    })

    $('input#vendedor').on('click', function () {
        quitarChecked();

        $('select#categorias').remove();

        var url = "/Home/ObtenerCategorias";
        var data = { idSector: sectores.vendedor };

        insertarCategorias(url, data);
    })


    function quitarChecked() {
        $('input#maestranza').removeAttr("checked");

        return false;
    }

    function insertarCategorias(url, data) {
        $.get(url, data).done(function (data) {
            $('div#lista-categorias').append(data);
        }).fail(function () {
            alert("Ha fallado");
        });
    }
})
