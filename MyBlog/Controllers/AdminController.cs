using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models.Classes;
namespace MyBlog.Controllers
{
    public class AdminController : Controller
    {
        Context context = new Context();
        // GET: Admin

        [Authorize]
        public ActionResult Index()
        {
            var values = context.Blogs.ToList();
            return View(values);
        }

        /// ///////////////////////////////////////

        [HttpGet]
        public ActionResult NewBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewBlog(Blog blog)
        {
            context.Blogs.Add(blog);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBlog(int id)
        {
            var blog = context.Blogs.Find(id);
            context.Blogs.Remove(blog);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGet(int id)
        {
            var blog = context.Blogs.Find(id);
            return View("BlogGet", blog);
        }


        public ActionResult BlogUpdate(Blog updateBlog)
        {
            var newBlog = context.Blogs.Find(updateBlog.Id);
            newBlog.Explanation = updateBlog.Explanation;
            newBlog.Baslik = updateBlog.Baslik;
            newBlog.BlogImage = updateBlog.BlogImage;
            newBlog.Tarih = updateBlog.Tarih;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        /// /////////////////////////

        public ActionResult CommentList()
        {
            var comments = context.Comments.ToList();
            return View(comments);
        }

        public ActionResult DeleteComment(int id)
        {
            var blog = context.Comments.Find(id);
            context.Comments.Remove(blog);
            context.SaveChanges();
            return RedirectToAction("CommentList");
        }

        public ActionResult CommetGet(int id)
        {
            var commet = context.Comments.Find(id);
            return View("CommetGet", commet);
        }

        public ActionResult CommetUpdate(Comment updateComment)
        {
            var newComment = context.Comments.Find(updateComment.Id);
            newComment.UserName = updateComment.UserName;
            newComment.Mail = updateComment.Mail;
            newComment.Comments = updateComment.Comments;
            context.SaveChanges();
            return RedirectToAction("CommentList");
        }
    }
}