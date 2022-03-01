using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models.Classes;
namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        Context context = new Context();
        BlogComment blogComment = new BlogComment();
        // GET: Blog
        public ActionResult Index()
        {
            blogComment.Value1 = context.Blogs.ToList();
            blogComment.Value2 = context.Comments.Take(3).ToList();
            blogComment.Value3 = context.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            return View(blogComment);
        }

       
        public ActionResult BlogDetail(int id)
        {
            blogComment.Value1 = context.Blogs.Where(x => x.Id == id).ToList();
            blogComment.Value2 = context.Comments.Where(x => x.Blogid == id).ToList();
            blogComment.Value3 = context.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            return View(blogComment);
        }


        [HttpGet]
        public PartialViewResult Comment(int id)
        {
            ViewBag.value = id;
            return PartialView();
        }


        [HttpPost]
        public PartialViewResult Comment(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
            return PartialView();
        }
    }
}