using GoldenSmith.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Dto
{
    public class JewelryDto
    {
        public int JewelryId { get; set; }
        public string? JewelryName { get; set; }
        public string? JewelryDescription { get; set; }
        public float JewelryWeight {  get; set; }
        public float? JewelrySize { get; set; }
        public float? JewelryPrice { get; set; }
        public string? JewelryColor { get; set; }
        public int CategoryId { get; set; }

    }
}
