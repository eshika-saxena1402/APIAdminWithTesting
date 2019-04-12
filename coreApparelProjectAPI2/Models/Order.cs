using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreApparelProjectAPI2.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Units { get; set; }
        public double OrderAmount { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
