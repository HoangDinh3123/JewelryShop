using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Domain.Entities
{
    public class JewelryImage
    {
        public int JewelryImageId { get; set;}
        public string? JewelryImagePath {  get; set;}

        public int JewelryId { get; set; }
        public Jewelry? Jewelry{ get; set;}
    }
}
