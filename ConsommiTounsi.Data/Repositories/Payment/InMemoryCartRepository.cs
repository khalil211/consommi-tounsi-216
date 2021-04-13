using ConsommiTounsi.Data.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommiTounsi.Data.Repositories.Payment
{
    public class InMemoryCartRepository : ICartRepository
    {
        public ResponseModel<Cart> AddItem(int userId, Item item)
        {
            throw new NotImplementedException();
        }

        public ResponseModel<Cart> GetCart(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
