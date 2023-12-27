using GoldenSmith.Api.Upload;
using GoldenSmith.Application.Dto;
using GoldenSmith.Application.Services;
using GoldenSmith.Domain.Entities;
/*using GoldenSmith.Infrastructure.Migrations;*/
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoldenSmith.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JewelryController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IJewelryService _jewelryService;
        private readonly ICategoryService _categoryService;
        private readonly IJewelryImageService _jewelryImageService;
        public JewelryController(ICategoryService categoryService, IWebHostEnvironment environment, IJewelryService jewelryService, IJewelryImageService jewelryImageService)
        {
            _categoryService = categoryService;
            _environment = environment;
            _jewelryService = jewelryService;
            _jewelryImageService = jewelryImageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetJewelries()
        {
            List<JewelryDto> jewelries = _jewelryService.GetAll();
            List<AllDataJewelryDto> allDataJewelryDtos = new List<AllDataJewelryDto>();
            for (int i = 0; i < jewelries.Count; i++)
            {
                var category = _categoryService.Get(jewelries[i].CategoryId);
                List<String> imagesUrl = new List<String>();
                List<String> images = GetImagesByJewelry(jewelries[i].JewelryId);
                
                for(int j = 0; j < images.Count; j++)
                {
                    imagesUrl.Add(images[j]);
                }    

                AllDataJewelryDto allDataJewelry = new AllDataJewelryDto
                {
                    JewelryId = jewelries[i].JewelryId,
                    CategoryId = category.CategoryId,
                    JewelryName = jewelries[i].JewelryName,
                    JewelryDescription = jewelries[i].JewelryDescription,
                    JewelryColor = jewelries[i].JewelryColor,
                    JewelryPrice = jewelries[i].JewelryPrice,
                    JewelrySize = jewelries[i].JewelrySize,
                    JewelryWeight = jewelries[i].JewelryWeight,
                    CategoryName = category.CategoryName,
                    jewelryImages = imagesUrl,
                    
                };
                allDataJewelryDtos.Add(allDataJewelry);
            }    
            return Ok(allDataJewelryDtos);
        }

        [HttpGet("byCategory")]
        public async Task<IActionResult> GetJewelriesByCategory(int id)
        {
            List<JewelryDto> jewelries = _jewelryService.GetByCategoryId(id);
            List<AllDataJewelryDto> allDataJewelryDtos = new List<AllDataJewelryDto>();
            for (int i = 0; i < jewelries.Count; i++)
            {
                var category = _categoryService.Get(jewelries[i].CategoryId);
                List<String> imagesUrl = new List<String>();
                List<String> images = GetImagesByJewelry(jewelries[i].JewelryId);
                for (int j = 0; j < images.Count; j++)
                {
                    imagesUrl.Add(images[j]);
                }

                AllDataJewelryDto allDataJewelry = new AllDataJewelryDto
                {
                    JewelryId = jewelries[i].JewelryId,
                    CategoryId = category.CategoryId,
                    JewelryName = jewelries[i].JewelryName,
                    JewelryDescription = jewelries[i].JewelryDescription,
                    JewelryColor = jewelries[i].JewelryColor,
                    JewelryPrice = jewelries[i].JewelryPrice,
                    JewelrySize = jewelries[i].JewelrySize,
                    JewelryWeight = jewelries[i].JewelryWeight,
                    CategoryName = category.CategoryName,
                    jewelryImages = imagesUrl,

                };
                allDataJewelryDtos.Add(allDataJewelry);
            }
            return Ok(allDataJewelryDtos);
        }

        [HttpGet("latest")]
        public int GetLatestJewelry()
        {
            List<JewelryDto> jewelry = new List<JewelryDto>();
            jewelry = _jewelryService.GetAll();
            JewelryDto jewelryDto = new JewelryDto();
            jewelryDto = jewelry[jewelry.Count - 1];
            return jewelryDto.JewelryId;
        }
        [HttpGet("{id}")]
        public IActionResult GetJewelry(int id)
        {
            var jewelry = _jewelryService.Get(id);
            var category = _categoryService.Get(jewelry.CategoryId);
            List<String> imagesUrl = new List<String>();
            List<String> images = GetImagesByJewelry(jewelry.JewelryId);
            for (int j = 0; j < images.Count; j++)
            {
                imagesUrl.Add(images[j]);
            }
            AllDataJewelryDto allDataJewelry = new AllDataJewelryDto
            {
                JewelryId = jewelry.JewelryId,
                CategoryId = category.CategoryId,
                JewelryName = jewelry.JewelryName,
                JewelryDescription = jewelry.JewelryDescription,
                JewelryColor = jewelry.JewelryColor,
                JewelryPrice = jewelry.JewelryPrice,
                JewelrySize = jewelry.JewelrySize,
                JewelryWeight = jewelry.JewelryWeight,
                CategoryName = category.CategoryName,
                jewelryImages = imagesUrl,
            };
            if (jewelry == null)
            {
                return NotFound();
            }
            return Ok(allDataJewelry);
        }


        [HttpPost]
        public IActionResult AddJewelry([FromForm] JewelryDto jewelry, [FromForm] List<IFormFile> jewelryImages)
        {

            if (_jewelryService.Add(jewelry))
            {
                int newId = GetLatestJewelry();
                List<String> images = new List<String>();
                images = UploadFile.UploadImage(newId, "Jewelry", jewelryImages);
                JewelryImageDto jewelryImageDto = new JewelryImageDto();
                foreach (var image in images)
                {
                    jewelryImageDto.JewelryImagePath = image;
                    _jewelryImageService.Add(jewelryImageDto, newId);
                }
                return CreatedAtAction("AddJewelry", new { id = newId });
            }
            return Ok("Jewelry đã tồn tại");
        }

        [HttpGet("GetImage")]
        public async Task<IActionResult> GetImage(int jewelryId)
        {
            string ImageUrl = string.Empty;
            string HostUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            try
            {
                JewelryImageDto jewelryImageDto = _jewelryImageService.Get(jewelryId);
                string? ImagePath = jewelryImageDto?.JewelryImagePath;
                ImageUrl = HostUrl + "/Jewelry/" + jewelryId + "/" + ImagePath;
            }
            catch (Exception e)
            {
            }
            return Ok(ImageUrl);

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
                foreach(FileInfo fileInfo in fileInfos)
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


        [HttpPut("{id}")]
        public IActionResult UpdateJewelry([FromForm] JewelryDto jewelry, [FromForm] List<IFormFile> jewelryImages)
        {
            if (_jewelryService.Update(jewelry))
            {
                int Id = jewelry.JewelryId;
                List<String> images = new List<String>();
                images = UploadFile.UploadImage(Id, "Jewelry", jewelryImages);
                JewelryImageDto jewelryImageDto = new JewelryImageDto();
                foreach (var image in images)
                {
                    jewelryImageDto.JewelryImagePath = image;
                    _jewelryImageService.Add(jewelryImageDto, Id);
                }
                return Ok("Update thành công");
            }
            return Ok("Lỗi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteJewelry(int id)
        {
            string directoryPath = "./wwwroot/Jewelry/" + id;
            Directory.Delete(directoryPath, true);
            if (_jewelryService.Delete(id))
            {
                return Ok("Xóa thành công");
            }
            return NotFound("Không thể xóa vì jewelry không tồn tại");
        }


        [NonAction]
        private string GetFilepath(int productcode)
        {
            return this._environment.WebRootPath + "\\Jewelry\\" + productcode;
        }

    }
}
