using BTL_DoAn.Application.Catalog.Common;
using BTL_DoAn.Application.Catalog.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.Products
{
    public interface IPublicProductService
    {
         Task<PageResult<ProductViewModel>> getAllByCategoryId(GetPublicProductRequest request);

         Task<List<ProductViewModel>> GetAll ();
         Task<List<ProductViewModel>> GetProductByName (string Name);
    }
}
