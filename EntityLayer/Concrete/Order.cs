using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string OrderClient { get; set; }
        public string OrderEmail { get; set; }
        public string OrderAddress { get; set; }
        public string OrderCity { get; set; }
        public string OrderPhoneNumber { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
