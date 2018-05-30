using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Gentil.WebAPI.Autorize
{
    public class GentilPrincipal : GenericPrincipal
    {
        public GentilPrincipal(Guid id, string user, IIdentity identity, string[] roles) : base(identity, roles)
        {
            this.ID = id;
            this.Name = user;
            this.Role = roles[0];
        }

        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}