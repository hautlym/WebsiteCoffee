﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.Carts.Dtos
{
    public class UpdateCartRequest
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? voucher { get; set; }
    }
}
