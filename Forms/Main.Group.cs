using System;
using System.Windows.Forms;

namespace Levantoso.Forms
{
    public partial class MainGroup : Form
    {
        public MainGroup(string nomeGrupo)
        {
            InitializeComponent();
            groupName.Text = nomeGrupo;
        }

        private void groupName_Enter(object sender, EventArgs e)
        {

        }

        private void MainGroup_Load(object sender, EventArgs e)
        {

        }
    }
}
