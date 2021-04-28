using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommiTounsi.Repositories.Product
{
    public interface IProductRepository
    {
        Task<Models.Products.Product> Get(int id);
        Task<IEnumerable<Models.Products.Product>> Get();
        Models.Products.Product Update(int id);
        void Remove(int id);
    }
}
