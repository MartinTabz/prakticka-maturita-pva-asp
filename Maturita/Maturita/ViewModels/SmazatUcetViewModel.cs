using System.ComponentModel.DataAnnotations;

namespace Maturita.ViewModels
{
    public class SmazatUcetViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Heslo je povinné")]
        [Display(Name = "Heslo pro ověření")]
        public required string Password { get; set; }
    }
}
