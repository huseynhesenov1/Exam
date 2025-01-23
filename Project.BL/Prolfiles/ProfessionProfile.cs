using AutoMapper;
using Project.BL.DTOs;
using Project.Core.Entities;

namespace Project.BL.Prolfiles
{
    public class ProfessionProfile:Profile
    {
        public ProfessionProfile()
        {
            CreateMap<ProfessionDto, Profession>();
            CreateMap<ProfessionDto, Profession>().ReverseMap();
        }
    }
}
