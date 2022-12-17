﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Data.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public string ShipNumberPhone { get; set; }
        public string ShipDescription { get; set; }
        public string ShippingFee { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }

}
