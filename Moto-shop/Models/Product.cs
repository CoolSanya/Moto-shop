using System.ComponentModel.DataAnnotations;

namespace Moto_shop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Range(1, int.MaxValue)]
        public int Price { get; set; }
        public string Image { get; set; }
    }   
}
