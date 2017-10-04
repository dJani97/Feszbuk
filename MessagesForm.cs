using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Feszbuk {
    public partial class MessagesForm : Form {
        public Person Target { get; private set; }
        Person User { get; set; }
        List<Message> Messages { get; set; }
        string initialText;

        int spacingY = 10;
        int spacingX = 10;


        public MessagesForm(Person target, Person user, List<Message> messages) {
            int LANG = MainForm.LANG;
            this.Target = target;
            this.User = user;
            this.Messages = messages;

            InitializeComponent();
            Icon = Icon.FromHandle(Properties.Resources.Logo.GetHicon());
            lblIndicator.BackColor = MainForm.DARK_BLUE;
            BackColor = MainForm.LIGHT_BLUE;
            btnClose.BackColor = MainForm.DARK_BLUE;
            btnSend.BackColor = MainForm.DARK_BLUE;
            btnClose.ForeColor = Color.White;
            rchTxtEditor.ForeColor = Color.Gray;
            btnSend.Text = MainForm.textSendBtn[LANG];
            initialText = MainForm.textInitialMessage[LANG];
            btnClose.Text = MainForm.textCloseBtn[LANG];

            lblIndicator.Text = target.FullName;
            this.Text = MainForm.textMessageFormTitle[LANG] + ": " + target.FullName;

            pnlMsgs.Left = this.ClientSize.Width / 2 - pnlMsgs.Width / 2;
            btnClose.Left = this.ClientSize.Width / 2 - btnClose.Width / 2;

            UpdatePanel();
        }

        private void UpdatePanel() {
            pnlMsgs.Controls.Clear();
            int totalHeight = 0;
            List<Message> msgs = new List<Message>();
            RichTextBox box;
            if (!rchTxtEditor.Focused) {
                rchTxtEditor.Text = initialText;
            }
            else {
                rchTxtEditor.Text = "";
            }

            foreach (Message msg in Messages) {
                if((msg.SenderID == Target.ID && msg.ReceiverID == User.ID) || (msg.SenderID == User.ID && msg.ReceiverID == Target.ID)) {
                    msgs.Add(msg);
                }
            }

            for (int i = 0; i < msgs.Count; i++) {
                box = new RichTextBox();
                box.Size = new Size((int)(pnlMsgs.Width/3)*2, 20);
                box.Margin = new Padding(100);
                box.ContentsResized += new ContentsResizedEventHandler(rtb_ContentsResized);
                box.Text = msgs[i].Content;
                box.Font = new Font(FontFamily.GenericSansSerif, 12);
                Console.WriteLine("\nBox size: " + box.ClientRectangle);
                box.WordWrap = true;
                box.ReadOnly = true;
                

                if (msgs[i].SenderID == User.ID) {
                    box.Location = new Point(pnlMsgs.Width - box.Width - spacingX, totalHeight + (i+1) * spacingY);
                    box.BackColor = MainForm.LIGHT_BLUE;
                    box.SelectionAlignment = HorizontalAlignment.Right;
                }
                else {
                    box.Location = new Point(spacingX, totalHeight + (i + 1) * spacingY);
                }
                pnlMsgs.Controls.Add(box);
                totalHeight += box.Height;
            }

            pnlMsgs.VerticalScroll.Value = VerticalScroll.Maximum;
        }

        private void SendMessage() {
            if(rchTxtEditor.Text != initialText && rchTxtEditor.TextLength > 0) {
                string content = rchTxtEditor.Text;
                content = content.Replace(";", "");
                Message msg = new Message(User.ID, Target.ID, content);
                Messages.Add(msg);
                UpdatePanel();
            }
            
        }

        // Handlers

        private void closeMsg_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void rchTxtEditor_Enter(object sender, EventArgs e) {
            if(rchTxtEditor.Text == initialText) {
                rchTxtEditor.Text = "";
                rchTxtEditor.ForeColor = Color.Black;
            }
        }

        private void rchTxtEditor_Leave(object sender, EventArgs e) {
            if (rchTxtEditor.Text == "") {
                rchTxtEditor.Text = initialText;
                rchTxtEditor.ForeColor = Color.Gray;
            }
        }

        private void btnSend_Click(object sender, EventArgs e) {
            SendMessage();
        }

        private void rtb_ContentsResized(object sender, ContentsResizedEventArgs e) {
            ((RichTextBox)sender).Height = e.NewRectangle.Height + 5;
            ((RichTextBox)sender).Width = e.NewRectangle.Width + 5;
        }

        private void rchTxtEditor_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                (e as KeyEventArgs).SuppressKeyPress = true;
                SendMessage();
            }
        }

        private void MessagesForm_FormClosing(object sender, FormClosingEventArgs e) {
            MainForm.openedMessagesForms.Remove(this);
        }
    }
}
