using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BBsBaskets.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Range(0, 1000,ErrorMessage ="Price must be greater than or equal to 0 and less than 1000.")]
        public decimal Price { get; set; }
        
        [DisplayName("Date Created")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public string? ImageURL { get; set; }

        public string? TestColumn { get; set; }

    }
}
