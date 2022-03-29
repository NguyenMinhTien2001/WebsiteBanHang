using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models;
namespace WebsiteBanHang.Controllers
{
    public class HomeController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {
            //var books = data.Hangs.;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    searchString = searchString.ToLower();
            //    books = books.Where(b => b.Title.ToLower().Contains(searchString));
            //}

            //return View(books.ToList());
            //;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}