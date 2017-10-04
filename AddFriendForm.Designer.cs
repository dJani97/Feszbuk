namespace Feszbuk {
    partial class AddFriendForm {
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
            this.lblIndicator = new System.Windows.Forms.Label();
            this.pnlPeople = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblIndicator
            // 
            this.lblIndicator.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblIndicator.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblIndicator.ForeColor = System.Drawing.Color.White;
            this.lblIndicator.Location = new System.Drawing.Point(0, 0);
            this.lblIndicator.Name = "lblIndicator";
            this.lblIndicator.Size = new System.Drawing.Size(550, 45);
            this.lblIndicator.TabIndex = 4;
            this.lblIndicator.Text = "Ismerősök keresése";
            this.lblIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPeople
            // 
            this.pnlPeople.AutoScroll = true;
            this.pnlPeople.Location = new System.Drawing.Point(34, 77);
            this.pnlPeople.Name = "pnlPeople";
            this.pnlPeople.Size = new System.Drawing.Size(482, 452);
            this.pnlPeople.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(228, 553);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 33);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Bezárás";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtSearch.Location = new System.Drawing.Point(178, 58);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(288, 26);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.Text = "Sajnos még nincs implementálva :(";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblSearch.Location = new System.Drawing.Point(80, 61);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(76, 20);
            this.lblSearch.TabIndex = 7;
            this.lblSearch.Text = "Keresés:";
            // 
            // AddFriendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 608);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlPeople);
            this.Controls.Add(this.lblIndicator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddFriendForm";
            this.Text = "AddFriendForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIndicator;
        private System.Windows.Forms.Panel pnlPeople;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
    }
}