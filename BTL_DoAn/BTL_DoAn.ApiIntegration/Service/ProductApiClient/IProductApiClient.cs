using BTL_DoAn.Application.Catalog.Common;
using BTL_DoAn.Application.Catalog.Products.Dtos;
using BTL_DoAn.Application.Catalog.System.Dtos;

namespace BTL_DoAn.ApiIntegration.Service.ProductApiClient
{
    public interface IProductApiClient
    {
        Task<ApiResult<PageResult<ProductViewModel>>> GetPaging(GetProductPagingRequest request);
        Task<List<ProductViewModel>> GetAll();
        Task<bool> CreateProduct(ProductCreateRequest request);
        Task<bool> UpdateProduct(int id, ProductUpdateRequest request);
        Task<ProductViewModel> GetById(int id);
        Task<bool> Delete(int id);
    }
}
