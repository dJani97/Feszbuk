using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Feszbuk {
    public partial class MainForm : Form {

        // Version
        public static string CURRENT_APP_VERSION = "1.2";

        // Debug options
        bool AUTO_LOAD_DATABASE = true;
        bool SEE_EVERYONE = false;
        bool AUTO_LOGIN = false;
        bool AUTO_OPEN_MESSAGES = false;
        int autoLogInID = 1;

        // Static definitions
        public static Color LIGHT_BLUE = Color.FromArgb(223, 227, 238);
        public static Color DARK_BLUE = Color.FromArgb(59, 89, 151);

        // Fields
        string INPUT_FILE = "feszbuk_data.txt";
        string OUTPUT_FILE = "feszbuk_data_export.txt";
        string PROFILE_INDICATOR = "**profile**";
        string MESSAGE_INDICATOR = "**message**";
        char SEPARATOR = ';';
        char FRIEND_SEPARATOR = '#';

        int PANEL_MARGIN_X = 30;
        int PANEL_MARGIN_Y = 10;
        int PANEL_PROFILE_HEIGHT = 70;
        int PANEL_GAP_Y = 30;

        // User handling
        List<Person> people = new List<Person>();
        List<Message> messages = new List<Message>();
        public static List<MessagesForm> openedMessagesForms = new List<MessagesForm>();
        public static List<ProfileForm> openedProfileForms = new List<ProfileForm>();
        int userID;

        // Language strings:
        // (0 - Hungarian, 1 - English)
        #region LANGUAGE
        public static int LANG = 1;
        // MainForm
        public static string[] textNoProfiles = { "Kérem először nyissa meg az adatokat tartalmazó fájlt!", "Unable to log in: no profiles are loaded into memory" };
        public static string[] textLogInBtn = { "Bejelentkezés", "Sign In" };
        public static string[] textMyProfileBtn = { "Saját profilom", "My Profile" };
        public static string[] textWritingSuccess = { "Adatok sikeresen kiírva!", "File writing successful!" };
        public static string[] textCleanMemoryWarning = { "Biztosan üríti a memóriát? A nem mentett módosítások elvesznek.", "Are you sure you want to clean the memory? Unsaved changes will be lost!" };
        public static string[] textWarning = { "Figyelem!", "Warning!" };
        public static string[] textFileBtn = { "Fájl", "File" };
        public static string[] textSaveFileBtn = { "Fájl mentése", "Save file" };
        public static string[] textLoadFileBtn = { "Fájl megnyitása", "Load file" };
        public static string[] textClearMemoryBtn = { "Memória ürítése", "Clean memory" };
        public static string[] textLogOutBtn = { "Kijelentkezés", "Log Out" };
        public static string[] textRegisterBtn = { "Regisztráció", "Register" };
        public static string[] textHelpBtn = { "Súgó", "Help" };
        public static string[] textPeopleBtn = { "Emberek", "People" };
        public static string[] textLanguageBtn = { "English version", "Magyar változat" };
        public static string[] textNotImplementedYet = { "Ez a funkció még nem elérhető! :(", "This function is not implemented yet! :(" };
        // All forms
        public static string[] textCloseBtn = { "Bezárás", "Close" };
        // AddFriendForm
        public static string[] textAddFriendTitle = { "Ismerősök keresése", "Add Friends" };
        public static string[] textSearchLbl = { "Keresés:", "Search" };
        // HelpForm
        public static string[] textHelpFormTitle = { "Súgó:", "Help" };
        public static string[] textAppVersion = { "Verziószám:", "Version:" };
        // LogInForm
        public static string[] textLogInFormTitle = textLogInBtn;
        public static string[] textLoginTextLbl = { "Kérem adja meg adatait a bejelentkezéshez!", "Please enter your log in data!" };
        public static string[] textUserNameLbl = { "Felhasználó név:", "User name:" };
        public static string[] textPasswordLbl = { "Jelszó:", "Password:" };
        public static string[] textLogInSuccess = { "Sikeres bejelentkezés!", "Login Successful!" };
        public static string[] textLogInFailure = { "Sikertelen bejelentkezés, kérem próbálja újra!", "Login failed, please try again!" };
        // MessageForm
        public static string[] textMessageFormTitle = { "Üzenetek", "Chat" };
        public static string[] textSendBtn = { "Küldés!", "Send!" };
        public static string[] textInitialMessage = { "Írjon be egy üzenetet...", "Enter a message..." };
        // ProfileForm
        public static string[] textProfileFormTitle = { "Profil", "Profile" };
        public static string[] textAge = { "Kor", "Age" };
        public static string[] textJob = { "Állás", "Job" };
        public static string[] textTown = { "Lakhely", "Town" };
        public static string[] textPhone = { "Tel.", "Phone" };
        public static string[] textEmail = { "E-mail", "E-mail" };



        #endregion


        public MainForm() {
            InitializeComponent();
            CenterToScreen();
            Init();
        }

        private void Init() {
            InitializeLanguage();

            Icon = Icon.FromHandle(Properties.Resources.Logo.GetHicon());
            BackColor = LIGHT_BLUE;
            pnlFriends.BackColor = LIGHT_BLUE;
            pnlFriends.Left = this.ClientSize.Width / 2 - pnlFriends.Width / 2;
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.FileName = INPUT_FILE;
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog1.FileName = OUTPUT_FILE;
            profileToolStripMenuItem.Enabled = false;
            LogOutCurrentUser();
            
            Person.FriendSeparator = FRIEND_SEPARATOR;


            if (AUTO_LOAD_DATABASE) {
                if (!ReadFile(INPUT_FILE)) {
                    while (!ReadFile()) { }
                }
            }

            if (SEE_EVERYONE) {
                foreach (Person p in people) {
                    OpenUserProfile(p.ID);
                }
            }

            if (AUTO_OPEN_MESSAGES) {

                LoginToNewUser();
                OpenMessages(2);
            }

            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void InitializeLanguage() {
            openFileToolStripMenuItem.Text = textLoadFileBtn[LANG];
            saveFileToolStripMenuItem.Text = textSaveFileBtn[LANG];
            fileToolStripMenuItem.Text = textFileBtn[LANG];
            registerToolStripMenuItem.Text = textRegisterBtn[LANG];
            helpToolStripMenuItem.Text = textHelpBtn[LANG];
            clearMemoryToolStripMenuItem.Text = textClearMemoryBtn[LANG];
            logoutToolStripMenuItem.Text = textLogOutBtn[LANG];
            peopleToolStripMenuItem.Text = textPeopleBtn[LANG];
            languageToolStripMenuItem.Text = textLanguageBtn[LANG];
            UpdatePanel();
        }
            

        #region IO METHODS
        private bool ReadFile(string fileName = null) {
            StreamReader file = null;
            bool success = false;
            Person newPerson;
            Message newMessage;
            string line;

            if (fileName == null) {
                if(openFileDialog1.ShowDialog() == DialogResult.OK) {
                    fileName = openFileDialog1.FileName;
                    Console.WriteLine("File name changed to: " + fileName);
                } 
                else {
                    return success;
                }
            }

            try {
                file = new StreamReader(fileName);
                Console.WriteLine("Attempting to read: " + fileName);
                while (!file.EndOfStream) {

                    line = file.ReadLine();

                    // Read a profile
                    if (line == PROFILE_INDICATOR) {
                        line = file.ReadLine();
                        newPerson = ProcessPerson(line);
                        if (newPerson != null) {
                            people.Add(newPerson);
                            success = true;
                        }
                        else {
                            Console.WriteLine("Error when loading person: " + line);
                        }
                    }
                    // Read a message
                    else if (line == MESSAGE_INDICATOR) {
                        line = file.ReadLine();
                        newMessage = ProcessMessage(line);
                        if (messages != null) {
                            messages.Add(newMessage);
                            success = true;
                        }
                        else {
                            Console.WriteLine("Error when loading message: " + line);
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                if (file != null) {
                    file.Close();
                }
            }

            if (success && people.Count > 0) {
                Console.WriteLine("File loaded!");
                profileToolStripMenuItem.Enabled = true;
            }

            return success;
        }

        private Person ProcessPerson(string rawData) {
            Person newPerson;

            try {
                string[] data = rawData.Split(SEPARATOR);
                newPerson = new Person(int.Parse(data[0]), data[1], data[2], data[3], data[4], int.Parse(data[5]),
                                          data[6], data[7], data[8], data[9], data[10], data[11]);
                return newPerson;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private Message ProcessMessage(string messageString) {
            Message newMessage;

            try {
                string[] messageDetails = messageString.Split(SEPARATOR);
                newMessage = new Message(int.Parse(messageDetails[0]), int.Parse(messageDetails[1]), messageDetails[2]);
                return newMessage;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool SaveFile() {
            StreamWriter file;
            bool success = false;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                file = new StreamWriter(saveFileDialog1.FileName);
                foreach (Person person in people) {
                    file.WriteLine(PROFILE_INDICATOR);
                    file.WriteLine(person.Export(SEPARATOR));
                }
                foreach (Message message in messages) {
                    file.WriteLine(MESSAGE_INDICATOR);
                    file.WriteLine(message.Export(SEPARATOR));
                }


                file.Close();
            }
            return success;
        }
        #endregion


        #region USER METHODS
        private void LoginToNewUser() {
            if(people.Count > 0) {
                if (AUTO_LOGIN) {
                    userID = autoLogInID;
                }
                else {
                    LogInForm login = new LogInForm(people, this);
                    login.ShowDialog();
                    userID = login.GetResult();
                }
                Console.WriteLine("Logged in to: " + userID);
                UpdatePanel();
            }
            else {
                MessageBox.Show(textNoProfiles[LANG]);
                
            }
            
        }

        private void LogOutCurrentUser() {
            userID = -1;
            UpdatePanel();
        }
        #endregion


        #region STATIC FOR OTHER FORMS
        public static int ScaleImageWidth(double originalHeight, double originalWidth, double newHeight) {
            double wantedWidth = originalWidth * (newHeight / originalHeight);
            return (int)wantedWidth;
        }

        public static Person FindPersonByID(int personID, List<Person> group) {
            Person result = null;
            foreach (Person person in group) {
                if (person.ID == personID) {
                    result = person;
                }
            }
            return result;
        }
        #endregion


        private void UpdatePanel() {

            if (userID == -1) {
                pnlFriends.Controls.Clear();
                profileToolStripMenuItem.Text = textLogInBtn[LANG];
                peopleToolStripMenuItem.Enabled = false;
                registerToolStripMenuItem.Visible = true;
            }

            else {
                profileToolStripMenuItem.Text = textMyProfileBtn[LANG];
                peopleToolStripMenuItem.Enabled = true;
                registerToolStripMenuItem.Visible = false;
                pnlFriends.Controls.Clear();

                List<Person> userFriends = new List<Person>();
                List<int> userFriendIDs = null;
                CustomPanel pnl;

                foreach (Person p in people) {
                    if (p.ID == userID) {
                        userFriendIDs = p.Friends;
                    }
                }

                foreach (Person p in people) {
                    if (userFriendIDs.Contains(p.ID)) {
                        userFriends.Add(p);
                    }
                }

                for (int i = 0; i < userFriends.Count; i++) {
                    pnl = new CustomPanel(userFriends[i], PANEL_PROFILE_HEIGHT, pnlFriends.Width - 2 * PANEL_MARGIN_X, panelMessagesClickHandler, Properties.Resources.MessageDark);
                    pnl.Location = new Point(PANEL_MARGIN_X, PANEL_MARGIN_Y + i * (PANEL_PROFILE_HEIGHT + PANEL_GAP_Y));
                    pnl.Click += new EventHandler(freinds_Click);
                    pnlFriends.Controls.Add(pnl);
                }
            }
        }



        private void OpenUserProfile(int id) {
            bool alreadyOpened = false;
            ProfileForm profileForm = null;

            foreach (ProfileForm form in openedProfileForms) {
                if (form.Person.ID == id) {
                    alreadyOpened = true;
                    profileForm = form;
                }
            }
            if (!alreadyOpened) {
                if (id >= 0) {
                    Person user = FindPersonByID(id, people);
                    profileForm = new ProfileForm(user);
                    profileForm.Show();
                    openedProfileForms.Add(profileForm);
                } 
                else {
                    Console.WriteLine("Attemped to open a wrong profile: " + id);
                }
            } 
            else {
                profileForm.BringToFront();
            }


            
        }

        private void OpenMessages(int id) {
            bool alreadyOpened = false;
            MessagesForm messagesForm = null;

            foreach(MessagesForm form in openedMessagesForms) {
                if (form.Target.ID == id) {
                    alreadyOpened = true;
                    messagesForm = form;
                }
            }

            if (!alreadyOpened) {
                Person target = FindPersonByID(id, people);
                Person user = FindPersonByID(userID, people);
                Console.WriteLine("Opening messages from: " + target.FullName);

                messagesForm = new MessagesForm(target, user, messages);
                messagesForm.Show();

                openedMessagesForms.Add(messagesForm);
            } 
            else {
                messagesForm.BringToFront();
            }
            
        }

        private void OpenAddFriend() {
            Console.WriteLine("Opening 'AddFriendForm'");

            AddFriendForm addFriend = new AddFriendForm(people, userID);
            addFriend.ShowDialog();

            UpdatePanel();
        }
        

        // Handlers
        private void panelMessagesClickHandler(object sender, EventArgs e) {
            OpenMessages((sender as CustomButton).Person.ID);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e) {
            ReadFile();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e) {
            if (userID == -1) {
                LoginToNewUser();
            }
            else {
                OpenUserProfile(userID);
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e) {
            if (SaveFile()) {
                MessageBox.Show(textWritingSuccess[LANG]);
            }
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenAddFriend();
        }

        private void messagesToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (Message message in messages) {
                Console.WriteLine(message);
            }
        }

        private void clearMemoryToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show(textCleanMemoryWarning[LANG], textWarning[LANG], MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
                people.Clear();
                messages.Clear();
                LogOutCurrentUser();
            }
        }

        private void fileToolStripMenuItem_DropDownOpened(object sender, EventArgs e) {
            (sender as ToolStripMenuItem).ForeColor = Color.Black;
        }

        private void fileToolStripMenuItem_DropDownClosed(object sender, EventArgs e) {
            (sender as ToolStripMenuItem).ForeColor = Color.White;
        }
        
        public void freinds_Click(object sender, EventArgs e) {
            if (sender is CustomPanel) {
                OpenUserProfile((sender as CustomPanel).Person.ID);
            }
        }

        private void kijelentkezésToolStripMenuItem_Click(object sender, EventArgs e) {
            LogOutCurrentUser();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
            new HelpForm().Show();
        }

        private void languageToolStripMenuItem_Click(object sender, EventArgs e) {
            if (LANG == 0) {
                LANG = 1;
            }
            else {
                LANG = 0;
            }
            InitializeLanguage();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show(textNotImplementedYet[LANG]);
        }
    }
}
