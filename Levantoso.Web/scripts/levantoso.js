var levantoso = (function () {
    var config = {
        urls: {
            gerarTabela: '',
            abrirForm: ''
        }
    };

    var init = function ($config) {
        config = $config;
    };

    var abrirFormulario = function (nome) {
        $.get(config.urls.abrirForm, { nome })
            .done(function (data) {
                $('#div-grid-tabela').append(data);
                $('#div-grid-tabela').show();
            })
            .fail(function (error) {
                console.error("Error fetching grid form content:", error);
            });
    }
    var adicionarDadosTabela = function (btn) {
        debugger;
        var item = $(btn).closest('form#form-tabela').find('select.form-control.input.item').val();
        var complexidade = $(btn).closest('form#form-tabela').find('select.form-control.input.complexidade').val();
        var descricao = $(btn).closest('form#form-tabela').find('textarea.form-control.input.descricao').val();
        var tableId = $(btn).closest('form#form-tabela').find('[data-table]').data('table');
        var newCell = '<tr>' +
                        '<td>' + item + '</td>' +
                        '<td>' + complexidade + '</td>' +
                        '<td>' + descricao + '</td>' +
                    '</tr>';

        $('table#' + tableId).append(newCell);
    }

    return {
        init: init,
        abrirFormulario: abrirFormulario,
        adicionarDadosTabela: adicionarDadosTabela
    };
})();
