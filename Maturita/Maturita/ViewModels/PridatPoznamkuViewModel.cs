using System.ComponentModel.DataAnnotations;

namespace Maturita.ViewModels
{
    public class PridatPoznamkuViewModel
    {
        [Display(Name = "Nadpis")]
        [Required(ErrorMessage = "Nadpis je požadován")]
        public string Heading { get; set; }
        [Display(Name = "Popis poznámky")]
        public string? Text { get; set; }
        [Display(Name = "Je důležité")]
        public bool IsImportant { get; set; } = false;
    }
}
