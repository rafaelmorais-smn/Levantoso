using Levantoso.Excel;
using Levantoso.Forms.Group;
using Levantoso.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Levantoso.Forms
{
    public partial class MainForm : Form
    {
        public readonly List<Tuple<byte, GroupTable>> Grupos = new List<Tuple<byte, GroupTable>>();
        private const string DiretorioGeracaoArquivo = @"C:\Levantoso\";

        public MainForm()
        {
            InitializeComponent();
        }

        public void AbrirGroup(string nomeGrupo)
        {
            if (Grupos.Any(x => x.Item2.NomeGrupo == nomeGrupo))
            {
                MessageBox.Show(@"Grupo já existente!");
                return;
            }

            var sequencialGrupo = (byte)(Grupos.Any() ? Grupos.Max(x => x.Item1) + 1 : 1);
            var groupTable = new GroupTable(nomeGrupo, sequencialGrupo)
            {
                Top = RecuperaPosicaoUltimoGrupo() + 10
            };

            groupTable.AjustaLargura(Width);
            Height += groupTable.Height + 10;
            Controls.Add(groupTable);
            Grupos.Add(new Tuple<byte, GroupTable>(sequencialGrupo, groupTable));
            groupTable.Show();
        }

        private void BtnNovoGrupo_Click(object sender, EventArgs e)
        {
            var createGroupForm = new CreateGroupForm();
            createGroupForm.Show();
            createGroupForm.AtribuiFoco();
        }

        private void BtnGerar_Click(object sender, EventArgs e)
        {
            var dados = MontaDadosProExcel();
            var arquivoGerado = GeradorExcel.Gerar(dados);
            CriaDiretorio();
            File.WriteAllBytes($@"{DiretorioGeracaoArquivo}Levantamento_{DateTime.Now.Ticks}.xlsx", arquivoGerado);
            MessageBox.Show($@"Arquivo gerado na pasta {DiretorioGeracaoArquivo}");
        }

        private static void CriaDiretorio()
        {
            if (!Directory.Exists(DiretorioGeracaoArquivo))
                Directory.CreateDirectory(DiretorioGeracaoArquivo);
        }

        private IEnumerable<GrupoModel> MontaDadosProExcel()
        {
            var grupos = new Collection<GrupoModel>();
            foreach (var grupo in Grupos.Select(x => x.Item2))
            {
                var itens = new Collection<ItemLevantamentoModel>();

                foreach (var item in grupo.TabelaGroup.Items)
                {
                    var listViewItem = (ListViewItem) item;
                    itens.Add((ItemLevantamentoModel)listViewItem.Tag);
                }

                grupos.Add(new GrupoModel
                {
                    NomeGrupo = grupo.NomeGrupo,
                    Itens = itens
                });
            }

            return grupos;
        }

        private int RecuperaPosicaoUltimoGrupo()
        {
            if (!Grupos.Any())
                return 0;

            var ultimoGrupo = Grupos.FirstOrDefault(z => z.Item1 == Grupos.Max(x => x.Item1))?.Item2;
            if (ultimoGrupo == null)
                throw new Exception();

            return ultimoGrupo.Bottom;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            foreach (var groupTable in Grupos.Select(x => x.Item2))
                groupTable.AjustaLargura(Convert.ToInt32(Width * 0.95));
        }
    }
}
