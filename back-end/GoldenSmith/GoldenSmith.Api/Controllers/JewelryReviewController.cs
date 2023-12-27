using GoldenSmith.Application.Dto;
using GoldenSmith.Application.Services;
using GoldenSmith.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSmith.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JewelryReviewController : ControllerBase
    {
        private readonly IJewelryReviewService _jewelryReviewService;
        private readonly IJewelryService _jewelryService;
        private readonly IUserService _userService;
        public JewelryReviewController(IJewelryReviewService jewelryReviewService, IJewelryService jewelryService, IUserService userService)
        {
            _jewelryReviewService = jewelryReviewService;
            _jewelryService = jewelryService;
            _userService = userService;
        }


        [HttpPost]
        public IActionResult AddJewelryReview(JewelryReviewDto jewelryReview)
        {
            if (_jewelryReviewService.Add(jewelryReview))
            {
                return Ok("Thêm thành công");
            }
            return Ok("Category đã tồn tại");
        }

        [HttpGet]
        public IActionResult GetReviews(int id)
        {
            List<JewelryReviewDto> jewelryReviewDtos = _jewelryReviewService.GetByJewelryId(id);
            List<AllDataJewelryReview> allDataJewelryReviews = new List<AllDataJewelryReview>();

            for (int i = 0; i < jewelryReviewDtos.Count; i++)
            {
                UserDto user = _userService.Get(jewelryReviewDtos[i].UserId);


                AllDataJewelryReview data = new AllDataJewelryReview
                {
                    JewelryReviewId = jewelryReviewDtos[i].JewelryReviewId,
                    JewelryReviewRating = jewelryReviewDtos[i].JewelryReviewRating,
                    JewelryReviewComment = jewelryReviewDtos[i].JewelryReviewComment,
                    ReviewDate = jewelryReviewDtos[i].ReviewDate,
                    UserId = user.UserId,
                    JewelryId = jewelryReviewDtos[i].JewelryId,
                    UserName = user.UserName,
                };
                allDataJewelryReviews.Add(data);
            }
            return Ok(allDataJewelryReviews);
        }
    }
}
