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
            this.gunBindsToggleBtn = new System.Windows.Forms.Button();
            this.attachBtn = new System.Windows.Forms.Button();
            this.currentGunLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gunBindsEnabledLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gunBindsToggleBtn
            // 
            this.gunBindsToggleBtn.Location = new System.Drawing.Point(164, 62);
            this.gunBindsToggleBtn.Name = "gunBindsToggleBtn";
            this.gunBindsToggleBtn.Size = new System.Drawing.Size(108, 23);
            this.gunBindsToggleBtn.TabIndex = 0;
            this.gunBindsToggleBtn.Text = "Toggle";
            this.gunBindsToggleBtn.UseVisualStyleBackColor = true;
            this.gunBindsToggleBtn.Click += new System.EventHandler(this.gunBindsToggleBtn_Click);
            // 
            // attachBtn
            // 
            this.attachBtn.Location = new System.Drawing.Point(12, 12);
            this.attachBtn.Name = "attachBtn";
            this.attachBtn.Size = new System.Drawing.Size(260, 23);
            this.attachBtn.TabIndex = 1;
            this.attachBtn.Text = "Inject";
            this.attachBtn.UseVisualStyleBackColor = true;
            this.attachBtn.Click += new System.EventHandler(this.attachBtn_Click);
            // 
            // currentGunLabel
            // 
            this.currentGunLabel.AutoSize = true;
            this.currentGunLabel.Location = new System.Drawing.Point(129, 49);
            this.currentGunLabel.Name = "currentGunLabel";
            this.currentGunLabel.Size = new System.Drawing.Size(13, 13);
            this.currentGunLabel.TabIndex = 2;
            this.currentGunLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current Gun:";
            // 
            // gunBindsEnabledLbl
            // 
            this.gunBindsEnabledLbl.AutoSize = true;
            this.gunBindsEnabledLbl.Location = new System.Drawing.Point(129, 67);
            this.gunBindsEnabledLbl.Name = "gunBindsEnabledLbl";
            this.gunBindsEnabledLbl.Size = new System.Drawing.Size(29, 13);
            this.gunBindsEnabledLbl.TabIndex = 4;
            this.gunBindsEnabledLbl.Text = "True";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "GunBindsEnabled:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gunBindsEnabledLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentGunLabel);
            this.Controls.Add(this.attachBtn);
            this.Controls.Add(this.gunBindsToggleBtn);
            this.Name = "MainForm";
            this.Text = "Form1";
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
    }
}

