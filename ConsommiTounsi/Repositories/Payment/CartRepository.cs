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
        public async Task<ResponseModel<Cart>> AddItem(int cartId, Item item, int productId)
        {
            var client = HttpClientBuilder.Get();
            var response = await client.PostAsJsonAsync<Item>(
                $"users/carts/{cartId}/items/{productId}", item);

            var model = await response.Content.ReadAsAsync<ResponseModel<Cart>>();

            if (!string.IsNullOrWhiteSpace(model.ErrorMessage))
            {
                throw new InvalidOperationException(model.ErrorMessage);
            }

            return model;
        }

        public ResponseModel<Cart> Get(int userId)
        {
            var client = HttpClientBuilder.Get();
            var response = client.GetAsync($"users/{userId}/cart").Result;

            return response.Content.ReadAsAsync<ResponseModel<Cart>>().Result;
        }

        public async Task<ResponseModel<Cart>> GetAsync(int userId)
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