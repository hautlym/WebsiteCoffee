using BTL_DoAn.Application.Catalog.Common;
using BTL_DoAn.Application.Catalog.Policies;
using BTL_DoAn.Application.Catalog.Policies.Dtos;
using BTL_DoAn.Application.Catalog.System.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.ApiIntegration.Service.PoliciesApiClient
{
    public interface IPolicyApiClient
    {
        Task<ApiResult<List<PolicyViewModels>>> GetAll();
        Task<PageResult<PolicyViewModels>> GetAllPaging(GetPolicyRequest request);
        Task<ApiResult<bool>> CreatePolicy(CreatePolicyRequest request);
        Task<bool> UpdatePolicy(int id, UpdatePolicyRequest request);
        Task<PolicyViewModels> GetById(int id);
        Task<bool> Delete(int id);
    }
}
