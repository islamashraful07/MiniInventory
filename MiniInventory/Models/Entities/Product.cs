using System.ComponentModel.DataAnnotations;

namespace MiniInventory.Models.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public decimal Price { get; set; }
        [Required]
        public Category Category { get; set; } 
        public int Quantity { get; set; }
        
    }
}
