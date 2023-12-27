using GoldenSmith.Domain.Entities;
using GoldenSmith.Domain.Repositories;
using GoldenSmith.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Infrastructure.Repositories
{
    public class OrderDetailRepo:Repo<OrderDetail>,IOrderDetailRepo
    {
        public OrderDetailRepo(JewelryDbContext dbContext) : base(dbContext) {
            _dbSet = dbContext.Set<OrderDetail>();
        }

        public List<OrderDetail> GetOrdersDetailByOrderId(int orderId)
        {
            return _dbSet.Where(o => o.OrderId == orderId).ToList();
        }
    }
}
