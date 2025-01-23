using AutoMapper;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.Core.Entities;
using Project.DAL.Contexts;
using Project.DAL.Repositories.Abstractions;

namespace Project.BL.Services.Implementations
{
    public class ProfessionService : IProfessionService
    {
        private readonly IProfessionRepository _proRepo;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProfessionService(IProfessionRepository proRepo, AppDbContext context, IMapper mapper)
        {
            _proRepo = proRepo;
            _context = context;
            _mapper = mapper;
        }

        public async Task<Profession> CreateAsync(ProfessionDto professiondto)
        {
            Profession profession = _mapper.Map<Profession>(professiondto);
            profession.CreateAt = DateTime.Now;
            
            var res = await _proRepo.CreateAsync(profession);
            await  _context.SaveChangesAsync();
            return res;
        }

        public async Task<ICollection<Profession>> GetAllAsync()
        {
            return await _proRepo.GetAllAsync();
        }

        public async Task<Profession> GetByIdAsync(int id)
        {
            return await _proRepo.GetByIdAsync(id);
        }

        public async Task<Profession> GetByIdForUpdateAsync(int id)
        {
            return await _proRepo.GetByIdForUpdateAsync(id);
        }

        public async Task<Profession> SoftDeleteAsync(int id)
        {
            Profession profession = await _proRepo.GetByIdAsync(id);
            if (profession == null)
            {
                throw new Exception();
            }
           var res = _proRepo.SoftDelete(profession);
            return res; 
        }

        public async Task<Profession> UpdateAsync(int id, ProfessionDto professiondto)
        {
            Profession profession = await _proRepo.GetByIdForUpdateAsync(id);
            if (profession == null)
            {
                throw new Exception();
            }
            Profession updateProfession = _mapper.Map<Profession>(professiondto);
            updateProfession.CreateAt = profession.CreateAt;
            updateProfession.Id = profession.Id;
            updateProfession.UpdateAt = DateTime.Now;
           var res = _proRepo.Update(updateProfession);
           await _context.SaveChangesAsync();
            return res;

        }
    }
}
