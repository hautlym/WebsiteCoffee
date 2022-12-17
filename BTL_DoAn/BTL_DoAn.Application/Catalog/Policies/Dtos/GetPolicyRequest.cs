using BTL_DoAn.Application.Catalog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.Policies.Dtos
{
    public class GetPolicyRequest : PagingRequestBase
    {
        public string? keyword { get; set; }
    }
}
