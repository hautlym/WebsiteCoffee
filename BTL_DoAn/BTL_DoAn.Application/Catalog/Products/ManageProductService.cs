using BTL_DoAn.Application.Catalog.Common;
using BTL_DoAn.Application.Catalog.Products.Dtos;
using BTL_DoAn.Application.Catalog.Products.ProductImgs;
using BTL_DoAn.Application.Catalog.System.Dtos;
using BTL_DoAn.Data.EF;
using BTL_DoAn.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly BTL_DoAnDbContext _context;
        private readonly IStorageService _storageService;
        public ManageProductService(BTL_DoAnDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(ProductCreateRequest request)
        {

            var product = new Product()
            {
                ProductName = request.ProductName,
                ProductDescription = request.ProductDescription,
                ProductPrice = request.ProductPrice,
                ProductTitle = request.ProductTitle,
                CountView = 0,
                Status= request.Status,
                Discount = request.Discount,
                CategoryId = request.CategoryId,
                PolicyId = request.PolicyId,
            };
            if (request.ThumbnailImage != null)
            {
                product.productImgs = new List<ProductImg>()
                {
                    new ProductImg()
                    {
                        Caption = "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            _context.products.Add(product);
            await _context.SaveChangesAsync();
            return product.ProductId;

        }
        public async Task<int> Delete(int productId)
        {
            var product = await _context.products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            if (product == null) throw new BTL_DoAnException("Can not find product");
            var image = _context.ProductImg.Where(x => x.ProductId == productId);
            foreach (var img in image)
            {
                await _storageService.DeleteFileAsync(img.ImagePath);
            }
            _context.products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public List<ProductViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<PageResult<ProductViewModel>>> GetAllPaging(GetProductPagingRequest request)
        {
            var query = from product in _context.products
                        join c in _context.Categories on product.CategoryId equals c.CategoryId
                        select new { product, c};
            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.product.ProductName.Contains(request.keyword));
            }
            if (request.CategoryId != null && request.CategoryId != 0)
            {
                query = query.Where(x => x.c.CategoryId == request.CategoryId);
            }
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.product.ProductId,
                    ProductName = x.product.ProductName,
                    ProductDescription = x.product.ProductDescription,
                    ProductPrice = x.product.ProductPrice,
                    ProductTitle = x.product.ProductTitle,
                    CountView = x.product.CountView,
                    Status = x.product.Status,
                    CategoryName = x.c.CategoryName,
                    Discount = x.product.Discount,
                    CategoryId = x.product.CategoryId,
                    ThumbnailImage = x.product.productImgs

                }).ToListAsync();
            var pageResult = new PageResult<ProductViewModel>
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };
            return new ApiSuccessResult<PageResult<ProductViewModel>>(pageResult);
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {

            var product = await _context.products.FindAsync(request.Id);
            if (product == null) throw new BTL_DoAnException("Can not find product");
            product.ProductName = request.ProductName;
            product.ProductPrice = request.ProductPrice;
            product.ProductDescription = request.ProductDescription;
            product.ProductTitle = request.ProductTitle;
            product.CountView = request.CountView;
            product.Status = request.Status;
            product.Discount = request.Discount;
            product.CategoryId = request.CategoryId;
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProductImg.FirstOrDefaultAsync(x => x.ProductId == request.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImg.Update(thumbnailImage);
                }

            }
            _context.Update(product);
            return await _context.SaveChangesAsync();
        }
        public async Task<string> SaveFile(IFormFile file)
        {

            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<ProductViewModel> GetById(int productId)
        {
            var products = _context.products.Where(x => x.ProductId == productId).Select(product => new ProductViewModel()
            {
                Id = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductDescription = product.ProductDescription,
                ProductTitle = product.ProductTitle,
                Status = product.Status,
                CountView = product.CountView,               
                Discount = product.Discount,
                CategoryId = product.CategoryId,
                ThumbnailImage = product.productImgs
            }).FirstOrDefault();
            //if(product == null) 
            //    throw new BTL_KTPMException("Can not find product");
            return products;

        }

        public async Task<int> AddImage(int productId, ProductImageCreateRequest request)
        {
            var productImage = new ProductImg()
            {
                Caption = request.Caption,
                DateCreated = DateTime.Now,
                IsDefault = request.IsDefault,
                ProductId = productId,
                SortOrder = request.SortOrder
            };

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImg.Add(productImage);
            await _context.SaveChangesAsync();
            return productImage.Id;
        }

        public async Task<int> RemoveImage(int imageId)
        {
            var productImage = await _context.ProductImg.FindAsync(imageId);
            if (productImage == null)
                throw new BTL_DoAnException($"Cannot find an image with id {imageId}");
            _context.ProductImg.Remove(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request)
        {
            var productImage = await _context.ProductImg.FindAsync(imageId);
            if (productImage == null)
                throw new BTL_DoAnException($"Cannot find an image with id {imageId}");

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImg.Update(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<ProductImageViewModel> GetImageById(int imageId)
        {
            var image = await _context.ProductImg.FindAsync(imageId);
            if (image == null)
                throw new BTL_DoAnException($"Cannot find an image with id {imageId}");

            var viewModel = new ProductImageViewModel()
            {
                Caption = image.Caption,
                DateCreated = image.DateCreated,
                FileSize = image.FileSize,
                Id = image.Id,
                ImagePath = image.ImagePath,
                IsDefault = image.IsDefault,
                ProductId = image.ProductId,
                SortOrder = image.SortOrder
            };
            return viewModel;
        }

        public async Task<List<ProductImageViewModel>> GetListImages(int productId)
        {
            return await _context.ProductImg.Where(x => x.ProductId == productId)
                .Select(i => new ProductImageViewModel()
                {
                    Caption = i.Caption,
                    DateCreated = i.DateCreated,
                    FileSize = i.FileSize,
                    Id = i.Id,
                    ImagePath = i.ImagePath,
                    IsDefault = i.IsDefault,
                    ProductId = i.ProductId,
                    SortOrder = i.SortOrder
                }).ToListAsync();
        }
    }

}
