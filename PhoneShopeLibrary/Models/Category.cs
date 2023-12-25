using System.ComponentModel.DataAnnotations;

namespace PhoneShopeLibrary.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

       public List<Product>? Products { get; set; }
    }
}
