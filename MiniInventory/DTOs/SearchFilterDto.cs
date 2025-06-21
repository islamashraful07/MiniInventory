using MiniInventory.Models.Entities;

namespace MiniInventory.DTOs
{
    public class SearchFilterDto
    {
        public string? Name { get; set; }
        public Category? Category { get; set; }
        
    }
}
