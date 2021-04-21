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
    public class CartRepository : ICartRepository
    {
        public Task<ResponseModel<Cart>> AddItem(int userId, Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<Cart>> Get(int userId)
        {
            var client = HttpClientBuilder.Get();
            var response = await client.GetAsync($"users/{userId}/cart");

            return await response.Content.ReadAsAsync<ResponseModel<Cart>>();
        }

        public Task<ResponseModel<Cart>> RemoveItem(int userId, int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Cart>> UpdateItemQuantity(int userId, int itemId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}