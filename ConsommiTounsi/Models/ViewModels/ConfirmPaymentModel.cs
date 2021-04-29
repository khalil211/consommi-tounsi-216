using ConsommiTounsi.Models.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.ViewModels
{
    /*
     * var body = {
                        userId: @user.id,
                        amount: result.paymentIntent.amount,
                        shippingAddress: {
                            recipientName: "mohamed",
                            street: "123 Main St.",
                            city: "Monastir",
                            governorate: "Monastir",
                            postCode: "5000"
                        }
                    };
     */
    public class ConfirmPaymentModel
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("shippingAddress")]
        public Address ShippingAddress { get; set; }
    }
}