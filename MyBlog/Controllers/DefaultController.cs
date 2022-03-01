using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models.Classes;
namespace MyBlog.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.Blogs.Take(3).ToList();
            return View(values);
        }

        public ActionResult About()
        {
            return View();
        }

        public PartialViewResult Partial1()
        {
            var values = context.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTop10()
        {
            var values = context.Blogs.Take(10).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialOtherBlog()
        {
            var values = context.Blogs.Take(3).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialOther2Blog()
        {
            var values = context.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            return PartialView(values);
        }
    }
}