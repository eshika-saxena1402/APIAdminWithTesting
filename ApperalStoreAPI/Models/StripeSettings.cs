using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApperalStoreAPI.Models
{
    public class StripeSettings
    {
        public int StripeSettingsId { get; set; }
        public string SecretKey { get; set; }
        public string PublishableKey { get; set; }

        public Payment Payments { get; set; }
    }
}
