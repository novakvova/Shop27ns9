using BLL.Abstract;
using Newtonsoft.Json;
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
        [HttpPost]
        public ContentResult DeleteUserRole(int userId, int roleId)
        {
            string json = "";
            int rez = _userProvider.DeleteUserRole(userId, roleId); 
            
            json = JsonConvert.SerializeObject(new
            {
                rez = rez
            });
            return Content(json, "application/json");
        }
    }
}