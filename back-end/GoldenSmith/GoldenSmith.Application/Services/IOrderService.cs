using GoldenSmith.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Services
{
    public interface IOrderService
    {
        List<OrderDto> GetAll();
        OrderDto Get(int id);
        List<OrderDto> GetByUserId(int id);
        bool Add(OrderDto order);
        bool Update(OrderDto order);
        bool Delete(int id);
    }
}
