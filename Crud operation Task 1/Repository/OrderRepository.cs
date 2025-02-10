using Crud_operation_Task_1.Database;
using Crud_operation_Task_1.Entity;
using Crud_operation_Task_1.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Crud_operation_Task_1.Repository
{
    public class OrderRepository:IOrderRepository
    {

        private readonly appDbContext _context;

        public OrderRepository(appDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Order.Include(o => o.Customer).Include(o => o.Product).ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Order.Include(o => o.Customer).Include(o => o.Product).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddOrder(Order order)
        {
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            _context.Order.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(int id)
        {
            var order = await GetOrderById(id);
            if (order != null)
            {
                _context.Order.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

    }
}
