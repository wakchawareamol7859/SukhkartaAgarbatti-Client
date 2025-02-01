using Khareedo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace Khareedo.Controllers
{
    public class HomeController : Controller
    {
        SukhkartaEntities db = new SukhkartaEntities();


        // GET: Home

        public ActionResult Index()
        {

            var visitor = db.MyVisitorCounts.FirstOrDefault();
            if (Session["HasVisited"] != "true")
            {
                if (visitor == null)
                {
                    visitor = new MyVisitorCount { Count = 1 };
                    db.MyVisitorCounts.Add(visitor);
                }
                else
                {
                    visitor.Count++;
                    db.Entry(visitor).State = EntityState.Modified;
                }
                db.SaveChanges();
                Session["HasVisited"] = "true";
            }
            ViewBag.MenProduct = db.Products.Where(x => x.Category.Name.Equals("Agarbatti")).ToList();
            ViewBag.WomenProduct = db.Products.Where(x => x.Category.Name.Equals("Dhoop Sticks")).ToList();
            ViewBag.SportsProduct = db.Products.Where(x => x.Category.Name.Equals("Cone Dhoop")).ToList();
            ViewBag.ElectronicsProduct = db.Products.Where(x => x.Category.Name.Equals("Roll-On")).ToList();
            ViewBag.Slider = db.genMainSliders.ToList();
            ViewBag.PromoRight = db.genPromoRights.ToList();
            ViewBag.VisitorCount = visitor.Count;
            this.GetDefaultData();

            return View();
        }

    }
}