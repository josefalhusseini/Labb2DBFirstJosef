using System;
using System.Collections.Generic;

namespace Labb2DBFirstJosef.Models;

public partial class Förlag
{
    public int Id { get; set; }

    public string? Namn { get; set; }

    public string? Kontaktperson { get; set; }

    public string? Telefon { get; set; }

    public virtual ICollection<Böcker> Böckers { get; set; } = new List<Böcker>();
}
