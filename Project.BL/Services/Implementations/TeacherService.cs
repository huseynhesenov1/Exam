using AutoMapper;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.Core.Entities;
using Project.DAL.Contexts;
using Project.DAL.Repositories.Abstractions;
using System.ComponentModel.Design;

namespace Project.BL.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teachRepo;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teachRepo, AppDbContext context, IMapper mapper)
        {
            _teachRepo = teachRepo;
            _context = context;
            _mapper = mapper;
        }
        public async Task<ICollection<Teacher>> GetAllAsync()
        {
            return await _teachRepo.GetAllAsync("Profession");
        }

        public async Task<Teacher> CreateAsync(TeacherDto teacherDto)
        {
            var folder = Path.Combine("wwwroot", "ImageUpload");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folder);
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }
            var filename = teacherDto.ImagePath.FileName;
            var fullPath = Path.Combine(pathToSave, filename);
            if (!File.Exists(fullPath))
            {
                filename = Path.GetFileNameWithoutExtension(filename) + Guid.NewGuid().ToString() + Path.GetExtension(filename);
                fullPath = Path.Combine(pathToSave, filename);
            }

            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                /* await fullPath.CopyToAsync(fileStream);*/
            }

            Teacher teacher = _mapper.Map<Teacher>(teacherDto);
            teacher.ImagePath = filename;
            teacher.CreateAt = DateTime.Now;
            var res = await _teachRepo.CreateAsync(teacher);
            await _context.SaveChangesAsync();
            return res;
        }


        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _teachRepo.GetByIdAsync(id);
        }

        public async Task<Teacher> GetByIdForUpdateAsync(int id)
        {
            return await _teachRepo.GetByIdForUpdateAsync(id);
        }

        public async Task<Teacher> SoftDeleteAsync(int id)
        {
            Teacher teacher = await _teachRepo.GetByIdAsync(id);
            var res = _teachRepo.SoftDelete(teacher);
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<Teacher> UpdateAsync(int id, TeacherUpdateDto teacherUpdateDto)
        {
            Teacher teacher = await _teachRepo.GetByIdForUpdateAsync(id);
            if (teacher == null)
            {
                throw new Exception();
            }
            Teacher updateTeacher = _mapper.Map<Teacher>(teacherUpdateDto);

            updateTeacher.Id = teacher.Id;
            updateTeacher.ImagePath = teacher.ImagePath;
            updateTeacher.CreateAt = teacher.CreateAt;
            updateTeacher.UpdateAt = DateTime.Now;

            var res = _teachRepo.Update(updateTeacher);
            await _context.SaveChangesAsync();
            return res;
        }
    }
}
