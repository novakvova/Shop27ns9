using BLL.Abstract;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IProductProvider _productProvider;
        public CategoryController(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }
        [AllowAnonymous]
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
            int result = _productProvider.AddCategory(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _productProvider.EditCategory(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditCategoryProdViewModel editCategory)
        {
            if (ModelState.IsValid)
            {
                int result = _productProvider.EditCategory(editCategory);
                if (result == 0)
                    ModelState.AddModelError("", "Помилка збереження даних!");
                else if (result != 0)
                    return RedirectToAction("Index");
            }
            return View(editCategory);
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _productProvider.GetCategoryInfo(id);
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoryItemProdViewModel categoryDel)
        {
            _productProvider.Delete(categoryDel.Id);
            return RedirectToAction("Index");

        }
    }
}