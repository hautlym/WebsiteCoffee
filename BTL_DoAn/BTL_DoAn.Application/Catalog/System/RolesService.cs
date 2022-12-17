﻿using BTL_DoAn.Application.Catalog.System;
using BTL_DoAn.Application.Catalog.System.Dtos;
using BTL_DoAn.Data.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.System
{
    public class RolesService : IRolesService
    {
        private readonly RoleManager<AppRoles> _roleManager;
        public RolesService(RoleManager<AppRoles> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<List<RolesViewModel>> GetAll()
        {
            var roles = await _roleManager.Roles
                   .Select(x => new RolesViewModel()
                   {
                       Id = x.Id,
                       Name = x.Name,
                       Description = x.Description
                   }).ToListAsync();

            return roles;
        }
    }
}
