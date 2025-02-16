using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProductContext _dbcontext;
        public OrderRepository()
        {
            _dbcontext = new ProductContext();
        }
        public void AddOrder(Order order)
        {
            _dbcontext.Orders.Add(order);
            _dbcontext.SaveChanges();
        }

        public Order GetOrder(int Id)
        {
            return _dbcontext.Orders.Include(x => x.Products).FirstOrDefault(o => o.OrderId == Id);
        }
    }
}
