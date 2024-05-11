using Levantoso.Lists;
using Levantoso.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace Levantoso.Excel
{
    public static class GeradorExcel
    {
        public static byte[] Gerar(IEnumerable<GrupoModel> grupos)
        {
            using (var ep = new ExcelPackage())
            {
                using (var modelo = System.IO.File.OpenRead($@"{AppDomain.CurrentDomain.BaseDirectory}\Excel\Modelo.xlsx"))
                    ep.Load(modelo);

                ep.MontaAbaHoras(grupos);
                ep.MontaAbaItens(grupos);
                return ep.GetAsByteArray();
            }
        }

        private static void MontaAbaHoras(this ExcelPackage ep, IEnumerable<GrupoModel> grupos)
        {
            var ws = ep.Workbook.Worksheets["Levantamento de horas"];

            var itens = ItemList.ComboValues.Where(x => x.Value > 0).Select(x => x.Value);
            var complexidades = ComplexidadeList.ComboValues.Where(x => x.Value > 0).Select(x => x.Value);
            
            var quantidadesGrupo = new Collection<Tuple<string, Collection<ItemLevantamentoAgrupadoModel>>>();
            foreach (var grupo in grupos)
                quantidadesGrupo.Add(new Tuple<string, Collection<ItemLevantamentoAgrupadoModel>>(grupo.NomeGrupo, ProcessaQuantidades(grupo, itens, complexidades)));

            ws.DuplicaQuadros((byte)grupos.Count());
            for (byte i = 0; i < quantidadesGrupo.Count; i++)
            {
                var grupo = quantidadesGrupo.ElementAt(i);
                ws.PreecheQuantidadesGrupo(i, grupo.Item1, grupo.Item2);
            }
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
            if (quantidade <= 1)
                return;

            var parteCopiada = ws.Cells["A2:H18"];
            for (var i = 1; i < quantidade; i++)
            {
                var linhaColagem = 20 * i;
                parteCopiada.Copy(ws.Cells[$"A{linhaColagem}"]);
            }
        }

        private static void PreecheQuantidadesGrupo(this ExcelWorksheet ws, byte numeroGrupo, string nomeGrupo, IEnumerable<ItemLevantamentoAgrupadoModel> grupo)
        {
            var linhaInicio = 20 * numeroGrupo;
            if (linhaInicio == 0)
                linhaInicio = 2;

            ws.Cells[linhaInicio + 3, 1].Value = nomeGrupo;

            foreach (var item in grupo.OrderBy(x => x.CodigoItem).ThenBy(x => x.CodigoComplexidade))
                ws.Cells[linhaInicio + 3 + item.CodigoItem, item.CodigoComplexidade + 2].Value = item.Quantidade;
        }

        private static void MontaAbaItens(this ExcelPackage ep, IEnumerable<GrupoModel> grupos)
        {
            var ws = ep.Workbook.Worksheets["Itens"];
            var linha = 0;

            foreach (var grupo in grupos)
            {
                linha += 2;
                var celulaTituloGrupo = ws.Cells[linha, 1];
                celulaTituloGrupo.Value = grupo.NomeGrupo;
                celulaTituloGrupo.Style.Font.Bold = true;

                foreach (var itemLevantamento in grupo.Itens)
                {
                    linha += 1;
                    var celularCodigo = ws.Cells[linha, 1];
                    celularCodigo.Value = $"{itemLevantamento.Item.Value}{itemLevantamento.Complexidade.Value}";
                    celularCodigo.Style.Font.Color.SetColor(Color.White);

                    ws.Cells[linha, 2].Value = $"{itemLevantamento.Item.Text} {itemLevantamento.Complexidade.Text} {itemLevantamento.Descricao}";
                }
            }
        }
    }
}
