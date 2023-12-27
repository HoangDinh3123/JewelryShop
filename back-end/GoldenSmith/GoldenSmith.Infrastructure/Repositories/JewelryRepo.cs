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
    public class JewelryRepo:Repo<Jewelry>,IJewelryRepo
    {
        public JewelryRepo(JewelryDbContext dbContext) : base(dbContext) {
            _dbSet = dbContext.Set<Jewelry>();
        }

        public List<Jewelry> GetJewelriesByCategory(int categoryId)
        {
            return _dbSet.Where(o => o.CategoryId == categoryId).ToList();
        }

    }
}
