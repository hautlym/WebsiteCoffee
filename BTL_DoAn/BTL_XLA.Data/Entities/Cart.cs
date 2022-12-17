using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Data.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Voucher { get; set; }
        public Guid AppUserId { get; set; }
        public Product Product { get; set; }
        public DateTime DateCreated { get; set; }
        public AppUser AppUser { get; set; }
    }
}
