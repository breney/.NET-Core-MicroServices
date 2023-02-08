using Mango.Service.OrderAPI.DbContexts;
using Mango.Service.OrderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Service.OrderAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContext;

        private readonly ApplicationDbContext _db;

        public OrderRepository(DbContextOptions<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
        }
    
        public async Task<bool> AddOrder(OrderHeader orderHeader)
        {
            await using var _db = new ApplicationDbContext(_dbContext);
    
            _db.OrderHeaders.Add(orderHeader);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
            
            return true;
        }
    
        public async Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid)
        {
            await using var _db = new ApplicationDbContext(_dbContext);
            
            var orderHeaderFromDb = _db.OrderHeaders.FirstOrDefault(x => x.OrderHeaderId == orderHeaderId);

            if(orderHeaderFromDb != null)
            {
                orderHeaderFromDb.PaymentStatus = paid;
                await _db.SaveChangesAsync();

            }
        }
    }
}
