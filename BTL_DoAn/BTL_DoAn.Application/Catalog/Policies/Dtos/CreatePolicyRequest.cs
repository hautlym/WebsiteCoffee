using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.Policies.Dtos
{
    public class CreatePolicyRequest
    {
        public string PolicyName { get; set; }
        public string PolicyDescription { get; set; }
        public double Discount { get; set; }
        public int? ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Voucher { get; set; }
    }
}
