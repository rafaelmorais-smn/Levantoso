var levantoso = (function () {
    var config = {
        urls: {
            abrirGrupo: '',
            novaLinhaGrid: '',
            exportarParaExcel: '',
            importandoArquivo: ''
        }
    };

    var init = function ($config) {
        config = $config;
        $('#div-buton').hide();
    };

    var abrirGrupo = function () {
        var nomeGrupo = $('#nomeGrupo').val(); 
        $.get(config.urls.abrirGrupo, {
            nomeGrupo: nomeGrupo
        }).done(function(data) {
            $('#div-grid-tabela').append(data).show();
            $('#input-file, #div-file').hide();
            $('#div-buton').show();
            setTimeout(function () {
                $('select[data-table="' + nomeGrupo + '"].tipo-operacao').focus();
                $('#nomeGrupo').val('');
            }, 200);
        }).fail(function(error) {
            console.error("Error fetching grid form content:", error);
        });
    };

    var atribuirFocoNoInputDaModal = function(idInput) {
        setTimeout(function() {
            $('input#' + idInput).focus();
        }, 250);
    };

    var adicionarDadosTabela = function (btn) {
        var form = $(btn).closest('form#form-tabela');
        var comboTipoOperacao = form.find('select.tipo-operacao'),
            comboItem = form.find('select.item'),
            comboComplexidade = form.find('select.complexidade');

        var model = {
            TipoOperacao: {
                Value: +comboTipoOperacao.val(),
                Text: comboTipoOperacao.find('option:selected').text()
            },
            Item: {
                Value: +comboItem.val(),
                Text: comboItem.find('option:selected').text()
            },
            Complexidade: {
                Value: +comboComplexidade.val(),
                Text: comboComplexidade.find('option:selected').text()
            },
            Descricao: form.find('textarea.descricao').val()
        };

        if (!model.TipoOperacao.Value)
            return alert('Selecione o tipo da operação');

        if (!model.Item.Value)
            return alert('Selecione um item');

        if (!model.Complexidade.Value)
            return alert('Selecione a complexidade');

        if (!model.Descricao)
            return alert('Informe a descrição');

        $.ajax({
            type: 'POST',
            contentType: 'application/json',
            url: config.urls.novaLinhaGrid,
            data: JSON.stringify({ item: model }),
            dataType: 'html'
        }).done(function (newRow) {
            var posicaoGrid = form.data('posicao-grid'),
                bodyTabela = $(btn).closest('div.quadro-grupo').find('table tbody');
            insereLinhaConsiderandoPosicaoAnterior(posicaoGrid, bodyTabela, newRow);
            form.trigger('reset').data('posicao-grid', '');
            comboTipoOperacao.focus();
        }).fail(function(xhr) {
            console.error('Falha ao carregar nova linha pro grid:', xhr.responseText);
        });
    };

    function insereLinhaConsiderandoPosicaoAnterior(posicaoGrid, bodyTabela, linha) {
        if (posicaoGrid === 0)
            bodyTabela.prepend(linha);
        else if (posicaoGrid && posicaoGrid.toString().length > 0)
            bodyTabela.find('tr:eq(' + (+posicaoGrid - 1) + ')').after(linha);
        else
            bodyTabela.append(linha);
    }

    function lerTabela(tabela) {
        var grupo = {
            NomeGrupo: $(tabela).attr('id'),
            Itens: []
        };

        $(tabela).find('tbody tr').each(function() {
            var linha = $(this);
            var colunaTipoOperacao = $(linha).find('td.tipo-operacao'),
                colunaItem = $(linha).find('td.item'),
                colunaComplexidade = $(linha).find('td.complexidade');

            grupo.Itens.push({
                TipoOperacao: {
                    Value: colunaTipoOperacao.data('value'),
                    Text: colunaTipoOperacao.text()
                },
                Item: {
                    Value: colunaItem.data('value'),
                    Text: colunaItem.text()
                },
                Complexidade: {
                    Value: colunaComplexidade.data('value'),
                    Text: colunaComplexidade.text()
                },
                Descricao: $(linha).find('td.descricao').text(),
            });
        });

        return grupo;
    }

    function lerDadosTabela() {
        var grupos = [],
            nomeArquivo = $('#nomeArquivo').val();

        $('#grid-tabela table').each(function() {
            var tabela = $(this);
            grupos.push(lerTabela(tabela));
        });

        $.ajax({
            type: 'POST',
            contentType: 'application/json',
            url: config.urls.exportarParaExcel,
            data: JSON.stringify({
                NomeArquivo: nomeArquivo,
                Grupos: grupos
            }),
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
                    alert('Aquivo Importado Com Sucesso');
                },
                error: function (xhr) {
                    console.log('Falha ao importar arquivo: ' + xhr.responseText);
                }
            });
        }
    }

    var deletarItem = function(btn) {
        if (confirm('Tem certeza que deseja remover o item?'))
            $(btn).closest('tr').remove();
    };

    var editarItem = function(btn) {
        var tr = $(btn).closest('tr'),
            form = $(btn).closest('div.quadro-grupo').find('form#form-tabela');

        var posicaoGrid = tr.index();
        form.data('posicao-grid', posicaoGrid);

        ['tipo-operacao', 'item', 'complexidade'].forEach(function (seletorClasse) {
            form.find('select.' + seletorClasse).val(tr.find('td.' + seletorClasse).data('value'));
        });
        form.find('textarea.descricao').val(tr.find('td.descricao').text()).focus();
        tr.remove();
    };

    var apagarTabela = function (btn) {
        if (confirm('Tem certeza que deseja remover o grupo?'))
            $(btn).closest('div#container').remove();
    };

    return {
        init: init,
        abrirGrupo: abrirGrupo,
        adicionarDadosTabela: adicionarDadosTabela,
        lerDadosTabela: lerDadosTabela,
        importarArquivo: importarArquivo,
        deletarItem: deletarItem,
        editarItem: editarItem,
        apagarTabela: apagarTabela,
        atribuirFocoNoInputDaModal: atribuirFocoNoInputDaModal,
    };
})();
