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
    public partial class ProfileForm : Form {

        public Person Person { get; private set; }
        int pictureMargin = 10;
        int imageHeight;
        

        public ProfileForm(Person personToDisplay) {
            int LANG = MainForm.LANG;
            InitializeComponent();
            CenterToParent();
            Person = personToDisplay;
            Icon = Icon.FromHandle(Properties.Resources.Logo.GetHicon());
            imageHeight = picBoxProfilePicture.Height;

            this.BackColor = MainForm.LIGHT_BLUE;

            lblUserFullName.Text = Person.FullName;
            lblUserAge.Text = MainForm.textAge[LANG] + ":\n " + Person.Age.ToString();
            lblUserJob.Text = MainForm.textJob[LANG] + ":\n " + Person.Job;
            lblUserTown.Text = MainForm.textTown[LANG] + ":\n " + Person.Town;
            lblUserPhone.Text = MainForm.textPhone[LANG] + ":\n " + Person.PhoneNumber.ToString();
            lblUserEmail.Text = MainForm.textEmail[LANG] + ":\n " + Person.Email;

            picBoxProfilePicture.Image = Image.FromFile("../pictures/" + Person.Picture);
            picBoxProfilePicture.Height = imageHeight;
            picBoxProfilePicture.Width = MainForm.ScaleImageWidth(picBoxProfilePicture.Image.Height, picBoxProfilePicture.Image.Width, imageHeight);
            picBoxProfilePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxProfilePicture.Left = this.ClientSize.Width - picBoxProfilePicture.Width - pictureMargin;
            picBoxProfilePicture.Top = pictureMargin;
            picBoxProfilePicture.BackColor = MainForm.LIGHT_BLUE;
            this.Text = MainForm.textProfileFormTitle[LANG] + ": " + Person.FullName;
        }

        private void picBoxProfilePicture_Click(object sender, EventArgs e)
        {
            if(picBoxProfilePicture.Dock != DockStyle.Fill) {
                picBoxProfilePicture.Dock = DockStyle.Fill;
                picBoxProfilePicture.BringToFront();
            }
            else {
                picBoxProfilePicture.Dock = DockStyle.None;
            }
        }

        private void ProfileForm_FormClosing(object sender, FormClosingEventArgs e) {
            MainForm.openedProfileForms.Remove(this);
        }
    }
}
