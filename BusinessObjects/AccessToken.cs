using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public sealed class AccessToken : Cook
    {
        public List<Role> Roles { get; private set; }

        public AccessToken() { }

        public AccessToken(Cook c, List<Role> roles)
        {
            if (c == null || roles == null || roles.Count == 0 || !c.Active)
            {
                throw new ApplicationException("Invalid cook.");
            }
            base.CookID = c.CookID;
            base.FirstName = c.FirstName;
            base.LastName = c.LastName;
            base.LocalPhone = c.LocalPhone;
            base.EmailAddress = c.EmailAddress;
            base.UserName = c.UserName;
            base.Active = c.Active;

            Roles = roles;
        }
    }

}
