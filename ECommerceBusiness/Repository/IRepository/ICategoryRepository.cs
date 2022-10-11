using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommercyModels.DTOs;

namespace ECommerceBusiness.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public CategoryDTO Create(CategoryDTO objDTO);
        public CategoryDTO Update(CategoryDTO objDTO);
        public int Delete(int id);
        public CategoryDTO Get(int id);
        public IEnumerable<CategoryDTO> GetAll();
    }
}