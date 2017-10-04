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
    public partial class AddFriendForm : Form {

        private List<Person> People { get; set; }
        private int UserID { get; set; }

        int PANEL_MARGIN_X = 30;
        int PANEL_MARGIN_Y = 10;
        int PANEL_PROFILE_HEIGHT = 70;
        int PANEL_GAP_Y = 30;

        public AddFriendForm(List<Person> people, int userID) {
            int LANG = MainForm.LANG;
            InitializeComponent();
            CenterToParent();
            People = people;
            UserID = userID;
            Icon = Icon.FromHandle(Properties.Resources.Logo.GetHicon());
            lblIndicator.BackColor = MainForm.DARK_BLUE;
            btnClose.BackColor = MainForm.DARK_BLUE;
            BackColor = MainForm.LIGHT_BLUE;
            btnClose.ForeColor = Color.White;
            btnClose.Text = MainForm.textCloseBtn[LANG];
            lblSearch.Text = MainForm.textSearchLbl[LANG];
            lblIndicator.Text = MainForm.textAddFriendTitle[LANG];
            this.Text = MainForm.textAddFriendTitle[LANG];

            // Szándékos, a funkciója még nincs implementálva
            txtSearch.Visible = false;
            lblSearch.Visible = false;


            pnlPeople.Left = this.ClientSize.Width / 2 - pnlPeople.Width / 2;
            btnClose.Left = this.ClientSize.Width / 2 - btnClose.Width / 2;

            UpdatePanel();
        }

        private void UpdatePanel() {
            pnlPeople.Controls.Clear();
            List<Person> notFriends = new List<Person>();
            List<int> userFriendIDs = new List<int>();
            CustomPanel pnl;

            userFriendIDs = (MainForm.FindPersonByID(UserID, People)).Friends;

            foreach (Person p in People) {
                if (!userFriendIDs.Contains(p.ID) && UserID != p.ID) {
                    notFriends.Add(p);
                }
            }

            for (int i = 0; i < notFriends.Count; i++) {
                pnl = new CustomPanel(notFriends[i], PANEL_PROFILE_HEIGHT, pnlPeople.Width - 2 * PANEL_MARGIN_X, addFriend_Click, Properties.Resources.Add);
                pnl.Location = new Point(PANEL_MARGIN_X, PANEL_MARGIN_Y + i * (PANEL_PROFILE_HEIGHT + PANEL_GAP_Y));
                pnlPeople.Controls.Add(pnl);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        public void addFriend_Click(object sender, EventArgs e) {
            Person user = MainForm.FindPersonByID(UserID, People);
            Person newFriend = (sender as CustomButton).Person;
            if (!user.Friends.Contains(newFriend.ID)) {
                user.Friends.Add(newFriend.ID);
            }
            if (!newFriend.Friends.Contains(user.ID)) {
                newFriend.Friends.Add(user.ID);
            }

            UpdatePanel();
        }
    }
}
