using System.ComponentModel.DataAnnotations;

namespace asp.netcoreTelerikGrid.Models
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal? price { get; set; }

        public string? Description { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? Created_at { get; set; }
    }
}
