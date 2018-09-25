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
        }
    }
}