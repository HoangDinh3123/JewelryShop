using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Domain.Entities
{
    public class Jewelry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JewelryId { get; set; }
        public string? JewelryName { get; set; }
        public string? JewelryDescription { get; set;}
        public float JewelryWeight { get; set; }
        public float? JewelrySize {  get; set; }
        public float? JewelryPrice { get; set; }
        public string? JewelryColor {  get; set; }
        public int CategoryId {  get; set; }
        public Category? Category { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
        public ICollection<JewelryImage>? JewelryImages { get; set; }
        public ICollection<JewelryReview>? JewelryReviews { get; set; }

    }
}
