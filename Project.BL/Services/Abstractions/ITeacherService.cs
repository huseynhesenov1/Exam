using Project.BL.DTOs;
using Project.Core.Entities;

namespace Project.BL.Services.Abstractions
{
    public interface ITeacherService
    {
        Task<ICollection<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(int id);
        Task<Teacher> GetByIdForUpdateAsync(int id);
        Task<Teacher> CreateAsync(TeacherDto teacherDto);
        Task<Teacher> UpdateAsync(int id, TeacherUpdateDto teacherUpdateDto);
        Task<Teacher> SoftDeleteAsync(int id);
    }
}
