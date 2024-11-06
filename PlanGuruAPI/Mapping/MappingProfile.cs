using Application.Users.Command.SetNameAndAvatar;
using Application.Users.Command.SignUp;
using Application.Users.Querry.Login;
using AutoMapper;
using PlanGuruAPI.DTOs;

namespace PlanGuruAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginRequest, LoginQuerry>().ReverseMap();
            CreateMap<SignUpRequest, SignUpCommand>().ReverseMap();
            CreateMap<SetNameAndAvatarRequest, SetNameAndAvatarCommand>().ReverseMap();
        }
    }
}
