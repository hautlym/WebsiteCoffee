using BTL_DoAn.Application.Catalog.Common;
using BTL_DoAn.Application.Catalog.Policies.Dtos;
using BTL_DoAn.Data.EF;
using BTL_DoAn.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.Policies
{
    public class ManagePolicy : IManagePolicy
    {
        private readonly BTL_DoAnDbContext _context;

        public ManagePolicy(BTL_DoAnDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CreatePolicyRequest request)
        {
            var policy = new Policy()
            {
                PolicyName = request.PolicyName,
                PolicyDescription = request.PolicyDescription,
                Discount = request.Discount,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Voucher = request.Voucher,
                ProductId = request.ProductId,
            };
            _context.Policies.Add(policy);
            await _context.SaveChangesAsync();
            return policy.PolicyId;
            throw new NotImplementedException();
        }

        public async Task<int> Delete(int PolicyId)
        {
            var policy = await _context.Policies.Where(x => x.PolicyId == PolicyId).FirstOrDefaultAsync();
            if (policy == null) throw new BTL_DoAnException("Can not find category");
            _context.Policies.Remove(policy);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<PolicyViewModels>> GetAllPolicy()
        {
            var data = await _context.Policies.Select(x => new PolicyViewModels()
            {
                PolicyId = x.PolicyId,
                PolicyName = x.PolicyName,
                PolicyDescription = x.PolicyDescription,
                ProductId = x.ProductId,
                Discount = x.Discount,
                EndDate = x.EndDate,
                StartDate = x.StartDate,
                Voucher = x.Voucher,
            }).ToListAsync();
            return data;
        }

        public async Task<PageResult<PolicyViewModels>> GetAlllPaging(GetPolicyRequest request)
        {
            var query = from p in _context.Policies
                        select p;
            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.PolicyName.Contains(request.keyword));
            }
            var totalRow = query.Count();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(x => new PolicyViewModels()
            {
                PolicyId = x.PolicyId,
                PolicyName = x.PolicyName,
                PolicyDescription = x.PolicyDescription,
                ProductId = x.ProductId,
                Discount = x.Discount,
                EndDate = x.EndDate,
                StartDate = x.StartDate,
                Voucher = x.Voucher,
            }).ToListAsync();
            var pageResult = new PageResult<PolicyViewModels>
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };
            return pageResult;
        }

        public async Task<PolicyViewModels> GetById(int PolicyId)
        {
            var policy = await _context.Policies.Where(x => x.PolicyId == PolicyId).FirstOrDefaultAsync();

            if (policy != null)
            {
                var policyViewModels = new PolicyViewModels()
                {
                    PolicyId = policy.PolicyId,
                    PolicyName = policy.PolicyName,
                    PolicyDescription = policy.PolicyDescription,
                    ProductId = policy.ProductId,
                    Discount = policy.Discount,
                    EndDate = policy.EndDate,
                    StartDate = policy.StartDate,
                    Voucher = policy.Voucher,
                };
                return policyViewModels;
            }
            else
            {
                return null;
            }
        }

        public async Task<int> Update(UpdatePolicyRequest request)
        {
            var policy = await _context.Policies.Where(x => x.PolicyId == request.PolicyId).FirstOrDefaultAsync();
            if (policy == null) throw new BTL_DoAnException("Can not find policy");
            policy.PolicyName = request.PolicyName;
            policy.PolicyDescription = request.PolicyDescription;
            policy.Discount = request.Discount;
            policy.StartDate = request.StartDate;
            policy.EndDate = request.EndDate;
            policy.Voucher = request.Voucher;
            policy.ProductId = request.ProductId;
            _context.Policies.Update(policy);
            return await _context.SaveChangesAsync();
        }
    }
}
