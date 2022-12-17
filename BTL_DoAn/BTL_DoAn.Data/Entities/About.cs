using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Data.Entities
{
    public class About
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string NumberPhone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string AddressInMap { get; set; }
    }
}
