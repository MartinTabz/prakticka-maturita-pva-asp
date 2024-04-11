using System.ComponentModel.DataAnnotations;

namespace Maturita.ViewModels
{
    public class RegistrovatViewModel
    {
        [Display(Name = "Uživatelské jméno")]
        [Required(ErrorMessage = "Uživatelské jméno je požadováno")]
        public string UserName { get; set; }

        [Display(Name = "Heslo")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Kontrola hesla")]
        [Required(ErrorMessage = "Kontrola hesla je požadována")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hesla se neshodují")]
        public string ConfirmPassword { get; set; }
    }
}