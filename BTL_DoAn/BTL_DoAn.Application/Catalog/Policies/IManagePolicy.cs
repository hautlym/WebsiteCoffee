using BTL_DoAn.Application.Catalog.Common;
using BTL_DoAn.Application.Catalog.Policies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.Policies
{
    public interface IManagePolicy
    {
        Task<List<PolicyViewModels>> GetAllPolicy();
        Task<PageResult<PolicyViewModels>> GetAlllPaging(GetPolicyRequest request);
        Task<int> Create(CreatePolicyRequest request);
        Task<int> Update(UpdatePolicyRequest request);
        Task<int> Delete(int PolicyId);
        Task<PolicyViewModels> GetById(int PolicyId);
    }
}
