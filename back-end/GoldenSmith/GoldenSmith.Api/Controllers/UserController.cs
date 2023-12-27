using GoldenSmith.Api.Upload;
using GoldenSmith.Application.Dto;
using GoldenSmith.Application.Services;
using GoldenSmith.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoldenSmith.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService; 
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto userDto)
        {
            //lấy user trong database
            var user = _userService.GetAll().Find(x => x.UserEmail == userDto.UserEmail
                                                    && x.UserPassword == userDto.UserPassword);
            //nếu tồn tại user thì tạo token
            if (user != null)
            {
                //mã hóa khóa bí mật
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
                //ký vào khóa bí mật đã mã hóa
                var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                //tạo claims chứa thông tin bổ sung
                var claims = new List<Claim>
                {
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.UserPermission.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName),
                };
                //tạo token với các thông số khớp với cấu hình trong file startup để validate
                var token = new JwtSecurityToken
                (
                    issuer: _configuration["Jwt:Issuser"],
                    audience: _configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredential,
                    claims: claims
                );
                TokenDto tokenUser = new TokenDto
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    user = user,
                };

                //sinh ra chuỗi token với các thông số ở trên
                return Ok(tokenUser);
            }
            return Unauthorized();
        }
        [HttpGet]
        public IActionResult GetJewelryImages()
        {
            List<UserDto> allUsers = _userService.GetAll();
            List<UserDto> customers = new List<UserDto>();
            for (int i = 0; i < allUsers.Count; i++)
            {
                if (allUsers[i].UserPermission == 0)
                {
                    customers.Add(allUsers[i]);
                }    
            }
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult SignUp(UserDto userDto)
        {
            List<UserDto> users = _userService.GetAll();
            bool emailExists = users.Any(u => u.UserEmail == userDto.UserEmail);

            if (emailExists)
            {
                // Trả về thông báo lỗi nếu email đã tồn tại
                return BadRequest("Email đã tồn tại");
            }
            else
            if (_userService.Add(userDto))
            {

                return Ok("Đăng ký thành công");
            }
            return Ok("Jewelry đã tồn tại");
        }

    }
}
