using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using Levantoso.Domain.Excel;
using Levantoso.Domain.Models;
using Levantoso.WinForm.Forms.Group;

namespace Levantoso.WinForm.Forms
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

        private static void NovoGrupo()
        {
            var createGroupForm = new CreateGroupForm();
            createGroupForm.Show();
            createGroupForm.AtribuiFoco();
        }

        private void GerarArquivo()
        {
            var dados = MontaDadosProExcel();
            var arquivoGerado = GeradorExcel.GerarPeloWinForm(dados);
            CriaDiretorio();
            var nomeLevantamento = string.IsNullOrEmpty(InputNomeLevantamento.Text)
                ? $"LevantamentoDeHoras_{DateTime.Now.Ticks}"
                : $"{InputNomeLevantamento.Text} - Levantamento de horas";

            File.WriteAllBytes($@"{DiretorioGeracaoArquivo}{nomeLevantamento}.xlsx", arquivoGerado);
            MessageBox.Show($@"Arquivo gerado na pasta {DiretorioGeracaoArquivo} com nome {nomeLevantamento}");
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
                return 30;

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

        private void ImportarArquivo()
        {
            if (!ValidaNovaImportacao())
                return;

            LimpaLevantamento();
            var grupos = RealizaLeituraArquivo();
            if (grupos == null)
                return;

            MontaExibicaoDados(grupos);
        }

        private bool ValidaNovaImportacao()
        {
            if (!Grupos.Any())
                return true;

            var dialog = MessageBox.Show(@"Ao importar um arquivo os itens cadastrados até aqui serão perdidos, "
                + @"certifique-se de gerar o arquivo se estes dados forem importantes antes de importar um levantamento!",
                @"Atenção", MessageBoxButtons.OKCancel);
            return dialog == DialogResult.OK;
        }

        private void LimpaLevantamento()
        {
            while (Grupos.Any())
            {
                var ultimo = Grupos.Last();
                Controls.Remove(ultimo.Item2);
                Grupos.Remove(ultimo);
            }
        }

        private IEnumerable<GrupoModel> RealizaLeituraArquivo()
        {
            if (FileDialogImportarArquivo.ShowDialog() != DialogResult.OK)
                return null;

            IEnumerable<GrupoModel> grupos;
            try
            {
                var file = new FileInfo(FileDialogImportarArquivo.FileName);
                grupos = LeitorExcel.Processar(file);
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                                $"Details:\n\n{ex.StackTrace}");
                return null;
            }
            return grupos;
        }

        private void MontaExibicaoDados(IEnumerable<GrupoModel> grupos)
        {
            InputNomeLevantamento.Text = FileDialogImportarArquivo.SafeFileName?.Replace(" - Levantamento de horas.xlsx", "");
            foreach (var grupo in grupos)
            {
                AbrirGroup(grupo.NomeGrupo);
                var groupTable = Grupos.Last().Item2;
                foreach (var item in grupo.Itens)
                {
                    var linha = new ListViewItem(new[] { item.Item.Text, item.Complexidade.Text, item.Descricao })
                    {
                        Tag = item
                    };
                    groupTable.TabelaGroup.Items.Add(linha);
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyData == (Keys.Control | Keys.N))
                NovoGrupo();

            if (e.Control && e.KeyData == (Keys.Control | Keys.I))
                ImportarArquivo();

            if (e.Control && e.KeyData == (Keys.Control | Keys.G))
                GerarArquivo();
        }
    }
}
