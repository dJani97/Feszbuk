using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feszbuk {
    public class Person {
        // Static
        public static char FriendSeparator { get; set; }

        // Identification
        private string usr;
        private string pwd;

        // Public and fixed
        public int ID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName {
            get {
                if(MainForm.LANG == 0) {
                    return LastName + " " + FirstName;
                }
                else {
                    return FirstName + " " + LastName;
                }
                
            }
        }
        public int BirthYear { get; private set; }
        public int Age {
            get {
                return DateTime.Now.Year - BirthYear;
            }
        }

        // Public and free
        public string Town { get; set; }
        public string Job { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Picture { get; set; }

        // Social
        public List<int> Friends = new List<int>();

        // Constructor
        public Person(int id, string usrName, string password, string firstName, string lastName, int birthYear, string town, string job, string email, string phoneNumber, string picture, string friends) {
            ID = id;
            usr = usrName;
            pwd = password;
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
            Town = town;
            Job = job;
            Email = email;
            PhoneNumber = phoneNumber;
            Picture = picture;

            if(friends != "-") {
                string[] friends_split = friends.Split(FriendSeparator);
                foreach(string friend in friends_split) {
                    Friends.Add(int.Parse(friend));
                }
            }
        }



        // Methods

        public bool LogIn(string userName, string password) {
            if (userName == this.usr && password == this.pwd) {
                return true;
            }
            return false;
        }
        

        public override string ToString() {
            return String.Format("\n**profile information:**\nID: {0}\nUser Name: {1}\nPassword: {2}\nFull name: {3}\nYear of birt: {4}\nTown: {5}\nJob: {6}\nE-mail: {7}\nPhone: {8}\nPicture: {9}\nFriends: {10}"
                                    , ID, usr, pwd, FullName, BirthYear, Town, Job, Email, PhoneNumber, Picture, String.Join(", ", Friends));
        }

        public string Export(char separator) {
            string friendsString;
            if (Friends.Count > 0) {
                friendsString = String.Join(FriendSeparator.ToString(), Friends);
            } else {
                friendsString = "-";
            }
            return String.Join(separator.ToString(), ID, usr, pwd, FirstName, LastName, BirthYear, Town, Job, Email, PhoneNumber, Picture, friendsString);
        }
    }
}
