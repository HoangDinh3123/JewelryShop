using GoldenSmith.Api.Upload;
using GoldenSmith.Application.Dto;
using GoldenSmith.Application.Services;
using GoldenSmith.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSmith.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IJewelryService _jewelryService;
        public OrderController(IWebHostEnvironment environment, IUserService userService, IOrderService orderService, IOrderDetailService orderDetailService, IJewelryService jewelryService)
        {
            _environment = environment;
            _userService = userService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _jewelryService = jewelryService;
        }

        [HttpPost]
        public IActionResult AddOrder(OrderDto orderDto)
        {

            if (_orderService.Add(orderDto))
            {

                return Ok("Them thanh cong");
            }
            return Ok("Jewelry đã tồn tại");
        }

        [HttpGet("latest")]
        public IActionResult GetLatestOrder()
        {
            List<OrderDto> order = new List<OrderDto>();
            order = _orderService.GetAll();
            OrderDto orderDto= new OrderDto();
            orderDto = order[order.Count - 1];
            return Ok(orderDto.OrderId);
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            List<OrderDto> orderDtos = _orderService.GetAll();
            List<DataOrderWithUser> dataOrderWithUsers = new List<DataOrderWithUser>();
            
            for (int i = 0; i < orderDtos.Count; i++)
            {
                List<OrderDetailWithJewelry> orderDetailWithJewelries = new List<OrderDetailWithJewelry>();
                UserDto user = _userService.Get(orderDtos[i].UserId);
                List<OrderDetailDto> orderDetailDtos = _orderDetailService.GetByOrderId(orderDtos[i].OrderId);

                for (int j = 0; j < orderDetailDtos.Count; j++)
                {
                    JewelryDto jewelry = _jewelryService.Get(orderDetailDtos[j].JewelryId);
                    List<String> jewelryImage = GetImagesByJewelry(jewelry.JewelryId);
                    OrderDetailWithJewelry orderDetail = new OrderDetailWithJewelry
                    {
                        OrderDetailId = orderDetailDtos[j].OrderDetailId,
                        Quantity = orderDetailDtos[j].Quantity,
                        OrderDetailPrice = orderDetailDtos[j].OrderDetailPrice,
                        OrderId = orderDetailDtos[j].OrderId,
                        JewelryId = orderDetailDtos[j].JewelryId,
                        JewelryName = jewelry.JewelryName,
                        JewelryImagePath = jewelryImage.First(),
                    };
                    orderDetailWithJewelries.Add(orderDetail);
                }

                DataOrderWithUser data = new DataOrderWithUser
                {
                    OrderId = orderDtos[i].OrderId,
                    OrderDate = orderDtos[i].OrderDate,
                    OrderStatus = orderDtos[i].OrderStatus,
                    OrderTotal = orderDtos[i].OrderTotal,
                    UserId  = user.UserId,
                    UserName = user.UserName,
                    UserEmail = user.UserEmail,
                    Address = orderDtos[i].Address,
                    Phone = orderDtos[i].Phone,
                    Details = orderDetailWithJewelries,
                };
                dataOrderWithUsers.Add(data);
            }
            return Ok(dataOrderWithUsers);
        }
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var image = _orderService.Get(id);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

        [HttpGet("getOrder")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var orders = _orderService.GetByUserId(id);
            List<DataOrderWithUser> dataOrderWithUsers = new List<DataOrderWithUser>();

            for (int i = 0; i < orders.Count; i++)
            {
                List<OrderDetailWithJewelry> orderDetailWithJewelries = new List<OrderDetailWithJewelry>();
                UserDto user = _userService.Get(orders[i].UserId);
                List<OrderDetailDto> orderDetailDtos = _orderDetailService.GetByOrderId(orders[i].OrderId);

                for (int j = 0; j < orderDetailDtos.Count; j++)
                {
                    JewelryDto jewelry = _jewelryService.Get(orderDetailDtos[j].JewelryId);
                    List<String> jewelryImage = GetImagesByJewelry(jewelry.JewelryId);
                    OrderDetailWithJewelry orderDetail = new OrderDetailWithJewelry
                    {
                        OrderDetailId = orderDetailDtos[j].OrderDetailId,
                        Quantity = orderDetailDtos[j].Quantity,
                        OrderDetailPrice = orderDetailDtos[j].OrderDetailPrice,
                        OrderId = orderDetailDtos[j].OrderId,
                        JewelryId = orderDetailDtos[j].JewelryId,
                        JewelryName = jewelry.JewelryName,
                        JewelryImagePath = jewelryImage.First(),
                    };
                    orderDetailWithJewelries.Add(orderDetail);
                }

                DataOrderWithUser data = new DataOrderWithUser
                {
                    OrderId = orders[i].OrderId,
                    OrderDate = orders[i].OrderDate,
                    OrderStatus = orders[i].OrderStatus,
                    OrderTotal = orders[i].OrderTotal,
                    UserId = user.UserId,
                    UserName = user.UserName,
                    UserEmail = user.UserEmail,
                    Address = orders[i].Address,
                    Phone = orders[i].Phone,
                    Details = orderDetailWithJewelries,
                };
                dataOrderWithUsers.Add(data);
            }
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(dataOrderWithUsers);
        }

        [HttpPut]
        public IActionResult UpdateOrder(DataOrderWithUser order)
        {
            OrderDto orderDto = _orderService.Get(order.OrderId);
            orderDto.OrderStatus = order.OrderStatus;
            if (_orderService.Update(orderDto))
            {
                return Ok("Cập nhật thành công");
            }
            return NotFound();
        }
        [NonAction]
        private List<String> GetImagesByJewelry(int jewelryId)
        {
            List<string> ImageUrl = new List<string>();
            string HostUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string filePath = GetFilepath(jewelryId);
                DirectoryInfo directoryInfo = new DirectoryInfo(filePath);
                FileInfo[] fileInfos = directoryInfo.GetFiles();
                foreach (FileInfo fileInfo in fileInfos)
                {
                    string _ImageUrl = HostUrl + "/Jewelry/" + jewelryId + "/" + fileInfo.Name;
                    ImageUrl.Add(_ImageUrl);
                }
            }
            catch (Exception e)
            {
            }
            return ImageUrl;
        }

        [NonAction]
        private string GetFilepath(int productcode)
        {
            return this._environment.WebRootPath + "\\Jewelry\\" + productcode;
        }
    }
}
