using AutoMapper;
using TimeApp_Server.Models;
using TimeApp_Server.ViewModels;

namespace TimeApp_Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<Posts,PostsView>().ReverseMap();
            CreateMap<Posts, ReadPostsView>().ReverseMap();

        }
    }
}
