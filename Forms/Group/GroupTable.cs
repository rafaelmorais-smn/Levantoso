using System.Windows.Forms;

namespace Levantoso.Forms.Group
{
    public partial class GroupTable : UserControl
    {
        public GroupTable(string nomeGrupo)
        {
            InitializeComponent();
            GroupBoxName.Text = nomeGrupo;
        }

        public void CancelarNovoItem()
        {
            //var groupForme
            //GroupBoxName.Height += groupForm.Height;
            //Height += groupForm.Height;
            //var mainForm = Application.OpenForms["MainForm"] as MainForm;
            //if (mainForm != null)
            //    mainForm.Height += groupForm.Height; grou
        }

        private void BtnNovoItem_Click(object sender, System.EventArgs e)
        {
            var groupForm = new GroupForm();
            Controls.Add(groupForm);
            var posicaoFinalTabela = TabelaGroup.Bottom;
            groupForm.Top = posicaoFinalTabela + 15;
            groupForm.Left = 15;
            groupForm.BringToFront();
            GroupBoxName.Height += groupForm.Height;
            Height += groupForm.Height;
            var mainForm = Application.OpenForms["MainForm"] as MainForm;
            if (mainForm != null)
                mainForm.Height += groupForm.Height;
            groupForm.Show();
        }

        public void AdicionarDadosGrid(string item, string complexidade, string descricao)
        {
            if (string.IsNullOrEmpty(item) || string.IsNullOrEmpty(complexidade) || string.IsNullOrEmpty(descricao))
                return;

            var dados = new ListViewItem(item);
            dados.SubItems.Add(complexidade);
            dados.SubItems.Add(descricao);
            TabelaGroup.Items.Add(dados);
        }
    }
}
