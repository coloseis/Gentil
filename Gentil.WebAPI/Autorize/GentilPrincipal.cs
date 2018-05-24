using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Gentil.WebAPI.Autorize
{
    public class GentilPrincipal : GenericPrincipal
    {
        public GentilPrincipal(int id, string user, IIdentity identity, string[] roles) : base(identity, roles)
        {
            this.ID = id;
            this.User = user;
            this.RoleID = int.Parse(roles[0]);
        }

        public int ID { get; set; }
        public string User { get; set; }
        public int RoleID { get; set; }
    }
}