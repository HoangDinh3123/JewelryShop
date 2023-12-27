using GoldenSmith.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Services
{
    public interface IJewelryReviewService
    {
        List<JewelryReviewDto> GetAll();
        JewelryReviewDto Get(int id);
        List<JewelryReviewDto> GetByJewelryId(int id);
        bool Add(JewelryReviewDto jewelryReview);
        bool Update(JewelryReviewDto jewelryReview);
        bool Delete(int id);
    }
}
