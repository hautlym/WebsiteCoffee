using BTL_DoAn.Application.Catalog.Orders.Dtos;
using BTL_DoAn.Data.Entities;

namespace BTL_DoAn.AdminApp.Models
{
    public class ModelViewOrderDetail
    {
        public OrderViewModel OrderModel { get; set; }
        public List<Product> product { get; set; }

    }
}
