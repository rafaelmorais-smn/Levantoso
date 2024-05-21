
using Levantoso.Web.Lists;
using Levantoso.Web.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Levantoso.Excel
{
    public static class LeitorExcel
    {
        private static byte _linha;
        private static bool _umaLinhaVazia;
        private static bool _duasLinhasVazias;
        private static Collection<GrupoModel> _grupos;
        private static readonly IEnumerable<ComboItem> Itens = ItemList.ComboValues.Where(x => x.Value > 0);
        private static readonly IEnumerable<ComboItem> Complexidades = ComplexidadeList.ComboValues.Where(x => x.Value > 0);

        public static IEnumerable<GrupoModel> Processar(HttpPostedFileBase file)
        {
            var stream = file.InputStream;
            using (var ep = new ExcelPackage(stream))
            {
                var ws = ep.Workbook.Worksheets["Itens"];
                IniciaVariaveisTrabalho();
                if (ws != null && ws.Dimension.Rows >= 2)
                {
                    while (!ws.Cells[_linha, 1].Text.Contains("fim") && !_duasLinhasVazias)
                    {
                        if (ws.Cells[_linha, 1] != null)
                        {
                            var grupo = RecuperaGrupo(ws.Cells[_linha, 1]);
                            var codigoItem = ws.Cells[_linha, 1].Text;
                            if (!codigoItem.ValidaLinhaVazia())
                            {
                                continue;
                            }
                            var itemLevantamento = codigoItem.MontaItemLevantamento(ws.Cells[_linha, 2].Text);
                            grupo.Itens.Add(itemLevantamento);
                        }
                        _linha += 1;
                    }
                }
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
            var grupo = new GrupoModel(nomeGrupo, "");
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
            if (codigoItem.Length < 3)
                throw new Exception("Item desconhecido");

            var idItem = byte.Parse(codigoItem.Substring(0, 2));
            var idComplexidade = byte.Parse(codigoItem[2].ToString());

            var itemCombo = Itens.FirstOrDefault(x => x.Value == idItem).ToString();
            var complexidadeCombo = Complexidades.FirstOrDefault(x => x.Value == idComplexidade).ToString();

            var resultado = new ItemLevantamentoModel(itemCombo, idItem, complexidadeCombo, idComplexidade, descricaoItem);

            return resultado;
        }
    }
}
