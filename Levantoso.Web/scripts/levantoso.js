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
                $('#nomeGrupo').val('');
            })
            .fail(function (error) {
                console.error("Error fetching grid form content:", error);
            });
    }
    const adicionarDadosTabela = function (btn) {
        const form = $(btn).closest('form#form-tabela');
        const table = $(btn).closest('div#grid-tabela').find('table').find('tbody');
        const item = $(btn).closest('form#form-tabela').find('select.form-control.input.item option:selected').text();
        const idItem = $(btn).closest('form#form-tabela').find('select.form-control.input.item').val();
        const complexidade = $(btn).closest('form#form-tabela').find('select.form-control.input.complexidade option:selected').text();
        const idComplexidade = $(btn).closest('form#form-tabela').find('select.form-control.input.complexidade').val();
        const descricao = $(btn).closest('form#form-tabela').find('textarea.form-control.input.descricao').val();

        if (idItem === "0")
            return alert('Selecione um item'); 
        if (idComplexidade === "0")
            return alert('Selecione uma Complexidade');

        const newCell = '<tr>' +
                        '<td id="item" data-idItem="' + idItem + '">' + item + '</td>' +
                        '<td id="complexidade" data-idComplexidade="' + idComplexidade + '">' + complexidade + '</td>' +
                        '<td id="descricao">' + descricao + '</td>' +
                        '<td onclick="levantoso.editarLinhas(this)"><i class="material-icons">edit</i></td>' +
                        '<td onclick="levantoso.deleteLinha(this)"><i class="material-icons">delete</i></td>' +
                    '</tr>';
            table.append(newCell);
            form.find('textarea').val('');
            form.find('select.form-control [value="0"]').prop('selected', true);

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
                const descricao = $(linha).find("td:nth-child(3)").text();

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
            data: JSON.stringify(grupos),
            xhrFields: {
                responseType: 'blob'
            }
        }).done(function (blob) {
            var url = window.URL.createObjectURL(blob);
            var a = document.createElement('a');
            a.href = url;
            a.download = nomeArquivo + ".xlsx";
            document.body.appendChild(a);
            a.click();
            window.URL.revokeObjectURL(url);
            document.body.removeChild(a);
        }).fail(function (error) {
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
                    $('#div-file').hide();
                    alert("Aquivo Importado Com Sucesso");
                },
                error: function() {
                }
            });
        }
    }
    
    var deleteLinha = function(btn) {
        $(btn).closest('tr').remove();
    }

    var editarLinhas = function(btn) {
        const item = $(btn).closest('tr').find('#item').data('iditem');
        const complexidade = $(btn).closest('tr').find('#complexidade').data('idcomplexidade');
        const descricao = $(btn).closest('tr').find('#descricao').text();

        $(btn).closest('div#container').find('form#form-tabela select.form-control.input.item').val(item);
        $(btn).closest('div#container').find('form#form-tabela').find('select.form-control.input.complexidade').val(complexidade);
        $(btn).closest('div#container').find('form#form-tabela').find('textarea.form-control.input.descricao').val(descricao);
        $(btn).closest('tr').remove();
    }

    var apagarTabela = function(btn) {
        $(btn).closest('div#container').remove();
    }
    return {
        init: init,
        abrirFormulario: abrirFormulario,
        adicionarDadosTabela: adicionarDadosTabela,
        lerDadosTabela: lerDadosTabela,
        importarArquivo: importarArquivo,
        deleteLinha: deleteLinha,
        editarLinhas: editarLinhas,
        apagarTabela: apagarTabela
    };
})();
