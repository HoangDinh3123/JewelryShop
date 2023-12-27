using GoldenSmith.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Services
{
    public interface IOrderDetailService
    {
        List<OrderDetailDto> GetAll();
        OrderDetailDto Get(int id);
        List<OrderDetailDto> GetByOrderId(int id);
        bool Add(OrderDetailDto orderDetail);
        bool Update(OrderDetailDto orderDetail);
        bool Delete(int id);
    }
}
