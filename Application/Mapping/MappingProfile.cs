using AutoMapper; 
using Domain.Entities; 
using Application.DTOs;
using SmartCity.Application.DTOs;
namespace Application.Mapping
{ 
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            // Users
            CreateMap<CreateUserDto, User>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
            CreateMap<User, UserDto>().ReverseMap();

            // Others
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Message, MessageDto>().ReverseMap();
            CreateMap<Advertisement, AdvertisementDto>().ReverseMap();
            CreateMap<PublicService, PublicServiceDto>().ReverseMap();
            CreateMap<PublicServiceCategory, PublicServiceCategoryDto>().ReverseMap();
        }

    }
}
