using System.ComponentModel.DataAnnotations;

namespace Project.BL.DTOs
{
    public class TeacherUpdateDto
    {
        //[MaxLength(50 , ErrorMessage = " UserName 50 simvoldan cox ola bilmaz")]
        [Required]
        public string FullName { get; set; }
        // [MinLength(0 , ErrorMessage = " ProfessionId 1 den az ola bilmaz")]
        [Required]
        public int ProfessionId { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
