using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gentil.Service.Models
{
    public class ClientDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}