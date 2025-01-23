using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.Core.Entities;
using System.Diagnostics.Contracts;

namespace Project.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ITeacherService _teachServ;
        private readonly IMapper _mapper;

        public HomeController(ITeacherService teachServ, IMapper mapper)
        {
            _teachServ = teachServ;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<Teacher> teachers = await _teachServ.GetAllAsync();
            return View(teachers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeacherDto teacherDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "bos input qoymaq olmaz");
                return View(teacherDto);
            }
            await _teachServ.CreateAsync(teacherDto);

            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            Teacher teacher = await _teachServ.GetByIdForUpdateAsync(id);
            if (teacher == null)
            {
                return RedirectToAction("Error");

            }
            TeacherUpdateDto teacherUpdateDto = _mapper.Map<TeacherUpdateDto>(teacher);
            return View(teacherUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, TeacherUpdateDto teacherUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "bos input qoymaq olmaz");
                return View(teacherUpdateDto);
            }
            try
            {

                await _teachServ.UpdateAsync(id, teacherUpdateDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                Teacher teacher = await _teachServ.GetByIdAsync(id);
                return View(teacher);

            }
            catch
            {
                return RedirectToAction("Error");

            }
        }
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _teachServ.SoftDeleteAsync(id);
                return RedirectToAction("Index");

            }
            catch
            {
                return RedirectToAction("Error");

            }
        }


        



    }
}
