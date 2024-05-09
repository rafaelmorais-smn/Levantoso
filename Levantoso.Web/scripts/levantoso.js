var levantoso = (function () {
    var config = {
        urls: {
            abrirGrids: '',
        }
    };

    var init = function ($config) {
        config = $config;
    };

    var abrirGridForm = function () {
        $.get(config.urls.abrirGrids)
            .done(function (data) {
                $('#div-grid-form').html(data);
                $('#div-grid-form').show();
            })
            .fail(function (error) {
                console.error("Error fetching grid form content:", error);
            });
    };

    return {
        init: init,
        abrirGridForm: abrirGridForm,
    };
})();
