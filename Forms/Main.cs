using Levantoso.Forms;
using System;
using System.Windows.Forms;

namespace Levantoso
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public void AbrirGroup(string nomeGrupo)
        {
            var groupForm = new MainGroup(nomeGrupo)
            {
                TopLevel = false,
                Location = 
            };

            Controls.Add(groupForm);
            groupForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var createGroupForm = new _CreateGroup();
            createGroupForm.Show();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {

        }
    }
}
