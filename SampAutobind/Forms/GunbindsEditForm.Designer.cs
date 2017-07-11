namespace SampAutobind.Forms
{
    partial class GunbindsEditForm
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
            this.weaponSelectBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.weaponInTextBox = new System.Windows.Forms.TextBox();
            this.weaponOutTextBox = new System.Windows.Forms.TextBox();
            this.weaponIdLbl = new System.Windows.Forms.Label();
            this.gunBindsSaveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // weaponSelectBox
            // 
            this.weaponSelectBox.FormattingEnabled = true;
            this.weaponSelectBox.ItemHeight = 16;
            this.weaponSelectBox.Location = new System.Drawing.Point(13, 13);
            this.weaponSelectBox.Name = "weaponSelectBox";
            this.weaponSelectBox.Size = new System.Drawing.Size(613, 100);
            this.weaponSelectBox.TabIndex = 0;
            this.weaponSelectBox.SelectedIndexChanged += new System.EventHandler(this.weaponSelectBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "WeaponInText:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "WeaponOutText:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "WeaponId:";
            // 
            // weaponInTextBox
            // 
            this.weaponInTextBox.Enabled = false;
            this.weaponInTextBox.Location = new System.Drawing.Point(158, 120);
            this.weaponInTextBox.Name = "weaponInTextBox";
            this.weaponInTextBox.Size = new System.Drawing.Size(468, 22);
            this.weaponInTextBox.TabIndex = 2;
            // 
            // weaponOutTextBox
            // 
            this.weaponOutTextBox.Enabled = false;
            this.weaponOutTextBox.Location = new System.Drawing.Point(158, 151);
            this.weaponOutTextBox.Name = "weaponOutTextBox";
            this.weaponOutTextBox.Size = new System.Drawing.Size(468, 22);
            this.weaponOutTextBox.TabIndex = 2;
            // 
            // weaponIdLbl
            // 
            this.weaponIdLbl.AutoSize = true;
            this.weaponIdLbl.Location = new System.Drawing.Point(155, 189);
            this.weaponIdLbl.Name = "weaponIdLbl";
            this.weaponIdLbl.Size = new System.Drawing.Size(0, 17);
            this.weaponIdLbl.TabIndex = 3;
            // 
            // gunBindsSaveBtn
            // 
            this.gunBindsSaveBtn.Enabled = false;
            this.gunBindsSaveBtn.Location = new System.Drawing.Point(13, 225);
            this.gunBindsSaveBtn.Name = "gunBindsSaveBtn";
            this.gunBindsSaveBtn.Size = new System.Drawing.Size(613, 35);
            this.gunBindsSaveBtn.TabIndex = 4;
            this.gunBindsSaveBtn.Text = "Save";
            this.gunBindsSaveBtn.UseVisualStyleBackColor = true;
            this.gunBindsSaveBtn.Click += new System.EventHandler(this.gunBindsSaveBtn_Click);
            // 
            // GunbindsEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 422);
            this.Controls.Add(this.gunBindsSaveBtn);
            this.Controls.Add(this.weaponIdLbl);
            this.Controls.Add(this.weaponOutTextBox);
            this.Controls.Add(this.weaponInTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.weaponSelectBox);
            this.Name = "GunbindsEditForm";
            this.Text = "Edit Gunbinds";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox weaponSelectBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox weaponInTextBox;
        private System.Windows.Forms.TextBox weaponOutTextBox;
        private System.Windows.Forms.Label weaponIdLbl;
        private System.Windows.Forms.Button gunBindsSaveBtn;
    }
}