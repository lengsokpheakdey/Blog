using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Models
{
    public class MenuController : Controller
    {
        ApplicationDbContext myDbContext = new ApplicationDbContext();
        // GET: Menu
        [ChildActionOnly]
        public ActionResult Index()
        {
            var Categories = myDbContext.Categories.ToList();
            return View("~/Views/Shared/_Layout.cshtml", Categories);
        }

        protected override void Dispose(bool disposing)
        {
            myDbContext.Dispose();
        }
    }
}