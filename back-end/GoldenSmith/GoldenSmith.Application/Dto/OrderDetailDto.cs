using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Dto
{
    public class OrderDetailDto
    {
        public int OrderDetailId {  get; set; }
        public int Quantity { get; set; }
        public float OrderDetailPrice {  get; set; }

        public int OrderId { get; set; }
        public int JewelryId { get; set; }
    }
}
