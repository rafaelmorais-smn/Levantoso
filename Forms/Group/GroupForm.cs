using Levantoso.Lists;
using Levantoso.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Levantoso.Forms.Group
{
    public partial class GroupForm : UserControl
    {
        public byte SequencialGrupo;

        public GroupForm(byte sequencialGrupo)
        {
            InitializeComponent();
            SequencialGrupo = sequencialGrupo;
            PreencheCombos();
        }

        public void AjustaPosicaoForm(int posicaoFinalTabela)
        {
            Top = posicaoFinalTabela + 15;
            Left = 15;
        }

        public void AtribuiFoco()
        {
            CbItem.Select();
        }

        public void AjustaLargura(int largura)
        {
            Width = Convert.ToInt32(largura * 0.9);
        }

        private void PreencheCombos()
        {
            CbItem.DataSource = ItemList.ComboValues;
            CbComplexidade.DataSource = ComplexidadeList.ComboValues;
        }

        private void BtnCancelarItem_Click(object sender, EventArgs e)
        {
            Hide();
            LimpaCampos();
            var grupo = BuscaGrupo();
            grupo.AjustaPosicoes(Height * -1);
            grupo.FormAberto = false;
        }

        private void BtnAdicionarItem_Click(object sender, EventArgs e)
        {
            var item = (ComboItem) CbItem.SelectedItem;
            var complexidade = (ComboItem) CbComplexidade.SelectedItem;

            if (item.Value == 0 || complexidade.Value == 0 || string.IsNullOrEmpty(InputDescricao.Text))
                return;

            var linha = new ListViewItem(new[] {item.Text, complexidade.Text, InputDescricao.Text})
            {
                Tag = new ItemLevantamentoModel(item, complexidade, InputDescricao.Text)
            };

            var grupo = BuscaGrupo();
            grupo.TabelaGroup.Items.Add(linha);
            BtnCancelarItem_Click(null, null);
        }

        private GroupTable BuscaGrupo()
        {
            var mainForm = Application.OpenForms["MainForm"] as MainForm;
            if (mainForm == null)
                throw new Exception();

            var form = (GroupForm)BtnAdicionarItem.Parent;
            if (form == null)
                throw new Exception();

            var grupo = mainForm.Grupos.FirstOrDefault(x => x.Item1 == form.SequencialGrupo)?.Item2;
            if (grupo == null)
                throw new Exception();

            return grupo;
        }

        private void LimpaCampos()
        {
            PreencheCombos();
            InputDescricao.Text = "";
        }
    }
}
