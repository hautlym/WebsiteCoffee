using BTL_DoAn.Application.Catalog.Common;
using BTL_DoAn.Application.Catalog.Products.Dtos;
using BTL_DoAn.Application.Catalog.System.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);
        Task<ProductViewModel> GetById(int productId);

        Task<int> Delete(int productId);
        public List<ProductViewModel> GetAll();
        Task<ApiResult<PageResult<ProductViewModel>>> GetAllPaging(GetProductPagingRequest request);

       
    }
}
