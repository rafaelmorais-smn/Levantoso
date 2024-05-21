var levantoso = (function () {
    var config = {
        urls: {
            gerarTabela: '',
            abrirForm: '',
            exportarParaExcel: '',
            importandoArquivo: ''
        }
    };

    var init = function ($config) {
        config = $config;
        $('#div-buton').hide();
    };

    var abrirFormulario = function (nome) {
        $.get(config.urls.abrirForm, { nome })
            .done(function (data) {
                $('#div-grid-tabela').append(data);
                $('#div-grid-tabela').show();
                $('#input-file').hide();
                $('#div-buton').show();
                $('#div-file').hide();
            })
            .fail(function (error) {
                console.error("Error fetching grid form content:", error);
            });
    }
    const adicionarDadosTabela = function (btn) {
        const item = $(btn).closest('form#form-tabela').find('select.form-control.input.item option:selected').text();
        const idItem = $(btn).closest('form#form-tabela').find('select.form-control.input.item').val();
        const complexidade = $(btn).closest('form#form-tabela').find('select.form-control.input.complexidade option:selected').text();
        const idComplexidade = $(btn).closest('form#form-tabela').find('select.form-control.input.complexidade').val();
        const descricao = $(btn).closest('form#form-tabela').find('textarea.form-control.input.descricao').val();

        const tableId = $(btn).closest('form#form-tabela').find('[data-table]').data('table');
        const newCell = '<tr>' +
                        '<td data-idItem="'+ idItem +'">' + item + '</td>' +
                        '<td data-idComplexidade="' + idComplexidade + '">' + complexidade + '</td>' +
                        '<td>' + descricao + '</td>' +
                        '<td onclick="levantoso.deleteLinha(this)"><i class="material-icons">delete</i></td>'+
                    '</tr>';

        $('table#' + tableId).append(newCell);
    }

    function lerDadosTabela(nomeArquivo) {
        const tabelas = $("#grid-tabela table");
        const grupos = [];
        for (let tabela of tabelas) {
            const linhas = $(tabela).find("tbody tr");
            const nomeTabela = $(tabela).attr('id');

            const grupo = {
                NomeArquivo: nomeArquivo,
                NomeGrupo: nomeTabela,
                Itens: []
            };

            for (let linha of linhas) {
                const item = $(linha).find("td:first-child").text();
                const idItem = $(linha).find("td:first-child").data('iditem');
                const complexidade = $(linha).find("td:nth-child(2)").text();
                const idComplexidade = $(linha).find("td:nth-child(2)").data('idcomplexidade');
                const descricao = $(linha).find("td:last-child").text();

                grupo.Itens.push({
                    Item: item,
                    IdItem: idItem,
                    IdComplexidade: idComplexidade,
                    Complexidade: complexidade,
                    Descricao: descricao
                });
            }

            grupos.push(grupo);
            console.log(grupo);
        }

        $.ajax({
            type: 'POST',
            contentType: 'application/json',
            url: config.urls.exportarParaExcel,
            data: JSON.stringify(grupos)
        }).done(function(data) {}).fail(function(error) {
            console.log("Error fetching grid form content: " + error);
        });
    }

    function importarArquivo() {
        var file = $('#dataFile')[0].files[0];
        if (file) {
            var formData = new FormData();
            formData.append('file', file);
            $.ajax({
                url: config.urls.importandoArquivo,
                type: 'POST',
                data: formData,
                contentType: false,
                processData: false,
                success: function (data) {
                    $('#div-grid-tabela').append(data);
                    $('#div-grid-tabela').show();
                    $('#input-file').hide();
                    $('#div-buton').show();
                },
                error: function() {
                }
            });
        }
    }
    
    var deleteLinha = function(btn) {
        $(btn).closest('tr').remove();
    }
    return {
        init: init,
        abrirFormulario: abrirFormulario,
        adicionarDadosTabela: adicionarDadosTabela,
        lerDadosTabela: lerDadosTabela,
        importarArquivo: importarArquivo,
        deleteLinha: deleteLinha
    };
})();
