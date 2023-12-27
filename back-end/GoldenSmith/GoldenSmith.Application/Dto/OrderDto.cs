using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Dto
{
    public class OrderDto
    {
        public int OrderId {  get; set; }
        public DateTime OrderDate { get; set; }
        public float OrderTotal {  get; set; }
        public int OrderStatus {  get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }

    }
}
