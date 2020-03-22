
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

    /**********************************************
     * CREAR EMPLEADO
     * ********************************************/

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

    /**********************************************
     * EDITAR EMPLEADO
     * ********************************************/

    $('input#editar-maestranza').on('click', function () {
        quitarCheckedEditar();

        $('select#categorias').remove();

        var url = "/Home/ObtenerCategorias";
        var data = { idSector: sectores.maestranza };

        insertarCategorias(url, data);
    })

    $('input#editar-administrativo').on('click', function () {
        quitarCheckedEditar();

        $('select#categorias').remove();

        var url = "/Home/ObtenerCategorias";
        var data = { idSector: sectores.administrativo };

        insertarCategorias(url, data);
    })

    $('input#editar-cajero').on('click', function () {
        quitarCheckedEditar();

        $('select#categorias').remove();

        var url = "/Home/ObtenerCategorias";
        var data = { idSector: sectores.cajero };

        insertarCategorias(url, data);
    })

    $('input#editar-personal').on('click', function () {
        quitarCheckedEditar();

        $('select#categorias').remove();

        var url = "/Home/ObtenerCategorias";
        var data = { idSector: sectores.personal };

        insertarCategorias(url, data);
    })

    $('input#editar-auxiliar').on('click', function () {
        quitarCheckedEditar();

        $('select#categorias').remove();

        var url = "/Home/ObtenerCategorias";
        var data = { idSector: sectores.auxiliar };

        insertarCategorias(url, data);
    })

    $('input#editar-vendedor').on('click', function () {
        quitarCheckedEditar();

        $('select#categorias').remove();

        var url = "/Home/ObtenerCategorias";
        var data = { idSector: sectores.vendedor };

        insertarCategorias(url, data);
    })



    /**********************************************
     * FUNCIONES
     * ********************************************/

    function quitarChecked() {
        $('input#maestranza').removeAttr("checked");

        return false;
    }

    function quitarCheckedEditar() {
        $('input#editar-maestranza').removeAttr("checked");
        $('input#editar-administrativo').removeAttr("checked");
        $('input#editar-cajero').removeAttr("checked");
        $('input#editar-personal').removeAttr("checked");
        $('input#editar-auxiliar').removeAttr("checked");
        $('input#editar-vendedor').removeAttr("checked");
    }

    function insertarCategorias(url, data) {
        $.get(url, data).done(function (data) {
            $('div#lista-categorias').append(data);
        }).fail(function () {
            alert("Ha fallado");
        });
    }
})
