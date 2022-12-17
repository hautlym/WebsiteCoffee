using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.Orders.Dtos
{
    public class CreateOrderRequest
    {
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public string ShipNumberPhone { get; set; }
        public string ShipDescription { get; set; }
        public double Price { get; set; }
        public Guid AppUserId { get; set; }
    }
}
