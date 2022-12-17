using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Data.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public string Status { get; set; }
        public int CountView { get; set; }
        public double Discount { get; set; }
        public int CategoryId { get; set; }
        public int? PolicyId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Cart> Carts { get; set; }
        public Category category { get; set; }
        public Policy policy { get; set; }
        public List<ProductImg> productImgs { get; set; }

    }
}
