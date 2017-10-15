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
                Name = addCategory.Name,
                Published = addCategory.Published
            };
            _categoryRepository.Add(category);
            _categoryRepository.SaveChanges();
            return category.Id;
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }

        public EditCategoryProdViewModel EditCategory(int id)
        {
            EditCategoryProdViewModel model = null;

            var category = _categoryRepository.GetCategoryById(id);
            if (category != null)
            {
                model = new EditCategoryProdViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Published = category.Published
                };
            }
            return model;
        }

        public int EditCategory(EditCategoryProdViewModel editCategory)
        {
            try
            {
                var category =
                    _categoryRepository.GetCategoryById(editCategory.Id);
                if (category != null)
                {
                    category.Name = editCategory.Name;
                    category.Published = editCategory.Published;
                    _categoryRepository.SaveChanges();
                }
            }
            catch
            {
                return 0;
            }
            return editCategory.Id;
        }

        public IEnumerable<CategoryItemProdViewModel> GetCategories()
        {
            var model = _categoryRepository.GetAllCategories()
                .Select(c => new CategoryItemProdViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Published = c.Published
                });
            return model.AsEnumerable();
        }

        public CategoryItemProdViewModel GetCategoryInfo(int id)
        {
            CategoryItemProdViewModel model = null;
            var category = _categoryRepository.GetCategoryById(id);
            if(category!=null)
            {
                model = new CategoryItemProdViewModel
                {
                    Id=category.Id,
                    Name=category.Name,
                    Published=category.Published
                };
            }
            return model;
        }
    }
}
