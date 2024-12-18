using Application.PlantPosts.Command.CreatePost;
using Application.PlantPosts.Common.GetPlantPosts;
using Application.Users.Querry.Login;
using AutoMapper;
using Domain.Entities;
using PlanGuruAPI.DTOs.PlantPostDTOs;

namespace PlanGuruAPI.Mapping
{
    public class PlantPostProfile : Profile
    {
        public PlantPostProfile()
        {
            CreateMap<CreatePlantPostRequest, CreatePlantPostCommand>().ReverseMap();
            CreateMap<CreatePlantPostRequest, CreatePlantPostCommand>().ReverseMap();
            CreateMap<Post, PlantPostDto>();

        }
    }
}
