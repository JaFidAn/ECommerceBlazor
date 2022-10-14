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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CategoryDTO> Create(CategoryDTO objDTO)
        {
            // Category category = new Category()
            // {
            //     Id = objDTO.Id,
            //     Name = objDTO.Name,
            //     CreatedDate = DateTime.Now
            // };
            //instead of above mapping below we use AutoMapper
            Category category = _mapper.Map<CategoryDTO, Category>(objDTO);
            category.CreatedDate = DateTime.Now;

            var addedCategory = _db.Categories.Add(category);
            await _db.SaveChangesAsync();

            // return new CategoryDTO()
            // {
            //     Id = category.Id,
            //     Name = category.Name
            // };
            //instead of above mapping below we use AutoMapper
            return _mapper.Map<Category, CategoryDTO>(category);
        }

        public async Task<int> Delete(int id)
        {
            Category deletedCategory = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (deletedCategory != null)
            {
                _db.Categories.Remove(deletedCategory);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<CategoryDTO> Get(int id)
        {
            Category category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                return _mapper.Map<Category, CategoryDTO>(category);
            }
            return new CategoryDTO();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public async Task<CategoryDTO> Update(CategoryDTO objDTO)
        {
            Category updatedCategory = await _db.Categories.FirstOrDefaultAsync(c => c.Id == objDTO.Id);
            if (updatedCategory != null)
            {
                updatedCategory.Name = objDTO.Name;
                _db.Categories.Update(updatedCategory);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDTO>(updatedCategory);
            }
            return objDTO;
        }
    }
}