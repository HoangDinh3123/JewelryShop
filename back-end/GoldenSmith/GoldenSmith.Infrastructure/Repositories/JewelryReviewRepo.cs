using GoldenSmith.Domain.Entities;
using GoldenSmith.Domain.Repositories;
using GoldenSmith.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Infrastructure.Repositories
{
    public class JewelryReviewRepo:Repo<JewelryReview>,IJewelryReviewRepo
    {
        public JewelryReviewRepo(JewelryDbContext dbContext) : base(dbContext) {
            _dbSet = dbContext.Set<JewelryReview>();
        }

        public List<JewelryReview> GetJewelryReviewByJewelryId(int jewelryId)
        {
            return _dbSet.Where(o => o.JewelryId == jewelryId).ToList();
        }
    }
}
