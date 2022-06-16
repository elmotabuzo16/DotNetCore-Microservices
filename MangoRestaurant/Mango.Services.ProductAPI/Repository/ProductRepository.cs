using Mango.Services.ProductAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mango.Services.ProductAPI.DbContexts;
using AutoMapper;
using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicaitonDbContext _db;
        private IMapper _mapper;

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();

            return _mapper.Map<List<ProductDto>>(productList);
        }

        public async Task<ProductDto> GetProductsById(int productId)
        {
            Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public ProductRepository(ApplicaitonDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);

            // Updates
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                // Creates
                _db.Products.Add(product);
            }

            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

                if(product == null)
                {
                    return false;
                }
                
                _db.Products.Remove(product);
                _db.SaveChangesAsync();

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }


    }
}
