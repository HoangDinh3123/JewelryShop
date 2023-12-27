using AutoMapper;
using GoldenSmith.Application.Dto;
using GoldenSmith.Domain.Entities;
using GoldenSmith.Domain.Repositories;
using GoldenSmith.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Services
{
    public class OrderDetailService:IOrderDetailService
    {
        private readonly IOrderDetailRepo _orderDetailRepo;
        private readonly IMapper _mapper;

        public OrderDetailService(IOrderDetailRepo orderDetailRepo, IMapper mapper)
        {
            _orderDetailRepo = orderDetailRepo;
            _mapper = mapper;
        }

        public List<OrderDetailDto> GetAll()
        {
            return _mapper.Map<List<OrderDetailDto>>(_orderDetailRepo.GetAll());
        }

        public OrderDetailDto Get(int id)
        {
            return _mapper.Map<OrderDetailDto>(_orderDetailRepo.Get(id));
        }
        public List<OrderDetailDto> GetByOrderId(int id)
        {
            var orderDetails = _orderDetailRepo.GetOrdersDetailByOrderId(id);
            return _mapper.Map<List<OrderDetailDto>>(orderDetails);
        }
        public bool Add(OrderDetailDto orderDetail)
        {
            return _orderDetailRepo.Add(_mapper.Map<OrderDetail>(orderDetail));
        }
        public bool Update(OrderDetailDto orderDetail)
        {
            return _orderDetailRepo.Update(_mapper.Map<OrderDetail>(orderDetail));
        }
        public bool Delete(int id)
        {
            return _orderDetailRepo.Delete(id);
        }
    }
}
