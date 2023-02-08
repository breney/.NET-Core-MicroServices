using Mango.Service.OrderAPI.Models;

namespace Mango.Service.OrderAPI.Repository
{
    public interface IOrderRepository
    {

        Task<bool> AddOrder(OrderHeader orderHeader);

        Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid);

    }
}
