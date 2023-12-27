using GoldenSmith.Application.Dto;
using GoldenSmith.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSmith.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpPost]
        public IActionResult AddOrderDetail(OrderDetailDto orderDetailDto)
        {

            if (_orderDetailService.Add(orderDetailDto))
            {

                return Ok("Them thanh cong");
            }
            return Ok("Jewelry đã tồn tại");
        }
    }
}
