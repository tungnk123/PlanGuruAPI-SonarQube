using Application.Users.Command.SetNameAndAvatar;
using Application.Users.Command.SignUp;
using Application.Users.Querry.Login;
using AutoMapper;
using Domain.Entities;
using PlanGuruAPI.DTOs.GroupDTOs;
using PlanGuruAPI.DTOs.UserDTOs;

namespace PlanGuruAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginRequest, LoginQuerry>().ReverseMap();
            CreateMap<SignUpRequest, SignUpCommand>().ReverseMap();
            CreateMap<SetNameAndAvatarRequest, SetNameAndAvatarCommand>().ReverseMap();
            CreateMap<CreateGroupRequest, Group>().ReverseMap();
            CreateMap<JoinGroupRequest, GroupUser>().ReverseMap();
            CreateMap<CreatePostInGroupRequest, Post>().ReverseMap();
            CreateMap<Post, PostReadDTO>().ReverseMap();
            CreateMap<PostInGroupDTO, Post>().ReverseMap()
                .ForMember(dest => dest.NumberOfComment, opt => opt.MapFrom(p => p.PostComments.Count))
                .ForMember(dest => dest.NumberOfUpvote, opt => opt.MapFrom(p => p.PostUpvotes.Count))
                .ForMember(dest => dest.NumberOfDevote, opt => opt.MapFrom(p => p.PostDevotes.Count))
                .ForMember(dest => dest.NumberOfShare, opt => opt.MapFrom(p => p.PostShares.Count))
                .ForMember(dest => dest.UserNickName, opt => opt.MapFrom(p => p.User.Name))
                .ForMember(dest => dest.UserAvatar, opt => opt.MapFrom(p => p.User.Avatar));
        }
    }
}
