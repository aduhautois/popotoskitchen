using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int CookID { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Completed { get; set; }
        public bool Paid { get; set; }
        public bool Traded { get; set; }
        public bool Active { get; set; }
        public DateTime DateCompleted { get; set; }

        public Order() { }

        public Order(int orderID,
                     int customerID,
                     int cookID,
                     DateTime orderDate,
                     bool paid,
                     bool traded,
                     bool active)
        {
            OrderID = orderID;
            CustomerID = customerID;
            CookID = cookID;
            OrderDate = orderDate;
            Paid = paid;
            Traded = traded;
            Active = active;
        }

        public Order(int orderID,
             int customerID,
             int cookID,
             DateTime orderDate,
             bool completed,
             bool paid,
             bool traded,
             bool active,
             DateTime dateCompleted)
        {
            OrderID = orderID;
            CustomerID = customerID;
            CookID = cookID;
            OrderDate = orderDate;
            Completed = completed;
            Paid = paid;
            Traded = traded;
            Active = active;
            DateCompleted = dateCompleted;
        }

        public Order(int orderID,
                     int customerID,
                     int cookID,
                     DateTime orderDate)
        {
            OrderID = orderID;
            CustomerID = customerID;
            CookID = cookID;
            OrderDate = orderDate;
        }
    }
}
