using ConsommiTounsi.Models.Payment;
using ConsommiTounsi.Models.ViewModels;
using ConsommiTounsi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsi.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult OnlinePayment()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateIntent(Purchase purchase)
        {
            var client = HttpClientBuilder.Get();
            var response = await client.PostAsJsonAsync<Purchase>(
                $"payments/online/create-intent", purchase);

            var model = await response.Content.ReadAsAsync<CreatePaymentResponse>();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> ConfirmCardPayment(ConfirmPaymentModel confirmPaymentModel)
        {
            var client = HttpClientBuilder.Get();
            var response = await client.PostAsJsonAsync<ConfirmPaymentModel>(
                $"payments/online/confirmCardPayment", confirmPaymentModel);

            var model = await response.Content.ReadAsAsync<CreatePaymentResponse>();

            return RedirectToAction("Index", "Home");
        }
    }
}