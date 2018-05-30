using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gentil.Business.Models
{
    public class Client
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
