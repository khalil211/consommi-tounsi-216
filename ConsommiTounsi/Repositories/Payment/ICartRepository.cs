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
        Task<ResponseModel<Cart>> AddItem(int userId, Item item, int productId);
        Task<ResponseModel<Cart>> RemoveItem(int userId, int itemId);
        Task<ResponseModel<Cart>> UpdateItemQuantity(int userId, int itemId, int quantity);
    }
}
