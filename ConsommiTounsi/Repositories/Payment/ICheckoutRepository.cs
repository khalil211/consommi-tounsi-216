using ConsommiTounsi.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ConsommiTounsi.Repositories.Payment
{
    public interface ICheckoutRepository
    {
        Task<bool> CreateAtDeliveryPayment(PaymentModel paymentModel);
    }
}