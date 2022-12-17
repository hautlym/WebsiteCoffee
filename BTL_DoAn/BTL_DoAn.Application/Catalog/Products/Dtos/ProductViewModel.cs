using BTL_DoAn.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.Products.Dtos
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public string Status { get; set; }
        public int CountView { get; set; }
        public double Discount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ProductImg> ThumbnailImage { get; set; }
    }
}
