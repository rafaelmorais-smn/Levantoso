namespace Levantoso.Forms.Group
{
    partial class GroupForm
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
            this.components = new System.ComponentModel.Container();
            this.groupFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BtnAdicionarItem = new System.Windows.Forms.Button();
            this.InputDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CbComplexidade = new System.Windows.Forms.ComboBox();
            this.CbItem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCancelarItem = new System.Windows.Forms.Button();
            this.itemListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAdicionarItem
            // 
            this.BtnAdicionarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdicionarItem.Location = new System.Drawing.Point(557, 114);
            this.BtnAdicionarItem.Name = "BtnAdicionarItem";
            this.BtnAdicionarItem.Size = new System.Drawing.Size(108, 23);
            this.BtnAdicionarItem.TabIndex = 13;
            this.BtnAdicionarItem.Text = "Adicionar";
            this.BtnAdicionarItem.UseVisualStyleBackColor = true;
            this.BtnAdicionarItem.Click += new System.EventHandler(this.BtnAdicionarItem_Click);
            // 
            // InputDescricao
            // 
            this.InputDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputDescricao.Location = new System.Drawing.Point(3, 67);
            this.InputDescricao.Multiline = true;
            this.InputDescricao.Name = "InputDescricao";
            this.InputDescricao.Size = new System.Drawing.Size(773, 41);
            this.InputDescricao.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Descrição";
            // 
            // CbComplexidade
            // 
            this.CbComplexidade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbComplexidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbComplexidade.FormattingEnabled = true;
            this.CbComplexidade.Location = new System.Drawing.Point(394, 22);
            this.CbComplexidade.Name = "CbComplexidade";
            this.CbComplexidade.Size = new System.Drawing.Size(382, 21);
            this.CbComplexidade.TabIndex = 10;
            // 
            // CbItem
            // 
            this.CbItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbItem.FormattingEnabled = true;
            this.CbItem.Location = new System.Drawing.Point(3, 22);
            this.CbItem.Name = "CbItem";
            this.CbItem.Size = new System.Drawing.Size(375, 21);
            this.CbItem.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Complexidade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Item";
            // 
            // BtnCancelarItem
            // 
            this.BtnCancelarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancelarItem.Location = new System.Drawing.Point(668, 114);
            this.BtnCancelarItem.Name = "BtnCancelarItem";
            this.BtnCancelarItem.Size = new System.Drawing.Size(108, 23);
            this.BtnCancelarItem.TabIndex = 14;
            this.BtnCancelarItem.Text = "Cancelar";
            this.BtnCancelarItem.UseVisualStyleBackColor = true;
            this.BtnCancelarItem.Click += new System.EventHandler(this.BtnCancelarItem_Click);
            // 
            // itemListBindingSource
            // 
            this.itemListBindingSource.DataSource = typeof(Levantoso.Lists.ItemList);
            // 
            // GroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnCancelarItem);
            this.Controls.Add(this.BtnAdicionarItem);
            this.Controls.Add(this.InputDescricao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CbComplexidade);
            this.Controls.Add(this.CbItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GroupForm";
            this.Size = new System.Drawing.Size(788, 149);
            ((System.ComponentModel.ISupportInitialize)(this.groupFormBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource groupFormBindingSource;
        private System.Windows.Forms.Button BtnAdicionarItem;
        private System.Windows.Forms.TextBox InputDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CbComplexidade;
        private System.Windows.Forms.ComboBox CbItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCancelarItem;
        private System.Windows.Forms.BindingSource itemListBindingSource;
    }
}
