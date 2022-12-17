using BTL_DoAn.Application.Catalog.Products.Dtos;

namespace BTL_DoAn.WebApp.Models
{
    public class DetailsProductViewModels
    {
        public ProductViewModel ProductDeltails { get; set; }
        public List<ProductViewModel> SuggestProduct { get; set; }
    }
}
