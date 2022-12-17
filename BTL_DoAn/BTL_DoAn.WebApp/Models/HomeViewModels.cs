using BTL_DoAn.Application.Catalog.Products.Dtos;

namespace BTL_DoAn.WebApp.Models
{
    public class HomeViewModels
    {
        public List<ProductViewModel> CoffeeProduct { get; set; }
        public List<ProductViewModel> Drinkproduct { get; set; }
        public List<ProductViewModel> FastFoodProduct { get; set; }

    }
}
