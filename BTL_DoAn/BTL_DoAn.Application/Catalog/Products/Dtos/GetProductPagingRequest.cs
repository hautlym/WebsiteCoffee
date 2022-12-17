﻿using BTL_DoAn.Application.Catalog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.Products.Dtos
{
    public class GetProductPagingRequest:PagingRequestBase
    {
        public string? keyword { get; set; }
        public int? CategoryId { get; set; }
    }
}
