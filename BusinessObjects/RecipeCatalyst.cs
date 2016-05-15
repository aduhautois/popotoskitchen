using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class RecipeCatalyst
    {
        public string Crystal { get; set; }
        public int Quantity { get; set; }

        public RecipeCatalyst() { }

        public RecipeCatalyst(string crystal,
                              int quantity)
        {
            Crystal = crystal;
            Quantity = quantity;
        }
    }
}
