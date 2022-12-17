
using BTL_DoAn.Application.Catalog.Contacts.Dtos;
using BTL_DoAn.Application.Catalog.System.Dtos;
using BTL_DoAn.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.ApiIntegration.Service.ContactApiClient
{
    public interface IContactApiClient
    {
        Task<ApiResult<List<Contact>>> GetAll();
        Task<ApiResult<bool>> CreateContact(CreateContactRequest request);
        Task<Contact> GetById(int id);
        Task<bool> Delete(int id);
    }
}
