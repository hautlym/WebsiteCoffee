

using BTL_DoAn.Application.Catalog.Categories;
using BTL_DoAn.Application.Catalog.Categories.Dtos;
using BTL_DoAn.Application.Catalog.Common;
using BTL_DoAn.Application.Catalog.System.Dtos;

namespace BTL_DoAn.ApiIntegration.Service.CategoryApiClient
{
    public interface ICategoriesApiClient
    {
        Task<ApiResult<List<CategoryViewModels>>> GetAll();
        Task<PageResult<CategoryViewModels>> GetAllPaging(GetCategoryRequest request);
        Task<ApiResult<bool>> CreateCategory(CreateCategoryRequest request);
        Task<bool> UpdateCategory(int id, UpdateCategoryRequest request);
        Task<CategoryViewModels> GetById(int id);
        Task<bool> Delete(int id);
    }
}
