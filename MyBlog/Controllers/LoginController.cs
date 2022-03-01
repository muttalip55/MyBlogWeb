﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyBlog.Models.Classes;
namespace MyBlog.Controllers
{
    public class LoginController : Controller
    {
        Context context = new Context();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var values = context.Admins.FirstOrDefault(x => x.User == admin.User && x.Password == admin.Password);
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(values.User, false);
                Session["User"] = values.User.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}