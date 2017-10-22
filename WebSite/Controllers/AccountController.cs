using BLL.Abstract;
using BLL.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountProvider _accountProvider;
        public AccountController(IAccountProvider accountProvider)
        {
            _accountProvider = accountProvider;
        }

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var status = _accountProvider.Login(model);
                if (status == StatusAccountViewModel.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Не коректні дані!");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var status = _accountProvider.Register(model);
                if (status == StatusAccountViewModel.Success)
                {
                    return RedirectToAction("Login");
                }
                else if (status == StatusAccountViewModel.Dublication)
                    ModelState.AddModelError("", "Даний адрес електронної пошти уже існує!");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            _accountProvider.Logout();
            return RedirectToAction("Index", "Home");
        }

        #region AJAX
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ContentResult LoginPopup(LoginViewModel model)
        {
            string json = ""; int rez = 0; string message = "";
            message = "Подумай ще!";
            if (ModelState.IsValid)
            {
                var status = _accountProvider.Login(model);
                if (status == StatusAccountViewModel.Success)
                {
                    rez = 1;
                }
                else
                {
                    message = "Не тупи!";
                    rez = 2;
                }
            }
            json = JsonConvert.SerializeObject(new {
                rez=rez,
                message=message
            });
            return Content(json, "application/json");
        }
        #endregion
    }
}