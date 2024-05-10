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
            this.BtnNovoGrupo = new System.Windows.Forms.Button();
            this.BtnGerar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnNovoGrupo
            // 
            this.BtnNovoGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNovoGrupo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnNovoGrupo.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnNovoGrupo.Location = new System.Drawing.Point(363, 37);
            this.BtnNovoGrupo.Name = "BtnNovoGrupo";
            this.BtnNovoGrupo.Size = new System.Drawing.Size(105, 41);
            this.BtnNovoGrupo.TabIndex = 0;
            this.BtnNovoGrupo.Text = "Novo Grupo";
            this.BtnNovoGrupo.UseVisualStyleBackColor = true;
            this.BtnNovoGrupo.Click += new System.EventHandler(this.BtnNovoGrupo_Click);
            // 
            // BtnGerar
            // 
            this.BtnGerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnGerar.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnGerar.Location = new System.Drawing.Point(474, 37);
            this.BtnGerar.Name = "BtnGerar";
            this.BtnGerar.Size = new System.Drawing.Size(105, 41);
            this.BtnGerar.TabIndex = 1;
            this.BtnGerar.Text = "Gerar Arquivo";
            this.BtnGerar.UseVisualStyleBackColor = true;
            this.BtnGerar.Click += new System.EventHandler(this.BtnGerar_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 90);
            this.Controls.Add(this.BtnGerar);
            this.Controls.Add(this.BtnNovoGrupo);
            this.Name = "MainForm";
            this.Text = "Levantoso";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnNovoGrupo;
        private System.Windows.Forms.Button BtnGerar;
    }
}

