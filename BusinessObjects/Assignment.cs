using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Assignment
    {
        public int CookID { get; set; }
        public string RoleID { get; set; }
        public bool Active { get; set; }

        public Assignment() { }
        
        public Assignment(int cookID,
                          string roleID,
                          bool active)
        {
            CookID = cookID;
            RoleID = roleID;
            Active = active;
        }
    }
}
