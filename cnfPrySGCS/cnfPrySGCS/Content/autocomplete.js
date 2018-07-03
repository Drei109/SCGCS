$(document).ready(function () {

    $("#MEF").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/cnfCambios/cnfClsSolicitud/CargarMetodologiaFase",
                dataType: "json",
                data: { term: request.term, pryCod: $("#PRYcodigo").val(), maxResults: 10 },
                minLength: 0,
                success: function (data) {
                    response($.map(data,
                        function (item) {
                            return { label: item.nombre, value: item.nombre, id: item.id };
                        }));
                }
            });
        },
        select: function (event, ui) {
            $("#MEFcodigo").val(ui.item.id);
        }
    }).focus(function () {
        $(this).autocomplete("search", " ");
        });

    $("#PLB").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/cnfCambios/cnfClsSolicitud/CargarComboLineaBase",
                dataType: "json",
                data: { mefCod: $("#MEFcodigo").val(), maxResults: 10 },
                minLength: 0,
                success: function (data) {
                    response($.map(data,
                        function (item) {
                            return { label: item.nombre, value: item.nombre, id: item.id };
                        }));
                }
            });
        },
        select: function (event, ui) {
            $("#PLBcodigo").val(ui.item.id);
        }
    }).focus(function () {
        $(this).autocomplete("search", " ");
    });


    $("#PEC").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/cnfCambios/cnfClsSolicitud/CargarComboElementoConfiguracion",
                type: "GET",
                dataType: "json",
                data: { term: request.term, pryCod: $("#PRYcodigo").val(), mefCod: $("#MEFcodigo").val(), mntCod: $("#MNTcodigo").val(), maxResults: 10 },
                minLength: 0,
                success: function (data) {
                    response($.map(data,
                        function (item) {
                            return { label: item.nombre, value: item.nombre, id: item.id };
                        }));
                }
            });
        },
        select: function (event, ui) {
            $("#PECcodigo").val(ui.item.id);
        }
    }).focus(function () {
            $(this).autocomplete("search", " ");
        });

    $("#MNT").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/cnfCambios/cnfClsSolicitud/CargarComboEntregable",
                type: "GET",
                dataType: "json",
                data: { term: request.term, mefCod: $("#MEFcodigo").val(), maxResults: 10 },
                minLength: 0,
                success: function (data) {
                    response($.map(data,
                        function (item) {
                            return { label: item.nombre, value: item.nombre, id: item.id };
                        }));    
                }
            });
        },
        select: function (event, ui) {
            $("#MNTcodigo").val(ui.item.id);
        }
    }).focus(function () {
        $(this).autocomplete("search", " ");
        });


});