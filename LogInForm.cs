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
    public partial class LogInForm : Form {

        private List<Person> People { get; set; }
        private MainForm parentForm;
        private int loggedInID = -1;

        public LogInForm(List<Person> people, MainForm sender) {
            int LANG = MainForm.LANG;
            InitializeComponent();
            People = people;
            parentForm = sender;
            Icon = Icon.FromHandle(Properties.Resources.Logo.GetHicon());
            btnLogin.Left = this.ClientSize.Width / 2 - btnLogin.Width / 2;
            btnLogin.BackColor = MainForm.DARK_BLUE;
            BackColor = MainForm.LIGHT_BLUE;
            CenterToParent();
            this.Text = MainForm.textLogInFormTitle[LANG];
            lblLoginText.Text = MainForm.textLoginTextLbl[LANG];
            lblUserName.Text = MainForm.textUserNameLbl[LANG];
            lblPassword.Text = MainForm.textPasswordLbl[LANG];
            btnLogin.Text = MainForm.textLogInBtn[LANG];
        }

        private void LogIn() {
            bool success;
            foreach (Person person in People) {
                success = person.LogIn(txtUserName.Text, txtPassword.Text);
                if (success) {
                    loggedInID = (int)person.ID;
                    this.Close();
                    MessageBox.Show(MainForm.textLogInSuccess[MainForm.LANG]);
                }
            }
            lblLoginText.Text = MainForm.textLogInFailure[MainForm.LANG];
            lblLoginText.ForeColor = Color.Red;
        }

        private void loginButton_Click(object sender, EventArgs e) {
            LogIn();
        }

        public int GetResult() {
            return loggedInID;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                (e as KeyEventArgs).SuppressKeyPress = true;
                LogIn();
            }
        }
    }
}
