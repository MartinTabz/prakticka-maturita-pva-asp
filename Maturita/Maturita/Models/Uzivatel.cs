﻿using Microsoft.AspNetCore.Identity;

namespace Maturita.Models
{
    public class Uzivatel : IdentityUser
    {
        public string? GitHub {  get; set; }

        public ICollection<Poznamka> Poznamky { get; set; }
    }
}
