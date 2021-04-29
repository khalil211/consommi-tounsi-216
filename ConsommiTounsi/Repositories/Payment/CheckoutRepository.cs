using ConsommiTounsi.Models.Payment;
using ConsommiTounsi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ConsommiTounsi.Repositories.Payment
{
    public class CheckoutRepository : ICheckoutRepository
    {
        public async Task<bool> CreateAtDeliveryPayment(PaymentModel paymentModel)
        {
            var client = HttpClientBuilder.Get();
            var response = await client.PostAsJsonAsync<PaymentModel>("atDeliveryCheckout", paymentModel);

            return response.IsSuccessStatusCode;
        }
    }
}