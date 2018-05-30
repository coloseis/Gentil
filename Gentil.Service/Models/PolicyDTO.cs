using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gentil.Service.Models
{
    public class PolicyDTO
    {
        public Guid ID { get; set; }
        public decimal AmountInsured { get; set; }
        public string Email { get; set; }
        public DateTime InceptionDate { get; set; }
        public bool InstallmentPayment { get; set; }
        public Guid ClientID { get; set; }
    }
}
