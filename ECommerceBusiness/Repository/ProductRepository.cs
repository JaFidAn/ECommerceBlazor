using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceBusiness.Repository.IRepository;
using ECommerceDataAccess;
using ECommerceDataAccess.Data;
using ECommercyModels.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ECommerceBusiness.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProductDTO> Create(ProductDTO objDTO)
        {
            Product product = _mapper.Map<ProductDTO, Product>(objDTO);

            var addedProduct = _db.Products.Add(product);
            await _db.SaveChangesAsync();


            return _mapper.Map<Product, ProductDTO>(product);
        }

        public async Task<int> Delete(int id)
        {
            Product deletedProduct = await _db.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (deletedProduct != null)
            {
                _db.Products.Remove(deletedProduct);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<ProductDTO> Get(int id)
        {
            Product product = await _db.Products.Include(u => u.Category).FirstOrDefaultAsync(c => c.Id == id);
            if (product != null)
            {
                return _mapper.Map<Product, ProductDTO>(product);
            }
            return new ProductDTO();
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.Products.Include(u => u.Category));
        }

        public async Task<ProductDTO> Update(ProductDTO objDTO)
        {
            Product updatedProduct = await _db.Products.FirstOrDefaultAsync(c => c.Id == objDTO.Id);
            if (updatedProduct != null)
            {
                updatedProduct.Name = objDTO.Name;
                updatedProduct.Descripton = objDTO.Descripton;
                updatedProduct.ShopFavorites = objDTO.ShopFavorites;
                updatedProduct.CustomerFavorites = objDTO.CustomerFavorites;
                updatedProduct.Color = objDTO.Color;
                updatedProduct.ImageUrl = objDTO.ImageUrl;
                updatedProduct.CategoryId = objDTO.CategoryId;
                _db.Products.Update(updatedProduct);
                await _db.SaveChangesAsync();
                return _mapper.Map<Product, ProductDTO>(updatedProduct);
            }
            return objDTO;
        }
    }
}