using ConsommiTounsi.Models.Products;
using ConsommiTounsi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ConsommiTounsi.Repositories.Product
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> Get()
        {
            var client = HttpClientBuilder.Get();
            var response = client.GetAsync("categories").Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"Error from the server: {response.StatusCode}");
            }

            return response.Content.ReadAsAsync<List<Category>>().Result;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            var client = HttpClientBuilder.Get();
            var response = await client.GetAsync("categories");
            
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"Error from the server: {response.StatusCode}");
            }

            return await response.Content.ReadAsAsync<List<Category>>();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Category Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}