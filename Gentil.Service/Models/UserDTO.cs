﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gentil.Service.Models
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RoleID { get; set; }
        public string Role { get; set; }
    }
}
