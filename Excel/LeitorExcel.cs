using Levantoso.Lists;
using Levantoso.Models;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

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

        public static IEnumerable<GrupoModel> Processar(FileInfo file)
        {
            using (var ep = new ExcelPackage(file))
            {
                var ws = ep.Workbook.Worksheets["Itens"];
                IniciaVariaveisTrabalho();

                while (!ws.Cells[_linha, 1].Text.Contains("fim") && !_duasLinhasVazias)
                {
                    var grupo = RecuperaGrupo(ws.Cells[_linha, 1]);

                    var codigoItem = ws.Cells[_linha, 1].Text;
                    
                    if (!codigoItem.ValidaLinhaVazia())
                        continue;

                    var itemLevantamento = codigoItem.MontaItemLevantamento(ws.Cells[_linha, 2].Text);
                    grupo.Itens.Add(itemLevantamento);
                    _linha += 1;
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
            codigoItem = codigoItem.PadLeft(3, '0');

            var item = byte.Parse(codigoItem.Substring(0, 2));
            var complexidade = byte.Parse(codigoItem[2].ToString());

            var itemCombo = Itens.FirstOrDefault(x => x.Value == item);
            var complexidadeCombo = Complexidades.FirstOrDefault(x => x.Value == complexidade);
            return new ItemLevantamentoModel(itemCombo, complexidadeCombo, descricaoItem);
        }
    }
}
