using ConsommiTounsi.Models.Payment;
using ConsommiTounsi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
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

        public async Task<ResponseModel<IEnumerable<Item>>> GetItems()
        {
            var client = HttpClientBuilder.Get();
            var response = await client.GetAsync("items");

            var model = await response.Content.ReadAsAsync<ResponseModel<IEnumerable<Item>>>();


            return model;
        }

        public async Task<ResponseModel<Cart>> RemoveItem(int itemId)
        {
            var client = HttpClientBuilder.Get();
            var response = await client.DeleteAsync($"items/{itemId}");

            var model = await response.Content.ReadAsAsync<ResponseModel<Cart>>();

            return model;
        }

        public async Task<ResponseModel<Cart>> UpdateItemQuantity(
            int itemId, int quantity)
        {

            var client = HttpClientBuilder.Get();
            var response = await client.PutAsync($"items/{itemId}/{quantity}", null);

            var model = await response.Content.ReadAsAsync<ResponseModel<Cart>>();

            return model;
        }
    }
}