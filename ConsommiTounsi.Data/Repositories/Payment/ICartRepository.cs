using ConsommiTounsi.Data.Models.Payment;

namespace ConsommiTounsi.Data.Repositories.Payment
{
    public interface ICartRepository
    {
        ResponseModel<Cart> GetCart(int userId);
        ResponseModel<Cart> AddItem(int userId, Item item);
    }
}
