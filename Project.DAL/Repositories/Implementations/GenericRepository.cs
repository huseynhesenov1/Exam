using Microsoft.EntityFrameworkCore;
using Project.Core.Entities;
using Project.DAL.Contexts;
using Project.DAL.Repositories.Abstractions;

namespace Project.DAL.Repositories.Implementations
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<Tentity> Table => _context.Set<Tentity>();

        public async Task<Tentity> CreateAsync(Tentity tentity)
        {
            await Table.AddAsync(tentity);
            return tentity;
        }

        public async Task<ICollection<Tentity>> GetAllAsync(params string[] includes)
        {
            var query = Table.AsQueryable();

            if (includes.Length != 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<Tentity> GetByIdAsync(int id)
        {
            return await Table.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tentity> GetByIdForUpdateAsync(int id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Tentity SoftDelete(Tentity tentity)
        {
            if (tentity == null)
            {
                throw new Exception();
            }
            tentity.IsDeleted = true;
            return tentity;
        }

        public Tentity Update(Tentity tentity)
        {
            Table.Update(tentity);
            return tentity;
        }
    }
}
