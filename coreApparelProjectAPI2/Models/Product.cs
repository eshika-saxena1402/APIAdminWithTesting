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
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }

    }
}
