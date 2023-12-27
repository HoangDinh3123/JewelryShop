using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public float OrderTotal { get; set; }
        public int OrderStatus {  get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
