using Levantoso.Domain.Lists;
using Levantoso.Domain.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Levantoso.Domain.Excel
{
    public static class LeitorExcel
    {
        private static byte _linha;
        private static bool _umaLinhaVazia;
        private static bool _duasLinhasVazias;
        private static Collection<GrupoModel> _grupos;
        private static readonly IEnumerable<ComboItem> TiposOperacoes = TipoOperacaoList.ComboValues.Where(x => x.Value > 0);
        private static readonly IEnumerable<ComboItem> Itens = ItemList.ComboValues.Where(x => x.Value > 0);
        private static readonly IEnumerable<ComboItem> Complexidades = ComplexidadeList.ComboValues.Where(x => x.Value > 0);

        public static IEnumerable<GrupoModel> Processar(Stream file)
        {
            if (file == null)
                return null;

            using (var ep = new ExcelPackage(file))
                return Processar(ep);
        }

        public static IEnumerable<GrupoModel> Processar(FileInfo file)
        {
            if (file == null)
                return null;

            using (var ep = new ExcelPackage(file))
                return Processar(ep);
        }

        private static IEnumerable<GrupoModel> Processar(ExcelPackage ep)
        {
            var ws = ep.Workbook.Worksheets["Itens"];
            IniciaVariaveisTrabalho();
            if (ws == null || ws.Dimension.Rows < 2)
                return _grupos;

            while (!ws.Cells[_linha, 1].Text.Contains("fim") && !_duasLinhasVazias)
            {
                if (ws.Cells[_linha, 1] == null)
                {
                    _linha += 1;
                    continue;
                }

                var grupo = RecuperaGrupo(ws.Cells[_linha, 1]);
                var codigoItem = ws.Cells[_linha, 1].Text;
                if (!codigoItem.ValidaLinhaVazia())
                    continue;

                var itemLevantamento = codigoItem.MontaItemLevantamento(ws.Cells[_linha, 2].Text);
                grupo.Itens.Add(itemLevantamento);
                _linha += 1;
            }
            return _grupos;
        }

        private static void IniciaVariaveisTrabalho()
        {
            _linha = 2;
            _umaLinhaVazia = false;
            _duasLinhasVazias = false;
            _grupos = new Collection<GrupoModel>();
        }

        private static GrupoModel RecuperaGrupo(ExcelRangeBase celula)
        {
            return celula.Style.Font.Bold ? CriaNovoGrupo(celula.Text) : _grupos.Last();
        }

        private static GrupoModel CriaNovoGrupo(string nomeGrupo)
        {
            var grupo = new GrupoModel(nomeGrupo);
            _grupos.Add(grupo);
            _linha += 1;
            _umaLinhaVazia = false;
            return grupo;
        }

        private static bool ValidaLinhaVazia(this string textoCelula)
        {
            if (string.IsNullOrEmpty(textoCelula))
            {
                if (_umaLinhaVazia)
                    _duasLinhasVazias = true;
                else
                    _umaLinhaVazia = true;

                _linha += 1;
                return false;
            }

            _umaLinhaVazia = false;
            return true;
        }

        private static ItemLevantamentoModel MontaItemLevantamento(this string codigoItem, string descricaoItem)
        {
            var partesDescricaoItem = codigoItem.Split(';');
            if (partesDescricaoItem.Length < 3)
                throw new Exception($"Item não identificado: {codigoItem}");

            var idTipoOperacao = byte.Parse(partesDescricaoItem[0]);
            var idItem = byte.Parse(partesDescricaoItem[1]);
            var idComplexidade = byte.Parse(partesDescricaoItem[2]);

            var tipoOperacaoCombo = TiposOperacoes.FirstOrDefault(x => x.Value == idTipoOperacao);
            var itemCombo = Itens.FirstOrDefault(x => x.Value == idItem);
            var complexidadeCombo = Complexidades.FirstOrDefault(x => x.Value == idComplexidade);

            descricaoItem = descricaoItem.Replace($"{tipoOperacaoCombo.Text} de", "");
            descricaoItem = descricaoItem.Replace(itemCombo.Text, "");
            descricaoItem = descricaoItem.Replace(complexidadeCombo.Text, "");
            descricaoItem = descricaoItem.Trim();
            return new ItemLevantamentoModel(tipoOperacaoCombo, itemCombo, complexidadeCombo, descricaoItem);
        }
    }
}
