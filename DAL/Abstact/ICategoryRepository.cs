using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstact
{
    public interface ICategoryRepository : IDisposable
    {
        Category Add(Category category);
        IQueryable<Category> GetAllCategories(bool published=true);
        void Delete(int id);
        Category GetCategoryById(int id);
        void SaveChanges();

    }
}
