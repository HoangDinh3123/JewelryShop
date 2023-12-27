using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Dto
{
    public class JewelryImageDto
    {
        public int JewelryImageId { get; set; }
        public string? JewelryImagePath { get; set; }
        public int JewelryId { get; set; }
    }
}
