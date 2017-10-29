using BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class AdminUserController : Controller
    {
        private readonly IUserProvider _userProvider;
        public AdminUserController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }
        // GET: AdminUser
        public ActionResult Index()
        {
            var model = _userProvider.GetAllUsers();
            //var list = model.ToList();
            return View(model);
        }
    }
}