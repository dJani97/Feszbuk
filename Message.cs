using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feszbuk {
    public class Message {
        // Static (unused)
        public static string[] AutoMessages { get; set; }

        // Message
        public int SenderID { get; private set; }
        public int ReceiverID { get; private set; }
        public string Content { get; private set; }


        private string content;

        public string AccessContent {
            get {
                return content;
            }
            set {
                content = value;
            }
        }


        // Constructor
        public Message(int senderID, int receiverID, string content) {
            SenderID = senderID;
            ReceiverID = receiverID;
            Content = content;
        }

        // Methods


        public override string ToString() {
            return String.Format("\n**message information: **\nSender ID: {0}\nReceiver ID: {1}\nContent: {2}", SenderID, ReceiverID, Content);
        }

        public string Export(char separator) {
            return String.Join(separator.ToString(), SenderID, ReceiverID, Content);
        }
    }
}
