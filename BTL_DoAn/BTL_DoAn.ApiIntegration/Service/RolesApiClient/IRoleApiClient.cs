
using BTL_DoAn.Application.Catalog.System.Dtos;

namespace BTL_DoAn.ApiIntegration.Service.RolesApiClient
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RolesViewModel>>> GetAll();
    }
}
