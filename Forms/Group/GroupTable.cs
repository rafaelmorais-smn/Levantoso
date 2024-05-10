using System;
using System.Linq;
using System.Windows.Forms;

namespace Levantoso.Forms.Group
{
    public partial class GroupTable : UserControl
    {
        public byte SequencialGrupo;
        public bool FormAberto { get; set; }
        public string NomeGrupo { get; set; }

        public GroupTable(string nomeGrupo, byte sequencialGrupo)
        {
            InitializeComponent();
            GroupBoxName.Text = nomeGrupo;
            NomeGrupo = nomeGrupo;
            SequencialGrupo = sequencialGrupo;
            FormAberto = false;
        }

        public void AjustaPosicaoGruposAbaixo(int alturaForm)
        {
            var grupos = BuscaMainForm().Grupos;
            if (!grupos.Any(x => x.Item1 > SequencialGrupo))
                return;

            grupos = grupos.Where(x => x.Item1 > SequencialGrupo).ToList();
            if (!grupos.Any())
                return;

            foreach (var grupo in grupos)
                grupo.Item2.Top += alturaForm > 0 ? alturaForm + 10 : alturaForm - 10;
        }

        public void AjustaPosicoes(int altura)
        {
            AjustaPosicaoGroup(altura);
            AjustaPosicaoGruposAbaixo(altura);
            AjustaPosicaoJanela(altura);
        }

        private void AjustaPosicaoGroup(int alturaForm)
        {
            alturaForm += alturaForm > 0 ? 10 : -10;
            GroupBoxName.Height += alturaForm;
            Height += alturaForm;
        }

        private static void AjustaPosicaoJanela(int alturaForm)
        {
            BuscaMainForm().Height += alturaForm > 0 ? alturaForm + 10 : alturaForm - 10;
        }

        private void BtnNovoItem_Click(object sender, EventArgs e)
        {
            if (FormAberto)
                return;

            var groupForm = new GroupForm(SequencialGrupo);
            groupForm.AjustaPosicaoForm(TabelaGroup.Bottom);
            Controls.Add(groupForm);
            AjustaPosicoes(groupForm.Height);
            groupForm.Show();
            groupForm.BringToFront();
            groupForm.AtribuiFoco();
            FormAberto = true;
        }

        private static MainForm BuscaMainForm()
        {
            var mainForm = Application.OpenForms["MainForm"] as MainForm;
            if (mainForm == null)
                throw new Exception();
            return mainForm;
        }

        private void BtnRemoverGrupo_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show(@"Deseja realmente remover este grupo?", @"Atenção", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
                return;

            var mainForm = BuscaMainForm();
            var grupo = mainForm.Grupos.FirstOrDefault(x => x.Item1 == SequencialGrupo);
            if (grupo == null)
                throw new Exception();

            mainForm.Grupos.Remove(grupo);
            mainForm.Controls.Remove(grupo.Item2);
            AjustaPosicoes(Height * -1);
        }

        private void TabelaGroup_KeyDown(object sender, KeyEventArgs e)
        {
            var dialog = MessageBox.Show(@"Deseja realmente remover este item?", @"Atenção", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
                return;

            if (Keys.Delete != e.KeyCode)
                return;

            foreach (ListViewItem listViewItem in ((ListView)sender).SelectedItems)
                listViewItem.Remove();
        }
    }
}
