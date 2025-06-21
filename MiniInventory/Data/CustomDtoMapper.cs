using AutoMapper;

namespace MiniInventory.Data
{
    public class CustomDtoMapper: Profile
    {
       public CustomDtoMapper()
        {
            CreateMap<Models.Entities.Product, Models.ViewModels.ProductModel>().ReverseMap();
        }
    }
}
