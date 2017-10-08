using BLL.Abstract;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductProvider _productProvider;
        public CategoryController(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }
        // GET: Category
        public ActionResult Index()
        {
            var model = _productProvider.GetCategories();
            return View(model);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(AddCategoryProdViewModel category)
        {
            int result=_productProvider.AddCategory(category);
            return RedirectToAction("Index");
        }
    }
}