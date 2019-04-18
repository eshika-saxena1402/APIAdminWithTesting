using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApperalStoreAPI.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int CardDigit { get; set; }
        public string Description { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int StripeSettingsId { get; set; }
        public StripeSettings StripeSettings { get; set; }
        public int CustomerId { get; set; }
    }
}
