using BTL_DoAn.Application.Catalog.System.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.System
{
    public interface IRolesService
    {
        Task<List<RolesViewModel>> GetAll();
    }
}
