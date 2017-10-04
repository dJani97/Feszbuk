namespace Feszbuk {
    partial class MessagesForm {
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
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMsgs = new System.Windows.Forms.Panel();
            this.rchTxtEditor = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIndicator
            // 
            this.lblIndicator.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblIndicator.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblIndicator.ForeColor = System.Drawing.Color.White;
            this.lblIndicator.Location = new System.Drawing.Point(0, 0);
            this.lblIndicator.Name = "lblIndicator";
            this.lblIndicator.Size = new System.Drawing.Size(535, 45);
            this.lblIndicator.TabIndex = 3;
            this.lblIndicator.Text = "Üzenetek";
            this.lblIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(220, 509);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 33);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Bezárás";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.closeMsg_Click);
            // 
            // pnlMsgs
            // 
            this.pnlMsgs.AutoScroll = true;
            this.pnlMsgs.BackColor = System.Drawing.Color.White;
            this.pnlMsgs.Location = new System.Drawing.Point(25, 67);
            this.pnlMsgs.Name = "pnlMsgs";
            this.pnlMsgs.Size = new System.Drawing.Size(484, 361);
            this.pnlMsgs.TabIndex = 5;
            // 
            // rchTxtEditor
            // 
            this.rchTxtEditor.Location = new System.Drawing.Point(25, 434);
            this.rchTxtEditor.Name = "rchTxtEditor";
            this.rchTxtEditor.Size = new System.Drawing.Size(413, 53);
            this.rchTxtEditor.TabIndex = 6;
            this.rchTxtEditor.Text = "";
            this.rchTxtEditor.Enter += new System.EventHandler(this.rchTxtEditor_Enter);
            this.rchTxtEditor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rchTxtEditor_KeyDown);
            this.rchTxtEditor.Leave += new System.EventHandler(this.rchTxtEditor_Leave);
            // 
            // btnSend
            // 
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(447, 434);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(62, 53);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Küldés!";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // MessagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 561);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rchTxtEditor);
            this.Controls.Add(this.pnlMsgs);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblIndicator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MessagesForm";
            this.Text = "MessagesForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessagesForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblIndicator;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlMsgs;
        private System.Windows.Forms.RichTextBox rchTxtEditor;
        private System.Windows.Forms.Button btnSend;
    }
}