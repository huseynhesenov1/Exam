using Project.Core.Entities;
using Project.DAL.Contexts;
using Project.DAL.Repositories.Abstractions;

namespace Project.DAL.Repositories.Implementations
{
    public class ProfessionRepository : GenericRepository<Profession>, IProfessionRepository
    {
        public ProfessionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
