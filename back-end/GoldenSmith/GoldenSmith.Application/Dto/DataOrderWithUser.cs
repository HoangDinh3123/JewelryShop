using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Dto
{
    public class DataOrderWithUser
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public float OrderTotal { get; set; }
        public int OrderStatus { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }

        public List<OrderDetailWithJewelry>? Details { get; set; }
    }
}
