using Project.Core.Entities;

namespace Project.DAL.Repositories.Abstractions
{
    public  interface IGenericRepository<Tentity> where Tentity : BaseEntity, new()
    {
        Task<ICollection<Tentity>> GetAllAsync(params string[] includes);
        Task<Tentity> GetByIdAsync(int id);
        Task<Tentity> GetByIdForUpdateAsync(int id);
        Task<Tentity> CreateAsync(Tentity tentity);
        Tentity Update(Tentity tentity);
        Tentity SoftDelete(Tentity tentity);
    }
}
