namespace Levantoso.Forms
{
    partial class MainGroup
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
            this.groupName = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // groupName
            // 
            this.groupName.Location = new System.Drawing.Point(1, 2);
            this.groupName.Name = "groupName";
            this.groupName.Size = new System.Drawing.Size(713, 261);
            this.groupName.TabIndex = 0;
            this.groupName.TabStop = false;
            this.groupName.Enter += new System.EventHandler(this.groupName_Enter);
            // 
            // MainGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 261);
            this.ControlBox = false;
            this.Controls.Add(this.groupName);
            this.Name = "MainGroup";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.MainGroup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupName;
    }
}