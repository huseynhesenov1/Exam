using AutoMapper;
using Project.BL.DTOs;
using Project.Core.Entities;

namespace Project.BL.Prolfiles
{
    public class TeacherUpdateProfile : Profile
    {
        public TeacherUpdateProfile()
        {
            CreateMap<Teacher, TeacherUpdateDto>();
            CreateMap<Teacher, TeacherUpdateDto>().ReverseMap();
        }
    }
}
