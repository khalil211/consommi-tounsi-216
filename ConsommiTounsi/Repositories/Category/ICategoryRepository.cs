using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommiTounsi.Data.Repositories.Category
{
    public interface ICategoryRepository
    {
        IEnumerable<Models.Products.Category> getAll();
    }
}
