using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public string? ProductColor { get; set; }
        public int? ProductStock { get; set; }
        public string? ProductImage { get; set; }
        public DateTime ProductCreateDate { get; set; }
        public bool ProductStatus { get; set; }


        //ilişkiler
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }

}
