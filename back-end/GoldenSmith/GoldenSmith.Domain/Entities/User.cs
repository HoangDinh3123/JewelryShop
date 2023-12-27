using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail {  get; set; }
        public string? UserPassword { get; set;}
        public string? UserPhone { get; set;}
        public int UserPermission {  get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<JewelryReview>? JewelryReviews { get; set; }
    }
}
