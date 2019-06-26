using AutoMapper;

namespace NearbyShop.API.ViewModels
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Shop, ShopViewModel>()
                .ReverseMap();
            CreateMap<User, RegisterViewModel>()
                .ReverseMap();
        }
    }
}
