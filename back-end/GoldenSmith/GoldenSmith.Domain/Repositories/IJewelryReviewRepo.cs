using GoldenSmith.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Domain.Repositories
{
    public interface IJewelryReviewRepo:IRepo<JewelryReview>
    {
        List<JewelryReview> GetJewelryReviewByJewelryId(int orderId);
    }
}
