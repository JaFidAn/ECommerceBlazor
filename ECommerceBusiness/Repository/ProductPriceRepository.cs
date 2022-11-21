using System.Data.Common;
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
    public class ProductPriceRepository : IProductPriceRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ProductPriceRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProductPriceDTO> Create(ProductPriceDTO objDTO)
        {
            ProductPrice productPrice = _mapper.Map<ProductPriceDTO, ProductPrice>(objDTO);

            var addedProductPrice = _db.ProductPrices.Add(productPrice);
            await _db.SaveChangesAsync();
            return _mapper.Map<ProductPrice, ProductPriceDTO>(productPrice);
        }

        public async Task<int> Delete(int id)
        {
            ProductPrice deletedProductPrice = await _db.ProductPrices.FirstOrDefaultAsync(c => c.Id == id);
            if (deletedProductPrice != null)
            {
                _db.ProductPrices.Remove(deletedProductPrice);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<ProductPriceDTO> Get(int id)
        {
            ProductPrice productPrice = await _db.ProductPrices.FirstOrDefaultAsync(c => c.Id == id);
            if (productPrice != null)
            {
                return _mapper.Map<ProductPrice, ProductPriceDTO>(productPrice);
            }
            return new ProductPriceDTO();
        }

        public async Task<IEnumerable<ProductPriceDTO>> GetAll(int? id = null)
        {
            if (id != null && id > 0)
            {
                return _mapper.Map<IEnumerable<ProductPrice>, IEnumerable<ProductPriceDTO>>(_db.ProductPrices.Where(u => u.ProductId == id));
            }
            else
            {
                return _mapper.Map<IEnumerable<ProductPrice>, IEnumerable<ProductPriceDTO>>(_db.ProductPrices);
            }

        }

        public async Task<ProductPriceDTO> Update(ProductPriceDTO objDTO)
        {
            ProductPrice updatedProductPrice = await _db.ProductPrices.FirstOrDefaultAsync(c => c.Id == objDTO.Id);
            if (updatedProductPrice != null)
            {
                updatedProductPrice.Price = objDTO.Price;
                updatedProductPrice.Size = objDTO.Size;
                updatedProductPrice.ProductId = objDTO.ProductId;
                _db.ProductPrices.Update(updatedProductPrice);
                await _db.SaveChangesAsync();
                return _mapper.Map<ProductPrice, ProductPriceDTO>(updatedProductPrice);
            }
            return objDTO;
        }
    }
}