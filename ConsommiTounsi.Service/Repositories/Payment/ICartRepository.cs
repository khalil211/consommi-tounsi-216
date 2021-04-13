using ConsommiTounsi.Service.Models.Payment;
using ConsommiTounsi.Service.Models.Payment.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommiTounsi.Service.Repositories.Payment
{
    public interface ICartRepository
    {
        ResponseModel<Cart> GetCart(int userId);
        ResponseModel<Cart> AddItem(int userId, Item item);
        //ResponseModel<Cart> GetCart(int userId);
    }
}
