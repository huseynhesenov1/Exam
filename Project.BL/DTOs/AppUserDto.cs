using System.ComponentModel.DataAnnotations;

namespace Project.BL.DTOs
{
    public class AppUserDto
    {
        [Required]
        [Display(Prompt = "FirstName")]
        [MaxLength(10, ErrorMessage = " FirstName 50 simvoldan cox ola bilmaz")]

        public string FirstName { get; set; }
        [Required]
        [Display(Prompt = "LastName")]
        [MaxLength(10 , ErrorMessage = " LastName 50 simvoldan cox ola bilmaz")]

        public string LastName { get; set; }
        [Required]
        [Display(Prompt = "UserName")]
        [MaxLength(10 , ErrorMessage = " UserName 50 simvoldan cox ola bilmaz")]
        public string UserName { get; set; }
        [Required]
        [Display(Prompt = "Email")]

        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Prompt = "Password")]

        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Prompt = "PasswordConfirm")]

        public string PasswordConfirm { get; set; }


    }
}
