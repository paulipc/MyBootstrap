using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBootstrap.Database;
using MyBootstrap.Models;

namespace MyBootstrap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        public ActionResult bootstrap()
        {
            var context = new alytaloEntities();

            var query = from talo in context.Talo
                           where talo.TaloId == 1
                           select talo;

            var setalo = query.FirstOrDefault();

            ViewBag.talo = setalo.TaloId;

            //Console.WriteLine("taloid: " + setalo.TaloId);

            return View();
        }

    }
}