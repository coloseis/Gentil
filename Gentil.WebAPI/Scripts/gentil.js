$.extend($.fn.dataTable.defaults, {
    searching: false,
    ordering: false,
    bLengthChange: false,
    pagingType: 'full_numbers',
    language: {
        emptyTable: "No hay información disponible",
        loadingRecords: "Cargando...",
        processing: "Procesando...",
        lengthMenu: "Filas por página: _MENU_",
        zeroRecords: "Sin resultados",
        info: "Página _PAGE_ de _PAGES_",
        infoEmpty: "Sin resultados",
        paginate: {
            first: "Primero",
            last: "Último",
            next: "Siguiente",
            previous: "Anterior"
        }
    }
});