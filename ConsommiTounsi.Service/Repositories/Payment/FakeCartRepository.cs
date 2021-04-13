using ConsommiTounsi.Service.Models.Payment;
using ConsommiTounsi.Service.Models.Payment.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommiTounsi.Service.Repositories.Payment
{
    public class FakeCartRepository : ICartRepository
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
