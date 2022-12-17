using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.Carts.Dtos
{
    public class CreateCartRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Guid UserId { get; set; }
        public string voucher { get; set; }
    }
}
