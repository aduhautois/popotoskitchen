using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Cook
    {
        public int CookID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string LocalPhone { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }
        public bool Active { get; set; }

        public Cook() { }

        public Cook(int cookID,
                    string firstName,
                    string lastName,
                    string userName,
                    string localPhone,
                    string emailAddress,
                    string passwordHash,
                    bool active)
        {
            CookID = cookID;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            LocalPhone = localPhone;
            EmailAddress = emailAddress;
            PasswordHash = passwordHash;
            Active = active;
        }

        public Cook(int cookID,
            string firstName,
            string lastName,
            string userName,
            string localPhone,
            string emailAddress,
            bool active)
        {
            CookID = cookID;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            LocalPhone = localPhone;
            EmailAddress = emailAddress;
            Active = active;
        }
    }
}
