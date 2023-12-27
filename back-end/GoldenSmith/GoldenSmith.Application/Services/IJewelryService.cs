using GoldenSmith.Application.Dto;
using GoldenSmith.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Services
{
    public interface IJewelryService
    {
        List<JewelryDto> GetAll();
        JewelryDto Get(int id);
        List<JewelryDto> GetByCategoryId(int id);
        bool Add(JewelryDto jewelry);
        bool Update(JewelryDto jewelry);
        bool Delete(int id);
    }
}
