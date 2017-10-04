namespace Feszbuk {
    partial class HelpForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.rchTxtHelp = new System.Windows.Forms.RichTextBox();
            this.lblIndicator = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rchTxtHelp
            // 
            this.rchTxtHelp.BackColor = System.Drawing.Color.White;
            this.rchTxtHelp.Location = new System.Drawing.Point(30, 79);
            this.rchTxtHelp.Name = "rchTxtHelp";
            this.rchTxtHelp.ReadOnly = true;
            this.rchTxtHelp.Size = new System.Drawing.Size(791, 542);
            this.rchTxtHelp.TabIndex = 0;
            this.rchTxtHelp.Text = "";
            // 
            // lblIndicator
            // 
            this.lblIndicator.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblIndicator.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblIndicator.ForeColor = System.Drawing.Color.White;
            this.lblIndicator.Location = new System.Drawing.Point(0, -3);
            this.lblIndicator.Name = "lblIndicator";
            this.lblIndicator.Size = new System.Drawing.Size(854, 48);
            this.lblIndicator.TabIndex = 2;
            this.lblIndicator.Text = "Súgó";
            this.lblIndicator.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(382, 650);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 33);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Bezárás";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.closeHelp_Click);
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 709);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblIndicator);
            this.Controls.Add(this.rchTxtHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HelpForm";
            this.Text = "HelpForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchTxtHelp;
        private System.Windows.Forms.Label lblIndicator;
        private System.Windows.Forms.Button btnClose;
    }
}