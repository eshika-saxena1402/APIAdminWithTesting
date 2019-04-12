using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreApparelProjectAPI2.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductSize { get; set; }
        public string ProductDescription { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
