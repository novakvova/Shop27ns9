﻿using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IProductProvider
    {
        int AddCategory(AddCategoryProdViewModel addCategory);
        IEnumerable<CategoryItemProdViewModel> GetCategories();
        void Delete(int id);
        EditCategoryProdViewModel EditCategory(int id);
        int EditCategory(EditCategoryProdViewModel editCategory);
        CategoryItemProdViewModel GetCategoryInfo(int id);


    }
}
