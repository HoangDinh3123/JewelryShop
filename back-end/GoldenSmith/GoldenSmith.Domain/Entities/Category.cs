using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Domain.Entities
{
    public class Category
    {
        public int CategoryId {  get; set; }
        public string? CategoryName { get; set; }
        public ICollection<Jewelry>? Jewelries{ get; set;}
    }
}
