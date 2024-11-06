using Application.Users.Querry;
using AutoMapper;
using PlanGuruAPI.DTOs;

namespace PlanGuruAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginRequest, LoginQuerry>().ReverseMap();
        }
    }
}
