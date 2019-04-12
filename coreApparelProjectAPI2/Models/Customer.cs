using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreApparelProjectAPI2.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
