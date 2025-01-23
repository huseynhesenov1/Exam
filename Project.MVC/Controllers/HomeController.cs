using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using Project.BL.Services.Abstractions;
using Project.Core.Entities;
using Project.DAL.Contexts;

namespace Project.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeacherService _teachServ;
        private readonly AppDbContext _context;

        public HomeController(ITeacherService teachServ, AppDbContext context)
        {
            _teachServ = teachServ;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
          ICollection<Teacher> teachers =   await _teachServ.GetAllAsync();
            return View(teachers);
        }

        /*public void CreateProfession()
        {
            Profession profession = new Profession();
            profession.Name = "back end developer";
            profession.CreateAt = DateTime.Now;
            profession.IsDeleted = false;
            _context.Professions.Add(profession);
            _context.SaveChanges();
        }

        public void CreateTeacher()
        {
            Teacher teacher = new Teacher();
            teacher.FullName = "Narmin Khan";
            teacher.ProfessionId = 1;
            teacher.ImagePath = "Hoca.png";
            teacher.CreateAt = DateTime.Now;
            teacher.IsDeleted = false;
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }*/
    }

}
