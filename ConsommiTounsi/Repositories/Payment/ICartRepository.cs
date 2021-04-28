using ConsommiTounsi.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommiTounsi.Repositories.Payment
{
    public interface ICartRepository
    {
        Task<ResponseModel<Cart>> GetAsync(int userId);
        ResponseModel<Cart> Get(int userId);
        Task<ResponseModel<Cart>> AddItem(int cartId, Item item, int productId);
        Task<ResponseModel<Cart>> RemoveItem(int itemId);
        Task<ResponseModel<Cart>> UpdateItemQuantity(int itemId, int quantity);
    }
}
