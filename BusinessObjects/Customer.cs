using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LocalPhone { get; set; }
        public string EmailAddress { get; set; }
        public string FreeCompany { get; set; }
        public bool Active { get; set; }

        public Customer() { }

        public Customer(int customerID,
                        string firstName,
                        string lastName,
                        string localPhone,
                        string emailAddress,
                        string freeCompany)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            LocalPhone = localPhone;
            EmailAddress = emailAddress;
            FreeCompany = freeCompany;
        }

        public Customer(int customerID,
                string firstName,
                string lastName,
                string localPhone,
                string emailAddress,
                string freeCompany,
                bool active)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            LocalPhone = localPhone;
            EmailAddress = emailAddress;
            FreeCompany = freeCompany;
            Active = active;
        }
    }
}
