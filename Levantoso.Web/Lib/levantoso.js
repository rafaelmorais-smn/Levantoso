var levantoso = (function () {
    var config = {
        urls: {
            abrirGrupo: '',
            novaLinhaGrid: '',
            exportarParaExcel: '',
            importandoArquivo: '',
            load: ''
        }
    };

    var localStorageName = 'levantoso';

    function carregaLocalStorageTela(conteudoLocalStorage) {
        $.ajax({
            type: 'POST',
            contentType: 'application/json',
            url: config.urls.load,
            data: JSON.stringify({ grupos: conteudoLocalStorage }),
            dataType: 'html'
        }).done(function (data) {
            $('#div-grid-tabela').append(data);
            $('#div-grid-tabela').show();
            $('#div-buton').show();
            $('#div-file').hide();
        }).fail(function() {
            console.log('Falha ao importar dados do local storage');
        });
    }

    var init = function ($config) {
        config = $config;
        $('#div-buton').hide();

        var conteudoLocalStorage = JSON.parse(localStorage.getItem(localStorageName));
        if (conteudoLocalStorage)
            carregaLocalStorageTela(conteudoLocalStorage);
    };

    var atribuirFocoNoInputDaModal = function (idInput) {
        setTimeout(function () {
            $('input#' + idInput).focus();
        }, 250);
    };

    function montaObjetoItemDeUmaTr(linha) {
        linha = $(linha);

        var colunaTipoOperacao = $(linha).find('td.tipo-operacao'),
            colunaItem = $(linha).find('td.item'),
            colunaComplexidade = $(linha).find('td.complexidade');

        return {
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
        };
    }

    function montaObjetoGeral() {
        var grupos = [];

        $('#grid-tabela table').each(function () {
            var tabela = $(this);

            var $grupo = {
                NomeGrupo: $(tabela).attr('id'),
                Itens: []
            };

            $(tabela).find('tbody tr').each(function () {
                $grupo.Itens.push(montaObjetoItemDeUmaTr($(this)));
            });

            grupos.push($grupo);
        });

        return grupos;
    }

    function atualizaConteudoLocalStorage() {
        var novoConteudo = montaObjetoGeral();
        localStorage.setItem(localStorageName, JSON.stringify(novoConteudo));
    }
        
    // GRUPOS ----------------------------------------------------------------------------------------- 
    var grupo = (function () {

        var listar = function (grupoDesconsiderar) {
            var $grupos = [];

            var seletor = 'div.quadro-grupo table.tabela-grupo';
            if (grupoDesconsiderar)
                seletor += ':not(#' + grupoDesconsiderar + ')';

            $(seletor).each(function () {
                $grupos.push($(this).attr('id'));
            });

            return $grupos;
        }

        function validarNovoGrupo(novoGrupo) {
            var $grupos = listar();
            if ($grupos.indexOf(novoGrupo) <= -1)
                return true;

            alert('Grupo já existente!');
            return false;
        }

        var inserir = function () {
            var nomeGrupo = $('#nomeGrupo').val();
            if (!validarNovoGrupo(nomeGrupo))
                return false;

            $.get(config.urls.abrirGrupo, {
                nomeGrupo: nomeGrupo
            }).done(function (data) {
                $('#div-grid-tabela').append(data).show();
                $('#div-file').hide();
                $('#div-buton').show();
                atualizaConteudoLocalStorage();
                setTimeout(function () {
                    $('select[data-table="' + nomeGrupo + '"].tipo-operacao').focus();
                    $('#nomeGrupo').val('');
                }, 200);
            }).fail(function (error) {
                console.error("Error fetching grid form content:", error);
            });
            return true;
        };

        var remover = function (btn) {
            if (!confirm('Tem certeza que deseja remover o grupo?'))
                return;

            $(btn).closest('div#container').remove();
            atualizaConteudoLocalStorage();
        };

        return {
            inserir: inserir,
            remover: remover,
            listar: listar
        }
    })();

    // ITENS ----------------------------------------------------------------------------------------- 
    var item = (function () {
        function validaInclusaoNovoItem(model) {
            var validacoes = [];

            if (!model.TipoOperacao.Value)
                validacoes.push('Selecione o tipo da operação');

            if (!model.Item.Value)
                validacoes.push('Selecione um item');

            if (!model.Complexidade.Value)
                validacoes.push('Selecione a complexidade');

            if (!model.Descricao)
                validacoes.push('Informe a descrição');

            if (!validacoes.length)
                return true;

            alert(validacoes.join('. '));
            return false;
        }

        function insereLinhaConsiderandoPosicaoAnterior(posicaoGrid, bodyTabela, linha) {
            if (posicaoGrid === 0)
                bodyTabela.prepend(linha);
            else if (posicaoGrid && posicaoGrid.toString().length > 0)
                bodyTabela.find('tr:eq(' + (+posicaoGrid - 1) + ')').after(linha);
            else
                bodyTabela.append(linha);

            atualizaConteudoLocalStorage();
        }

        var inserir = function (btn) {
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

            if (!validaInclusaoNovoItem(model))
                return false;

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
            }).fail(function (xhr) {
                console.error('Falha ao carregar nova linha pro grid:', xhr.responseText);
            });

            return true;
        };

        var remover = function (btn) {
            if (!confirm('Tem certeza que deseja remover o item?'))
                return;

            $(btn).closest('tr').remove();
            atualizaConteudoLocalStorage();
        };

        var editar = function (btn) {
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

        var mudarGrupo = function () {
            var tr = $('tr[item-que-sera-trocado]');
            var novoGrupo = $('select.grupos-disponiveis option:selected').text();
            if (!novoGrupo)
                return alert('Selecione o grupo de destino!');

            $('table#' + novoGrupo).find('tbody').append(tr);
            atualizaConteudoLocalStorage();
            return true;
        };

        return {
            inserir: inserir,
            remover: remover,
            editar: editar,
            mudarGrupo: mudarGrupo
        };

    })();

    // ARQUIVO ----------------------------------------------------------------------------------------- 
    var arquivo = (function() {

        function abrirDocumentoGerado(blob, nomeArquivo) {
            var url = window.URL.createObjectURL(blob),
                a = document.createElement('a');

            a.href = url;
            a.download = nomeArquivo + '.xlsx';
            document.body.appendChild(a);
            a.click();
            window.URL.revokeObjectURL(url);
            document.body.removeChild(a);
        }

        var gerar = function () {
            var nomeArquivo = $('#nomeArquivo').val(),
                $grupos = montaObjetoGeral();

            $.ajax({
                type: 'POST',
                contentType: 'application/json',
                url: config.urls.exportarParaExcel,
                data: JSON.stringify({
                    NomeArquivo: nomeArquivo,
                    Grupos: $grupos
                }),
                xhrFields: {
                    responseType: 'blob'
                }
            }).done(function (blob) {
                abrirDocumentoGerado(blob, nomeArquivo);
            }).fail(function (error) {
                console.log("Error fetching grid form content: " + error);
            });
        };

        var importar = function () {
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
                        $('#div-grid-tabela').append(data).show();
                        $('#div-buton').show();
                        $('#div-file').hide();
                        alert('Arquivo Importado Com Sucesso');
                        atualizaConteudoLocalStorage();
                    },
                    error: function (xhr) {
                        console.log('Falha ao importar arquivo: ' + xhr.responseText);
                    }
                });
            }
        }

        return {
            gerar: gerar,
            importar: importar
        };
    })();

    function carregaComboGruposDisponiveis(grupos) {
        var comboGruposDisponivel = $('select.grupos-disponiveis').empty().append('<option>Selecione</option>');

        grupos.forEach(function ($grupo) {
            var option = $('<option>',
                {
                    value: $grupo,
                    text: $grupo
                });
            comboGruposDisponivel.append(option);
        });
    }

    var abrirEscolhaNovoGrupo = function (btn) {
        $('tr[item-que-sera-trocado]').removeAttr('item-que-sera-trocado');
        $(btn).closest('tr').attr('item-que-sera-trocado', '');
        var grupos = grupo.listar($(btn).closest('table.tabela-grupo').attr('id'));
        carregaComboGruposDisponiveis(grupos);
        return true;
    };

    var limparTudo = function () {
        if (!confirm('Deseja realmente limpar todo o trabalho?'))
            return;

        localStorage.setItem(localStorageName, null);
        $('#div-grid-tabela').hide().empty();
        $('#div-file').show();
        $('#div-buton').hide();
    };

    return {
        init: init,
        grupo: grupo,
        item: item,
        arquivo: arquivo,
        atribuirFocoNoInputDaModal: atribuirFocoNoInputDaModal,
        abrirEscolhaNovoGrupo: abrirEscolhaNovoGrupo,
        limparTudo: limparTudo
    };
})();