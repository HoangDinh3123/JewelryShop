using AutoMapper;
using GoldenSmith.Application.Dto;
using GoldenSmith.Domain.Entities;
using GoldenSmith.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public List<UserDto> GetAll()
        {
            return _mapper.Map<List<UserDto>>(_userRepo.GetAll());
        }

        public UserDto Get(int id)
        {
            return _mapper.Map<UserDto>(_userRepo.Get(id));
        }
        public bool Add(UserDto user)
        {
            return _userRepo.Add(_mapper.Map<User>(user));
        }
        public bool Update(UserDto user)
        {
            return _userRepo.Update(_mapper.Map<User>(user));
        }
        public bool Delete(int id)
        {
            return _userRepo.Delete(id);
        }
    }
}
