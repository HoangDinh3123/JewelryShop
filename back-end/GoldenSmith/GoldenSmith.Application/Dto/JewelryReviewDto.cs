using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Dto
{
    public class JewelryReviewDto
    {
        public int JewelryReviewId { get; set; }
        public float JewelryReviewRating { get; set; }
        public string? JewelryReviewComment {  get; set; }
        public DateTime ReviewDate { get; set; }
        public int JewelryId {  get; set; }
        public int UserId { get; set; }
    }
}
