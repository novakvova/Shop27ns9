using DAL.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IEFContext _context;
        public CategoryRepository(IEFContext context)
        {
            _context = context;
        }
        public Category Add(Category category)
        {
            _context.Set<Category>().Add(category);
            return category;
        }

        public void Dispose()
        {
            if(this._context!=null)
                this._context.Dispose();
        }

        public IQueryable<Category> GetAllCategories(bool published = true)
        {
            return this._context.Set<Category>();
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
