using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gentil.Business.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public virtual Role Role { get; set; }
    }
}
