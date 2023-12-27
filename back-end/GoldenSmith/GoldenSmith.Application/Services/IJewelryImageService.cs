using GoldenSmith.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Services
{
    public interface IJewelryImageService
    {
        List<JewelryImageDto> GetAll();
        JewelryImageDto Get(int id);
        bool Add(JewelryImageDto jewelryImage, int id);
        bool Update(JewelryImageDto jewelryImage);
        bool Delete(int id);
        
    }
}
