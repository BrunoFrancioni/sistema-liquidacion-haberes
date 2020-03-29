
$(function () {
    'use strict';

    const obrasSociales = {
        swiss: 1,
        osde: 2,
        galeno: 3
    };

    const bancos = {
        galicia: 1,
        macro: 2,
        santander: 3,
        bbva: 4,
        creadicoop: 5
    };

    // OBRAS SOCIALES

    $('input#swiss').on('click', function () {
        $('#idObraSocial').val(obrasSociales.swiss);
    })

    $('input#osde').on('click', function () {
        $('#idObraSocial').val(obrasSociales.osde);
    })

    $('input#galeno').on('click', function () {
        $('#idObraSocial').val(obrasSociales.galeno);
    })

    // BANCOS

    $('input#galicia').on('click', function () {
        $('#idBancos').val(bancos.galicia);
    })

    $('input#macro').on('click', function () {
        $('#idBancos').val(bancos.macro);
    })

    $('input#santander').on('click', function () {
        $('#idBancos').val(bancos.santander);
    })

    $('input#bbva').on('click', function () {
        $('#idBancos').val(bancos.bbva);
    })

    $('input#credicoop').on('click', function () {
        $('#idBancos').val(bancos.creadicoop);
    })

    // CATEGORÍAS

    $('input#1').on('click', function () {
        $('#idCategorias').val(1);
    })

    $('input#2').on('click', function () {
        $('#idCategorias').val(2);
    })

    $('input#3').on('click', function () {
        $('#idCategorias').val(3);
    })

    $('input#4').on('click', function () {
        $('#idCategorias').val(4);
    })

    $('input#5').on('click', function () {
        $('#idCategorias').val(5);
    })

    $('input#6').on('click', function () {
        $('#idCategorias').val(6);
    })

    $('input#7').on('click', function () {
        $('#idCategorias').val(7);
    })

    $('input#8').on('click', function () {
        $('#idCategorias').val(8);
    })

    $('input#9').on('click', function () {
        $('#idCategorias').val(9);
    })

    $('input#10').on('click', function () {
        $('#idCategorias').val(10);
    })

    $('input#11').on('click', function () {
        $('#idCategorias').val(11);
    })

    $('input#12').on('click', function () {
        $('#idCategorias').val(12);
    })

    $('input#13').on('click', function () {
        $('#idCategorias').val(13);
    })

    $('input#14').on('click', function () {
        $('#idCategorias').val(14);
    })

    $('input#15').on('click', function () {
        $('#idCategorias').val(15);
    })

    $('input#16').on('click', function () {
        $('#idCategorias').val(16);
    })

    $('input#17').on('click', function () {
        $('#idCategorias').val(17);
    })

    $('input#18').on('click', function () {
        $('#idCategorias').val(18);
    })

    $('input#19').on('click', function () {
        $('#idCategorias').val(19);
    })

    $('input#20').on('click', function () {
        $('#idCategorias').val(20);
    })

    $('input#21').on('click', function () {
        $('#idCategorias').val(21);
    })
})