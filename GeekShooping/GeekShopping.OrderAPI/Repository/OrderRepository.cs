using GeekShopping.OrderAPI.Model;
using GeekShopping.OrderAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GeekShopping.CartAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MySQLContext _context;

        public OrderRepository(MySQLContext context)
        {
            _context = context;
        }

        public async Task<bool> AddOrder(OrderHeader header)
        {
            try
            {
                if (header == null) return false;
                //await using var _db = new MySQLContext(_context);
                _context.Headers.Add(header);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task UpdateOrderPaymentStatus(long orderHeaderId, bool status)
        {
            //await using var _db = new MySQLContext(_context);
            var header = await _context.Headers.FirstOrDefaultAsync(o => o.Id == orderHeaderId);
            if (header != null)
            {
                header.PaymentStatus = status;
                await _context.SaveChangesAsync();
            };
        }
    }
}
