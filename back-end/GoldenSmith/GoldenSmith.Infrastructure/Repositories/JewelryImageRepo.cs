using GoldenSmith.Domain.Entities;
using GoldenSmith.Domain.Repositories;
using GoldenSmith.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Infrastructure.Repositories
{
    public class JewelryImageRepo:Repo<JewelryImage>,IJewelryImageRepo
    {
        public JewelryImageRepo(JewelryDbContext context) : base(context) { }

    }
}
