namespace Levantoso.Forms.Group
{
    partial class GroupTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataGridItens = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Complexidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnNovoItem = new System.Windows.Forms.Button();
            this.GroupBoxName = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridItens)).BeginInit();
            this.GroupBoxName.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridItens
            // 
            this.DataGridItens.AllowUserToAddRows = false;
            this.DataGridItens.AllowUserToOrderColumns = true;
            this.DataGridItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.Complexidade,
            this.Descricao});
            this.DataGridItens.Location = new System.Drawing.Point(13, 19);
            this.DataGridItens.Name = "DataGridItens";
            this.DataGridItens.Size = new System.Drawing.Size(789, 150);
            this.DataGridItens.TabIndex = 3;
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            // 
            // Complexidade
            // 
            this.Complexidade.HeaderText = "Complexidade";
            this.Complexidade.Name = "Complexidade";
            // 
            // Descricao
            // 
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            // 
            // BtnNovoItem
            // 
            this.BtnNovoItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNovoItem.Location = new System.Drawing.Point(804, 57);
            this.BtnNovoItem.Name = "BtnNovoItem";
            this.BtnNovoItem.Size = new System.Drawing.Size(63, 51);
            this.BtnNovoItem.TabIndex = 4;
            this.BtnNovoItem.Text = "+";
            this.BtnNovoItem.UseVisualStyleBackColor = true;
            this.BtnNovoItem.Click += new System.EventHandler(this.BtnNovoItem_Click);
            // 
            // GroupBoxName
            // 
            this.GroupBoxName.Controls.Add(this.BtnNovoItem);
            this.GroupBoxName.Location = new System.Drawing.Point(4, 4);
            this.GroupBoxName.Name = "GroupBoxName";
            this.GroupBoxName.Size = new System.Drawing.Size(873, 215);
            this.GroupBoxName.TabIndex = 5;
            this.GroupBoxName.TabStop = false;
            this.GroupBoxName.Text = "groupBox1";
            // 
            // GroupTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridItens);
            this.Controls.Add(this.GroupBoxName);
            this.Name = "GroupTable";
            this.Size = new System.Drawing.Size(880, 243);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridItens)).EndInit();
            this.GroupBoxName.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridItens;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Complexidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.Button BtnNovoItem;
        private System.Windows.Forms.GroupBox GroupBoxName;
    }
}
