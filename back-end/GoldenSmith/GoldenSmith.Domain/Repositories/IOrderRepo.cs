using GoldenSmith.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Domain.Repositories
{
    public interface IOrderRepo:IRepo<Order>
    {
        List<Order> GetOrdersByUserId(int userId);
    }
}
