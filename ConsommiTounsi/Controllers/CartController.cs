using ConsommiTounsi.Models.Payment;
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
    }
}