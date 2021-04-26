using ConsommiTounsi.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommiTounsi.Repositories.Product
{
    public interface ICategoryRepository
    {
        Category Get(int id);
        Task<IEnumerable<Category>> Get();
        Category Update(int id);
        void Remove(int id);
    }
}
