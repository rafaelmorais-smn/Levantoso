using System;
using System.Windows.Forms;

namespace Levantoso.Forms
{
    public partial class _CreateGroup : Form
    {
        public _CreateGroup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nomeGrupo = inputNomeGrupo.Text;
            var mainForm = Application.OpenForms["Main"];
            (mainForm as Main)?.AbrirGroup(nomeGrupo);
            Close();
        }
    }
}
