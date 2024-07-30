using System;
using System.Windows.Forms;

namespace Levantoso.WinForm.Forms
{
    public partial class CreateGroupForm : Form
    {
        public CreateGroupForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nomeGrupo = inputNomeGrupo.Text;
            var mainForm = Application.OpenForms["MainForm"];
            (mainForm as MainForm)?.AbrirGroup(nomeGrupo);
            Close();
        }

        public void AtribuiFoco()
        {
            inputNomeGrupo.Focus();
        }
    }
}
