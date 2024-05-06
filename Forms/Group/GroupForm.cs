using System.Windows.Forms;

namespace Levantoso.Forms.Group
{
    public partial class GroupForm : UserControl
    {
        public GroupForm()
        {
            InitializeComponent();

            CbComplexidade.Items.Add("Simples");
            CbComplexidade.Items.Add("Médio");
            CbComplexidade.Items.Add("Complexo");

            CbItem.Items.Add("Tabela");
            CbItem.Items.Add("Formulário");
            CbItem.Items.Add("Procedure");
            CbItem.Items.Add("JOB");
            CbItem.Items.Add("Trigger");
            CbItem.Items.Add("Função");
            CbItem.Items.Add("Script");
            CbItem.Items.Add("Modelagem");
            CbItem.Items.Add("API");
            CbItem.Items.Add("Console");
            CbItem.Items.Add("PDF");
            CbItem.Items.Add("Excel");
        }

        private void BtnCancelarItem_Click(object sender, System.EventArgs e)
        {
            //var mainForm = Application.OpenForms["GroupTable"]. as MainForm;
            //if (mainForm != null)
            //    mainForm.Height += groupForm.Height;
        }
    }
}
