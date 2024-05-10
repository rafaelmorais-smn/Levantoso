using System.Windows.Forms;

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
            this.BtnNovoItem = new System.Windows.Forms.Button();
            this.GroupBoxName = new System.Windows.Forms.GroupBox();
            this.BtnRemoverGrupo = new System.Windows.Forms.Button();
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
            this.BtnNovoItem.Location = new System.Drawing.Point(807, 57);
            this.BtnNovoItem.Name = "BtnNovoItem";
            this.BtnNovoItem.Size = new System.Drawing.Size(63, 51);
            this.BtnNovoItem.TabIndex = 4;
            this.BtnNovoItem.Text = "+";
            this.BtnNovoItem.UseVisualStyleBackColor = true;
            this.BtnNovoItem.Click += new System.EventHandler(this.BtnNovoItem_Click);
            // 
            // GroupBoxName
            // 
            this.GroupBoxName.Controls.Add(this.BtnRemoverGrupo);
            this.GroupBoxName.Controls.Add(this.TabelaGroup);
            this.GroupBoxName.Controls.Add(this.BtnNovoItem);
            this.GroupBoxName.Location = new System.Drawing.Point(4, 4);
            this.GroupBoxName.Name = "GroupBoxName";
            this.GroupBoxName.Size = new System.Drawing.Size(873, 139);
            this.GroupBoxName.TabIndex = 5;
            this.GroupBoxName.TabStop = false;
            this.GroupBoxName.Text = "groupBox1";
            // 
            // BtnRemoverGrupo
            // 
            this.BtnRemoverGrupo.ForeColor = System.Drawing.Color.Red;
            this.BtnRemoverGrupo.Location = new System.Drawing.Point(809, 14);
            this.BtnRemoverGrupo.Name = "BtnRemoverGrupo";
            this.BtnRemoverGrupo.Size = new System.Drawing.Size(59, 23);
            this.BtnRemoverGrupo.TabIndex = 6;
            this.BtnRemoverGrupo.Text = "Remover";
            this.BtnRemoverGrupo.UseVisualStyleBackColor = true;
            this.BtnRemoverGrupo.Click += new System.EventHandler(this.BtnRemoverGrupo_Click);
            // 
            // TabelaGroup
            // 
            this.TabelaGroup.AllowDrop = true;
            this.TabelaGroup.BackColor = System.Drawing.SystemColors.Window;
            this.TabelaGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.item,
            this.complexidade,
            this.descricao});
            this.TabelaGroup.FullRowSelect = true;
            this.TabelaGroup.GridLines = true;
            this.TabelaGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.TabelaGroup.Location = new System.Drawing.Point(6, 14);
            this.TabelaGroup.Name = "TabelaGroup";
            this.TabelaGroup.Size = new System.Drawing.Size(798, 94);
            this.TabelaGroup.TabIndex = 5;
            this.TabelaGroup.UseCompatibleStateImageBehavior = false;
            this.TabelaGroup.View = System.Windows.Forms.View.Details;
            this.TabelaGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabelaGroup_KeyDown);
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.GroupBoxName);
            this.Name = "GroupTable";
            this.Size = new System.Drawing.Size(880, 155);
            this.GroupBoxName.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnNovoItem;
        private System.Windows.Forms.GroupBox GroupBoxName;
        public System.Windows.Forms.ListView TabelaGroup;
        private System.Windows.Forms.ColumnHeader item;
        private System.Windows.Forms.ColumnHeader complexidade;
        private System.Windows.Forms.ColumnHeader descricao;
        private System.Windows.Forms.Button BtnRemoverGrupo;
    }
}
