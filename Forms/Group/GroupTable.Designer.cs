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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("yrdyr");
            this.BtnNovoItem = new System.Windows.Forms.Button();
            this.GroupBoxName = new System.Windows.Forms.GroupBox();
            this.TabelaGroup = new System.Windows.Forms.ListView();
            this.item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.complexidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GroupBoxName.SuspendLayout();
            this.SuspendLayout();
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
            this.GroupBoxName.Controls.Add(this.TabelaGroup);
            this.GroupBoxName.Controls.Add(this.BtnNovoItem);
            this.GroupBoxName.Location = new System.Drawing.Point(4, 4);
            this.GroupBoxName.Name = "GroupBoxName";
            this.GroupBoxName.Size = new System.Drawing.Size(873, 215);
            this.GroupBoxName.TabIndex = 5;
            this.GroupBoxName.TabStop = false;
            this.GroupBoxName.Text = "groupBox1";
            // 
            // TabelaGroup
            // 
            this.TabelaGroup.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TabelaGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.item,
            this.complexidade,
            this.descricao});
            this.TabelaGroup.FullRowSelect = true;
            this.TabelaGroup.GridLines = true;
            this.TabelaGroup.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.TabelaGroup.Location = new System.Drawing.Point(6, 14);
            this.TabelaGroup.Name = "TabelaGroup";
            this.TabelaGroup.Size = new System.Drawing.Size(798, 195);
            this.TabelaGroup.TabIndex = 5;
            this.TabelaGroup.UseCompatibleStateImageBehavior = false;
            this.TabelaGroup.View = System.Windows.Forms.View.Details;
            // 
            // item
            // 
            this.item.Text = "Item";
            this.item.Width = 248;
            // 
            // complexidade
            // 
            this.complexidade.Text = "Complexidade";
            this.complexidade.Width = 234;
            // 
            // descricao
            // 
            this.descricao.Text = "Descrição";
            this.descricao.Width = 263;
            // 
            // GroupTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupBoxName);
            this.Name = "GroupTable";
            this.Size = new System.Drawing.Size(880, 243);
            this.GroupBoxName.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnNovoItem;
        private System.Windows.Forms.GroupBox GroupBoxName;
        private System.Windows.Forms.ListView TabelaGroup;
        private System.Windows.Forms.ColumnHeader item;
        private System.Windows.Forms.ColumnHeader complexidade;
        private System.Windows.Forms.ColumnHeader descricao;
    }
}
