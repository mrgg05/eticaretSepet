﻿using ECommerce.Models;
using ECommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShopContext db = new ShopContext();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var cartviewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            return View(cartviewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var eklenen = db.Products.FirstOrDefault(x => x.ProductId==id);
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(eklenen);

            return RedirectToAction("Index");

        }

        public ActionResult RemoveToCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            string itemname = db.Carts.FirstOrDefault(x => x.RecordId == id).Product.Title;
        

           int itemcount= cart.RemoveFromCart(id);

            

            var result = new ShoppingCartRemoveViewModel
            {
                Message=Server.HtmlEncode(itemname)+" sepetinizden basariyla kaldirildi",
                CartTotal = cart.GetTotal(),
                Count = cart.GetCount(),
                ItemCount = itemcount,
                DeleteId=id
            };

            return Json(result);

        }

        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }

    }
}