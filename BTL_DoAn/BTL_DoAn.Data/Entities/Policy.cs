using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Data.Entities
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
        public int PolicyDescription { get; set; }
        public double  Discount { get; set; }
        public int? ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Voucher { get; set; }

        public List<Product> ListProduct { get; set; }
    }
}
