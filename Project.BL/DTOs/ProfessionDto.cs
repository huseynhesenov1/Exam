using System.ComponentModel.DataAnnotations;

namespace Project.BL.DTOs
{
    public class ProfessionDto
    {
        [MaxLength(5 , ErrorMessage = " Name 5 simvoldan cox ola bilmaz")]
        [Display(Prompt = "Name")]

        public string Name { get; set; }

    }
}
