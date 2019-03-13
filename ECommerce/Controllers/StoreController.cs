using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class StoreController : Controller
    {
        ShopContext db = new ShopContext();
        // GET: Store
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();

            return View(categories);
        }

        public ActionResult Details(int id)
        {
            var product = db.Products.Where(x=>x.CategoryId==id).ToList();

            return View(product);
        }
    }
}