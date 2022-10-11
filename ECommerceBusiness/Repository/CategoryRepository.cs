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
        public CategoryDTO Create(CategoryDTO objDTO)
        {
            // Category category = new Category()
            // {
            //     Id = objDTO.Id,
            //     Name = objDTO.Name,
            //     CreatedDate = DateTime.Now
            // };
            //instead of above mapping below we use AutoMapper
            Category category = _mapper.Map<CategoryDTO, Category>(objDTO);

            _db.Categories.Add(category);
            _db.SaveChanges();

            // return new CategoryDTO()
            // {
            //     Id = category.Id,
            //     Name = category.Name
            // };
            //instead of above mapping below we use AutoMapper
            return _mapper.Map<Category, CategoryDTO>(category);
        }

        public int Delete(int id)
        {
            Category deletedCategory = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (deletedCategory != null)
            {
                _db.Categories.Remove(deletedCategory);
                return _db.SaveChanges();
            }
            return 0;
        }

        public CategoryDTO Get(int id)
        {
            Category category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                return _mapper.Map<Category, CategoryDTO>(category);
            }
            return new CategoryDTO();
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public CategoryDTO Update(CategoryDTO objDTO)
        {
            Category updatedCategory = _db.Categories.FirstOrDefault(c => c.Id == objDTO.Id);
            if (updatedCategory != null)
            {
                updatedCategory.Name = objDTO.Name;
                _db.Categories.Update(updatedCategory);
                _db.SaveChanges();
                return _mapper.Map<Category, CategoryDTO>(updatedCategory);
            }
            return objDTO;
        }
    }
}