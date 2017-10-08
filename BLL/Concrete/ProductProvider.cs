using BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModels;
using DAL.Abstact;
using DAL.Entities;

namespace BLL.Concrete
{
    public class ProductProvider : IProductProvider
    {
        ICategoryRepository _categoryRepository;
        public ProductProvider(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public int AddCategory(AddCategoryProdViewModel addCategory)
        {
            Category category = new Category
            {
                Name=addCategory.Name,
                Published=addCategory.Published
            };
            _categoryRepository.Add(category);
            _categoryRepository.SaveChanges();
            return category.Id;
        }
    }
}
