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
    public class OrderRepo:Repo<Order>,IOrderRepo
    {
        public OrderRepo(JewelryDbContext dbContext) : base(dbContext) {
            _dbSet = dbContext.Set<Order>();
        }
        public List<Order> GetOrdersByUserId(int userId)
        {
            return _dbSet.Where(o => o.UserId == userId).ToList();
        }
    }
}
