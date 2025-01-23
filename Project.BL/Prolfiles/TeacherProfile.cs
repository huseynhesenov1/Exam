using AutoMapper;
using Project.BL.DTOs;
using Project.Core.Entities;

namespace Project.BL.Prolfiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<TeacherDto , Teacher>();
            CreateMap<TeacherDto , Teacher>().ReverseMap();
        }
    }
}
