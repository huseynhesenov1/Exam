using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.BL.Services.Implementations;
using Project.Core.Entities;

namespace Project.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class ProfessionController : Controller
    {
        private readonly IProfessionService _proSer;
        private readonly IMapper _mapper;


        public ProfessionController(IProfessionService proSer, IMapper mapper)
        {
            _proSer = proSer;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<Profession> professions = await _proSer.GetAllAsync();
            return View(professions);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProfessionDto professionDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "bos input qoymaq olmaz");
                return View(professionDto);
            }
            await _proSer.CreateAsync(professionDto);

            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                Profession profession = await _proSer.GetByIdAsync(id);
                return View(profession);

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
                await _proSer.SoftDeleteAsync(id);
                return RedirectToAction("Index");

            }
            catch
            {
                return RedirectToAction("Error");

            }
        }
        public async Task<IActionResult> Update(int id)
        {
            Profession profession = await _proSer.GetByIdForUpdateAsync(id);
            if (profession == null)
            {
                return RedirectToAction("Error");

            }
            ProfessionDto professionDto = _mapper.Map<ProfessionDto>(profession);
            return View(professionDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, ProfessionDto professionDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "bos input qoymaq olmaz");
                return View(professionDto);
            }
            try
            {

                await _proSer.UpdateAsync(id, professionDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

    }
}
