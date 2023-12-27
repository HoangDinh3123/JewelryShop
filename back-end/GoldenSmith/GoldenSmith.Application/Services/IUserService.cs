using GoldenSmith.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Services
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto Get(int id);
        bool Add(UserDto user);
        bool Update(UserDto user);
        bool Delete(int id);
    }
}
