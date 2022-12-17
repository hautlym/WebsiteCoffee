using BTL_DoAn.Application.Catalog.Carts.Dtos;
using BTL_DoAn.Application.Catalog.Common;
using BTL_DoAn.Data.EF;
using BTL_DoAn.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.Carts
{
    public class ManagerCart : IManageCart
    {
        private readonly BTL_DoAnDbContext _context;

        public ManagerCart(BTL_DoAnDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(CreateCartRequest request)
        {
            var cart = new Cart()
            {
                ProductId = request.ProductId,
                AppUserId = request.UserId,
                Quantity = request.Quantity,
                Voucher = "dsfghjk",
            };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart.CartId;
        }

        public async Task<int> Delete(int CartId)
        {
            var cart = _context.Carts.Where(x => x.CartId == CartId).FirstOrDefault();
            if (cart == null) throw new BTL_DoAnException("Can not find cart");
            _context.Carts.Remove(cart);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<CartViewModel>> GetAllCart()
        {
            var cart = from p in _context.products
                       join c in _context.Carts on p.ProductId equals c.ProductId
                       join u in _context.appUsers on c.AppUserId equals u.Id
                       select new
                       {
                           UserName = u.FirstName + u.LastName,
                           c.CartId,
                           p.ProductName,
                           p.ProductPrice,
                           p.Discount,
                           c.Quantity,
                           Img = p.productImgs.Count > 0 ? p.productImgs[0].ImagePath : "",
                           u.Address,
                           voucher = c.Voucher
                       };

            var data = await cart.Select(x => new CartViewModel()
            {
                id = x.CartId,
                UserName = x.UserName,
                Discount = x.Discount,
                ProductNane = x.ProductName,
                ProductPrice = x.ProductPrice,
                Quantity = x.Quantity,
                ImgUrl = x.Img,
                Address = x.Address,
                voucher = x.voucher
            }).ToListAsync();
            return data;
        }

        public async Task<List<CartViewModel>> GetAllCartByUserId(Guid UserId)
        {
            var cart = from p in _context.products
                       join c in _context.Carts on p.ProductId equals c.ProductId
                       join u in _context.appUsers on c.AppUserId equals u.Id
                       select new
                       {
                           UserId = u.Id,
                           UserName = u.FirstName + u.LastName,
                           c.CartId,
                           p.ProductName,
                           p.ProductPrice,
                           p.Discount,
                           c.Quantity,
                           Img = p.productImgs.Count > 0 ? p.productImgs[0].ImagePath : "",
                           u.Address,
                           voucher = c.Voucher
                       };

            var data = await cart.Where(x => x.UserId == UserId).Select(x => new CartViewModel()
            {
                id = x.CartId,
                UserName = x.UserName,
                Discount = x.Discount,
                ProductNane = x.ProductName,
                ProductPrice = x.ProductPrice,
                Quantity = x.Quantity,
                ImgUrl = x.Img,
                Address = x.Address,
                voucher = x.voucher
            }).ToListAsync();
            return data;
        }

        public async Task<CartViewModel> GetById(int CartId)
        {

            var cart = from p in _context.products
                       join c in _context.Carts on p.ProductId equals c.ProductId
                       join u in _context.appUsers on c.AppUserId equals u.Id
                       select new
                       {
                           UserId = u.Id,
                           UserName = u.FirstName + u.LastName,
                           c.CartId,
                           p.ProductName,
                           p.ProductPrice,
                           p.Discount,
                           c.Quantity,
                           Img = p.productImgs.Count > 0 ? p.productImgs[0].ImagePath : "",
                           u.Address,
                           Phone = u.PhoneNumber,
                           voucher = c.Voucher
                       };

            var data = await cart.Where(x => x.CartId == CartId).Select(x => new CartViewModel()
            {
                id = x.CartId,
                UserName = x.UserName,
                Discount = x.Discount,
                ProductNane = x.ProductName,
                ProductPrice = x.ProductPrice,
                Quantity = x.Quantity,
                ImgUrl = x.Img,
                Address = x.Address,
                Phone = x.Phone,
                voucher = x.voucher

            }).FirstOrDefaultAsync();

            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }

        public async Task<int> Update(UpdateCartRequest request)
        {
            var cart = await _context.Carts.Where(x => x.CartId == request.id).FirstOrDefaultAsync();
            if (cart == null) throw new BTL_DoAnException("Can not find product");

            cart.ProductId = request.ProductId;
            cart.Quantity = request.Quantity;
            _context.Update(cart);
            return await _context.SaveChangesAsync();
        }
    }
}
