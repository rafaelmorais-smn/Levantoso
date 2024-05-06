using Levantoso.Forms.Group;
using System;
using System.Windows.Forms;

namespace Levantoso.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void AbrirGroup(string nomeGrupo)
        {
            var groupTable = new GroupTable(nomeGrupo);            
            Controls.Add(groupTable);
            groupTable.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void BtnNovoGrupo_Click(object sender, EventArgs e)
        {
            var createGroupForm = new CreateGroupForm();
            createGroupForm.Show();
        }

        private void BtnGerar_Click(object sender, EventArgs e)
        {

        }
    }
}
