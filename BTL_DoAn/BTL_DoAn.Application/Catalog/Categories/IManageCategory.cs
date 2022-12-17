using BTL_DoAn.Application.Catalog.Categories.Dtos;
using BTL_DoAn.Application.Catalog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.Categories
{
    public interface IManageCategory
    {
        Task<List<CategoryViewModels>> GetAllCategory();
        Task<PageResult<CategoryViewModels>> GetAlllPaging(GetCategoryRequest request);
        Task<int> Create(CreateCategoryRequest request);
        Task<int> Update(UpdateCategoryRequest request);
        Task<int> Delete(int CategoryId);
        Task<CategoryViewModels> GetById(int categoryId);
    }
}
