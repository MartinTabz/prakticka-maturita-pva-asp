using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maturita.Models
{
    public class Poznamka
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Nadpis { get; set; }

        public string? Text { get; set; }

        public bool Dulezite { get; set; } = false;

        [ForeignKey("Uzivatel")]
        public string UzivatelId { get; set; }

        public Uzivatel? Uzivatel { get; set; }
    }
}