using AutoMapper;
using FootiniApp.API.Dtos;
using FootiniApp.API.Models;

namespace FootiniApp.API.helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForList>();
            CreateMap<userForUpdateDto, User>();
            CreateMap<Image, ImageForReturnDto>();
            CreateMap<ImageForCreationDto, Image>();
        }
    }
}