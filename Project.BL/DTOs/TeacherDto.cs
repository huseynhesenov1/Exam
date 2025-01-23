using Microsoft.AspNetCore.Http;
using Project.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project.BL.DTOs
{
    public class TeacherDto
    {
        [Required]
        [Display(Prompt = "FullName")]
        //[MaxLength(20, ErrorMessage = "FullName 20 simvoldan artiq ola bilmez ")]
        public string FullName { get; set; }
        [Required]
        [Display(Prompt = "ProfessionId")]
        //[MinLength(0, ErrorMessage = "ProfessionId 0 simvodlan az ola bilmez ")]
        public int ProfessionId { get; set; }
        [Required]
        [Display(Prompt = "ImagePath")]
        public IFormFile ImagePath { get; set; }
    }
}
