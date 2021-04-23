using ConsommiTounsi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ConsommiTounsi.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        public Models.Products.Product Get(int id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Models.Products.Product> GetA()
        {
            var client = HttpClientBuilder.Get();
            var response = client.GetAsync("products/").Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"Error from the server: {response.StatusCode}");
            }

            return response.Content.ReadAsAsync<List<Models.Products.Product>>().Result;
        }
        public async Task<IEnumerable<Models.Products.Product>> Get()
        {
            var client = HttpClientBuilder.Get();
            var response = await client.GetAsync("products/");

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"Error from the server: {response.StatusCode}");
            }

            return await response.Content.ReadAsAsync<List<Models.Products.Product>>();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Models.Products.Product Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}