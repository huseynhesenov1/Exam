using Project.BL.DTOs;
using Project.Core.Entities;

namespace Project.BL.Services.Abstractions
{
    public interface IProfessionService
    {
        Task<ICollection<Profession>> GetAllAsync();
        Task<Profession> GetByIdAsync(int id);
        Task<Profession> GetByIdForUpdateAsync(int id);
        Task<Profession> CreateAsync(ProfessionDto professiondto);
        Task<Profession> UpdateAsync(int id, ProfessionDto professiondto);
        Task<Profession> SoftDeleteAsync(int id);
    }
}
