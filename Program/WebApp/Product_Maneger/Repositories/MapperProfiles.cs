using AutoMapper;
using Product_Maneger.Models;
using Product_Maneger.Models.DTO;

namespace Product_Maneger.Repositories
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles() 
        {
            CreateMap<Product, ProductDTO>(MemberList.Destination).ReverseMap();
            CreateMap<Category, CategoryDTO>(MemberList.Destination).ReverseMap();
        }
    }
}
