using Khareedo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Khareedo.Controllers
{
    public class HomeController : Controller
    {
        SukhkartaEntities db = new SukhkartaEntities();
       

        // GET: Home
        
        public ActionResult Index()
        {
          
            ViewBag.MenProduct = db.Products.Where(x => x.Category.Name.Equals("Agarbatti")).ToList();
            ViewBag.WomenProduct = db.Products.Where(x => x.Category.Name.Equals("Dhoop Sticks")).ToList();
            ViewBag.SportsProduct = db.Products.Where(x => x.Category.Name.Equals("Cone Dhoop")).ToList();
            ViewBag.ElectronicsProduct = db.Products.Where(x => x.Category.Name.Equals("Roll-On")).ToList();
            ViewBag.Slider = db.genMainSliders.ToList();
            ViewBag.PromoRight = db.genPromoRights.ToList();

            this.GetDefaultData();

            return View();
        }      

    }
}