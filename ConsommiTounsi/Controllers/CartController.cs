using ConsommiTounsi.Models.Payment;
using ConsommiTounsi.Models.User;
using ConsommiTounsi.Models.ViewModels;
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
        private readonly ICheckoutRepository checkoutRepository;

        public CartController(ICartRepository cartRepository, ICheckoutRepository checkoutRepository)
        {
            this.cartRepository = cartRepository;
            this.checkoutRepository = checkoutRepository;
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

        public async Task<ActionResult> GetItems()
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var response = await cartRepository.GetAsync((int)user.id);
            var items = response.Body.Items;

            return Json(items, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public async Task<ActionResult> RemoveItem(int id)
        {
            var model = await cartRepository.RemoveItem(id);
            if (!string.IsNullOrWhiteSpace(model.ErrorMessage))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, model.ErrorMessage);
            }
            return Json(model);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateItem(int id, int quantity)
        {
            var model = await cartRepository.UpdateItemQuantity(itemId: id, quantity);
            if (!string.IsNullOrWhiteSpace(model.ErrorMessage))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, model.ErrorMessage);
            }
            return Json(model);
        }

        public async Task<ActionResult> Checkout()
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

            var model = new CheckoutViewModel()
            {
                Cart = cart,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Checkout(CheckoutViewModel model)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (model.Payment.PaymentType == PaymentType.ONLINE)
            {
                return RedirectToAction("OnlinePayment", "Payment");
            }

            var paymentModel = new PaymentModel
            {
                ShippingAddress = model.Payment.Address,
                PaymentType = model.Payment.PaymentType,
                UserId = (int)user.id
            };
            var response = await checkoutRepository.CreateAtDeliveryPayment(paymentModel);

            if (!response)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            return RedirectToAction("Index", "Home");
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