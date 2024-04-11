using System.ComponentModel.DataAnnotations;

namespace Maturita.ViewModels
{
    public class PrihlasitViewModel
    {
        [Display(Name = "Uživatelské jméno")]
        [Required(ErrorMessage = "Uživatelské jméno je požadováno")]
        public string UserName { get; set; }

        [Display(Name = "Heslo")]
        [Required(ErrorMessage = "Heslo je požadováno")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}