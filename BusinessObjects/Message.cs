using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Message
    {

        public DateTime MessageDate { get; set; }
        public int CookID { get; set; }
        public string MessageSubject { get; set; }
        public bool HasRead { get; set; }
        public string MessageText { get; set; }
        public int MessageID { get; set; }
        public bool Active { get; set; }

        public Message() { }

        public Message(int messageID,
                       int cookID,
                       string messageSubject,
                       string messageText,
                       DateTime messageDate,
                       bool active,
                       bool hasRead)
        {
            MessageID = messageID;
            CookID = cookID;
            MessageSubject = messageSubject;
            MessageText = messageText;
            MessageDate = messageDate;
            Active = active;
            HasRead = hasRead;
        }
    }
}
