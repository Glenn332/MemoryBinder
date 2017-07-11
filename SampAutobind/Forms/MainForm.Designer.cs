using SampAutobind.Properties;

namespace SampAutobind.Forms
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
            this.components = new System.ComponentModel.Container();
            this.gunBindsToggleBtn = new System.Windows.Forms.Button();
            this.attachBtn = new System.Windows.Forms.Button();
            this.currentGunLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gunBindsEnabledLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gunbindsEditBtn = new System.Windows.Forms.Button();
            this.mInfoBtn = new System.Windows.Forms.Button();
            this.mToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // gunBindsToggleBtn
            // 
            this.gunBindsToggleBtn.Location = new System.Drawing.Point(219, 76);
            this.gunBindsToggleBtn.Margin = new System.Windows.Forms.Padding(4);
            this.gunBindsToggleBtn.Name = "gunBindsToggleBtn";
            this.gunBindsToggleBtn.Size = new System.Drawing.Size(69, 28);
            this.gunBindsToggleBtn.TabIndex = 0;
            this.gunBindsToggleBtn.Text = Resources.btn_toggle;
            this.gunBindsToggleBtn.UseVisualStyleBackColor = true;
            this.gunBindsToggleBtn.Click += new System.EventHandler(this.gunBindsToggleBtn_Click);
            // 
            // attachBtn
            // 
            this.attachBtn.Location = new System.Drawing.Point(16, 15);
            this.attachBtn.Margin = new System.Windows.Forms.Padding(4);
            this.attachBtn.Name = "attachBtn";
            this.attachBtn.Size = new System.Drawing.Size(347, 28);
            this.attachBtn.TabIndex = 1;
            this.attachBtn.Text = Resources.btn_inject;
            this.attachBtn.UseVisualStyleBackColor = true;
            this.attachBtn.Click += new System.EventHandler(this.attachBtn_Click);
            // 
            // currentGunLabel
            // 
            this.currentGunLabel.AutoSize = true;
            this.currentGunLabel.Location = new System.Drawing.Point(172, 60);
            this.currentGunLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentGunLabel.Name = "currentGunLabel";
            this.currentGunLabel.Size = new System.Drawing.Size(16, 17);
            this.currentGunLabel.TabIndex = 2;
            this.currentGunLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current Gun:";
            // 
            // gunBindsEnabledLbl
            // 
            this.gunBindsEnabledLbl.AutoSize = true;
            this.gunBindsEnabledLbl.Location = new System.Drawing.Point(172, 82);
            this.gunBindsEnabledLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gunBindsEnabledLbl.Name = "gunBindsEnabledLbl";
            this.gunBindsEnabledLbl.Size = new System.Drawing.Size(35, 17);
            this.gunBindsEnabledLbl.TabIndex = 4;
            this.gunBindsEnabledLbl.Text = "OFF";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "GunBindsEnabled:";
            // 
            // gunbindsEditBtn
            // 
            this.gunbindsEditBtn.Location = new System.Drawing.Point(295, 76);
            this.gunbindsEditBtn.Name = "gunbindsEditBtn";
            this.gunbindsEditBtn.Size = new System.Drawing.Size(68, 28);
            this.gunbindsEditBtn.TabIndex = 6;
            this.gunbindsEditBtn.Text = "Edit";
            this.gunbindsEditBtn.UseVisualStyleBackColor = true;
            this.gunbindsEditBtn.Click += new System.EventHandler(this.gunbindsEditBtn_Click);
            // 
            // mInfoBtn
            // 
            this.mInfoBtn.Location = new System.Drawing.Point(344, 286);
            this.mInfoBtn.Name = "mInfoBtn";
            this.mInfoBtn.Size = new System.Drawing.Size(23, 23);
            this.mInfoBtn.TabIndex = 7;
            this.mInfoBtn.Text = "?";
            this.mInfoBtn.UseVisualStyleBackColor = true;
            this.mInfoBtn.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.mInfoBtn);
            this.Controls.Add(this.gunbindsEditBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gunBindsEnabledLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentGunLabel);
            this.Controls.Add(this.attachBtn);
            this.Controls.Add(this.gunBindsToggleBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MemoryBinder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gunBindsToggleBtn;
        private System.Windows.Forms.Button attachBtn;
        private System.Windows.Forms.Label currentGunLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label gunBindsEnabledLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button gunbindsEditBtn;
        private System.Windows.Forms.Button mInfoBtn;
        private System.Windows.Forms.ToolTip mToolTip;
    }
}

