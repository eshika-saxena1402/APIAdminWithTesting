using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreApparelProjectAPI2.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        //public virtual List<Product> Products { get; set; }
    }
}
