using AutoMapper;
using Project.BL.DTOs;
using Project.Core.Entities;

namespace Project.BL.Prolfiles
{
    public class AppUserProfile:Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser , AppUserDto>();
            CreateMap<AppUser , AppUserDto>().ReverseMap();
        }
    }
}
