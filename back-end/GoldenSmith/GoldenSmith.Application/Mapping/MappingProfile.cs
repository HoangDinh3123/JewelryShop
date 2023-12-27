using AutoMapper;
using GoldenSmith.Application.Dto;
using GoldenSmith.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Jewelry, JewelryDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<JewelryImage, JewelryImageDto>().ReverseMap();
            CreateMap<JewelryReview, JewelryReviewDto>().ReverseMap();
        }
    }
}
