using Levantoso.Lists;
using Levantoso.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Levantoso.Excel
{
    public static class GeradorExcel
    {
        public static ExcelPackage Gerar(IEnumerable<GrupoModel> grupos)
        {
            using (var ep = new ExcelPackage())
            {
                using (var modelo = System.IO.File.OpenRead($@"{AppDomain.CurrentDomain.BaseDirectory}\Excel\Modelo.xlsx"))
                    ep.Load(modelo);

                ep.MontaAbaHoras(grupos);
                ep.MontaAbaItens(grupos);
                return ep;
                //DownloadReport(ep.GetAsByteArray());
            }
        }

        private static void MontaAbaHoras(this ExcelPackage ep, IEnumerable<GrupoModel> grupos)
        {
            var ws = ep.Workbook.Worksheets["Levantamento de horas"];

            var itens = ItemList.ComboValues.Select(x => x.Value);
            var complexidades = ComplexidadeList.ComboValues.Select(x => x.Value);

            var quantidadesGrupo = new Collection<Tuple<string, Collection<ItemLevantamentoAgrupadoModel>>>();
            foreach (var grupo in grupos)
                quantidadesGrupo.Add(new Tuple<string, Collection<ItemLevantamentoAgrupadoModel>>(grupo.NomeGrupo, ProcessaQuantidades(grupo, itens, complexidades)));

            ws.DuplicaQuadros((byte)grupos.Count());
        }

        private static Collection<ItemLevantamentoAgrupadoModel> ProcessaQuantidades(GrupoModel grupo, IEnumerable<byte> codigosItens, IEnumerable<byte> codigosComplexidades)
        {
            var itensGrupo = new Collection<ItemLevantamentoAgrupadoModel>();
            foreach (var codigoItem in codigosItens)
                foreach (var codigoComplexidade in codigosComplexidades)
                {
                    var quantidade = (byte)grupo.Itens.Count(x => x.Item.Value == codigoItem && x.Complexidade.Value == codigoComplexidade);
                    itensGrupo.Add(new ItemLevantamentoAgrupadoModel(codigoItem, codigoComplexidade, quantidade));
                }

            return itensGrupo;
        }

        private static void DuplicaQuadros(this ExcelWorksheet ws, byte quantidade)
        {
            var parteCopiada = ws.Cells["A2:H18"];
            for (var i = 1; i <= quantidade; i++)
            {
                var linhaColagem = 20 * i;
                parteCopiada.Copy(ws.Cells[$"A{linhaColagem}:H{(linhaColagem + 20)}"]);
            }
        }

        private static void PreecheQuantidadesGrupo(this ExcelWorksheet ws, string nomeGrupo, IEnumerable<ItemLevantamentoAgrupadoModel> grupo)
        {
            foreach (var itemLevantamentoAgrupadoModel in grupo)
            {
                
            }
        }

        private static void MontaAbaItens(this ExcelPackage ep, IEnumerable<GrupoModel> grupos)
        {
            var ws = ep.Workbook.Worksheets["Itens"];

        }
    }
}
