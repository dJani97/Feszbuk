namespace Feszbuk {
    partial class ProfileForm {
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
            this.picBoxProfilePicture = new System.Windows.Forms.PictureBox();
            this.lblUserFullName = new System.Windows.Forms.Label();
            this.lblUserAge = new System.Windows.Forms.Label();
            this.lblUserJob = new System.Windows.Forms.Label();
            this.lblUserTown = new System.Windows.Forms.Label();
            this.lblUserPhone = new System.Windows.Forms.Label();
            this.lblUserEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxProfilePicture
            // 
            this.picBoxProfilePicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxProfilePicture.BackColor = System.Drawing.SystemColors.Control;
            this.picBoxProfilePicture.Location = new System.Drawing.Point(325, 12);
            this.picBoxProfilePicture.Name = "picBoxProfilePicture";
            this.picBoxProfilePicture.Size = new System.Drawing.Size(137, 198);
            this.picBoxProfilePicture.TabIndex = 0;
            this.picBoxProfilePicture.TabStop = false;
            this.picBoxProfilePicture.Click += new System.EventHandler(this.picBoxProfilePicture_Click);
            // 
            // lblUserFullName
            // 
            this.lblUserFullName.AutoSize = true;
            this.lblUserFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUserFullName.Location = new System.Drawing.Point(12, 12);
            this.lblUserFullName.Name = "lblUserFullName";
            this.lblUserFullName.Size = new System.Drawing.Size(215, 33);
            this.lblUserFullName.TabIndex = 1;
            this.lblUserFullName.Text = "Example Name";
            // 
            // lblUserAge
            // 
            this.lblUserAge.AutoSize = true;
            this.lblUserAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUserAge.Location = new System.Drawing.Point(12, 72);
            this.lblUserAge.Name = "lblUserAge";
            this.lblUserAge.Size = new System.Drawing.Size(27, 20);
            this.lblUserAge.TabIndex = 1;
            this.lblUserAge.Text = "20";
            // 
            // lblUserJob
            // 
            this.lblUserJob.AutoSize = true;
            this.lblUserJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUserJob.Location = new System.Drawing.Point(12, 132);
            this.lblUserJob.Name = "lblUserJob";
            this.lblUserJob.Size = new System.Drawing.Size(96, 20);
            this.lblUserJob.TabIndex = 1;
            this.lblUserJob.Text = "ExampleJob";
            // 
            // lblUserTown
            // 
            this.lblUserTown.AutoSize = true;
            this.lblUserTown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUserTown.Location = new System.Drawing.Point(14, 192);
            this.lblUserTown.Name = "lblUserTown";
            this.lblUserTown.Size = new System.Drawing.Size(47, 20);
            this.lblUserTown.TabIndex = 1;
            this.lblUserTown.Text = "Town";
            // 
            // lblUserPhone
            // 
            this.lblUserPhone.AutoSize = true;
            this.lblUserPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUserPhone.Location = new System.Drawing.Point(12, 252);
            this.lblUserPhone.Name = "lblUserPhone";
            this.lblUserPhone.Size = new System.Drawing.Size(108, 20);
            this.lblUserPhone.TabIndex = 1;
            this.lblUserPhone.Text = "06301234567";
            // 
            // lblUserEmail
            // 
            this.lblUserEmail.AutoSize = true;
            this.lblUserEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUserEmail.Location = new System.Drawing.Point(12, 312);
            this.lblUserEmail.Name = "lblUserEmail";
            this.lblUserEmail.Size = new System.Drawing.Size(143, 20);
            this.lblUserEmail.TabIndex = 1;
            this.lblUserEmail.Text = "example@email.hu";
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 463);
            this.Controls.Add(this.lblUserEmail);
            this.Controls.Add(this.lblUserPhone);
            this.Controls.Add(this.lblUserTown);
            this.Controls.Add(this.lblUserJob);
            this.Controls.Add(this.lblUserAge);
            this.Controls.Add(this.lblUserFullName);
            this.Controls.Add(this.picBoxProfilePicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ProfileForm";
            this.Text = "Profile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfileForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxProfilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxProfilePicture;
        private System.Windows.Forms.Label lblUserFullName;
        private System.Windows.Forms.Label lblUserAge;
        private System.Windows.Forms.Label lblUserJob;
        private System.Windows.Forms.Label lblUserTown;
        private System.Windows.Forms.Label lblUserPhone;
        private System.Windows.Forms.Label lblUserEmail;
    }
}