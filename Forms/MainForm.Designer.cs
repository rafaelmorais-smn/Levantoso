using System.Windows.Forms;

namespace Levantoso.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InputNomeLevantamento = new System.Windows.Forms.TextBox();
            this.LabelNomeLevantamento = new System.Windows.Forms.Label();
            this.FileDialogImportarArquivo = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InputNomeLevantamento
            // 
            this.InputNomeLevantamento.Location = new System.Drawing.Point(15, 20);
            this.InputNomeLevantamento.Name = "InputNomeLevantamento";
            this.InputNomeLevantamento.Size = new System.Drawing.Size(313, 20);
            this.InputNomeLevantamento.TabIndex = 2;
            // 
            // LabelNomeLevantamento
            // 
            this.LabelNomeLevantamento.AutoSize = true;
            this.LabelNomeLevantamento.Location = new System.Drawing.Point(13, 3);
            this.LabelNomeLevantamento.Name = "LabelNomeLevantamento";
            this.LabelNomeLevantamento.Size = new System.Drawing.Size(89, 13);
            this.LabelNomeLevantamento.TabIndex = 3;
            this.LabelNomeLevantamento.Text = "Nome do Projeto:";
            // 
            // FileDialogImportarArquivo
            // 
            this.FileDialogImportarArquivo.FileName = "Selecione um levantamento";
            this.FileDialogImportarArquivo.Filter = "Text files (*.xlsx)|*.xlsx";
            this.FileDialogImportarArquivo.InitialDirectory = "C:\\Levantoso";
            this.FileDialogImportarArquivo.Title = "Importar Levantamento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ctrl + N = Novo Grupo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ctrl + I = Importar Arquivo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(675, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ctrl + G = Gerar Arquivo";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(964, 72);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelNomeLevantamento);
            this.Controls.Add(this.InputNomeLevantamento);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Levantoso";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox InputNomeLevantamento;
        private System.Windows.Forms.Label LabelNomeLevantamento;
        private System.Windows.Forms.OpenFileDialog FileDialogImportarArquivo;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}

