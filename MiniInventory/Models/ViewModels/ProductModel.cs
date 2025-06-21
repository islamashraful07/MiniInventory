using MiniInventory.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MiniInventory.Models.ViewModels
{
    public class ProductModel
    {
        public int Id { get; set; }
        public required string Name { get; set; } 
        public decimal Price { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
        public Category Category { get; set; }
        public int Quantity { get; set; }
    }
}
