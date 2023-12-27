using GoldenSmith.Application.Dto;
using GoldenSmith.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSmith.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JewelryImageController : ControllerBase
    {
        private readonly IJewelryImageService _jewelryImageService;
        public JewelryImageController(IJewelryImageService jewelryImageService)
        {
            _jewelryImageService = jewelryImageService;
        }
        [HttpGet]
        public IActionResult GetJewelryImages()
        {
            return Ok(_jewelryImageService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetJewelryImage(int id)
        {
            var image = _jewelryImageService.Get(id);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteImage(int id, string nameFile)
        {
            string directoryPath = "./wwwroot/Jewelry/" + id + "/" +nameFile;
            Directory.Delete(directoryPath, true);
            if (_jewelryImageService.Delete(id))
            {
                return Ok("Xóa thành công");
            }
            return NotFound("Không thể xóa vì jewelry không tồn tại");
        }
    }
}

