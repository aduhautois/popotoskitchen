using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class OrderLine
    {
        public int OrderID { get; set; }
        public string RecipeID { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        public bool Active { get; set; }
        public bool Completed { get; set; }
        public DateTime DateCompleted { get; set; }

        public OrderLine() { }

        public OrderLine(int orderID,
                         string recipeID,
                         int price,
                         int quantity,
                         int total,
                         bool active,
                         bool completed,
                         DateTime dateCompleted)
        {
            OrderID = orderID;
            RecipeID = recipeID;
            Price = price;
            Quantity = quantity;
            Total = total;
            Active = active;
            Completed = completed;
            DateCompleted = dateCompleted;
        }
    }
}
