using ConsommiTounsi.Models.Payment;
using ConsommiTounsi.Models.User;
using ConsommiTounsi.Repositories.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsi.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddItem(int id, int productId, int quantity)
        {
            var item = new Item()
            {
                Quantity = quantity
            };
            var model = await cartRepository.AddItem(id, item, productId);
            if (!string.IsNullOrWhiteSpace(model.ErrorMessage))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, model.ErrorMessage);
            }
            return Json(model);
        }


        public async Task<ActionResult> Details()
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var response = await cartRepository.GetAsync((int)user.id);
            var cart = response.Body;
            if (cart == null || cart.Items.Count == 0)
            {
                return RedirectToAction("Index", "Product");
            }

            return View(cart);
        }


        [ChildActionOnly]
        public ActionResult RenderCart()
        {
            var user = Session["user"] as User;
            if (user != null)
            {
                var response = cartRepository.Get((int)user.id);
                Cart cart = response.Body;
                return PartialView("_Cart", cart);
            }
            return PartialView("_Cart", null);
        }

        //private Cart _getCart()
        //{
        //    var user = Session["user"] as User;
        //    if (user != null)
        //    {
        //        return cartRepository.Get((int)user.id).Body;
        //    }
        //    return null;
        //}
    }
}