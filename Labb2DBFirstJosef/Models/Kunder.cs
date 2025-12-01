using System;
using System.Collections.Generic;

namespace Labb2DBFirstJosef.Models;

public partial class Kunder
{
    public int Id { get; set; }

    public string? Förnamn { get; set; }

    public string? Efternamn { get; set; }

    public string? Email { get; set; }

    public string? Telefon { get; set; }

    public virtual ICollection<OrderRader> OrderRaders { get; set; } = new List<OrderRader>();

    public virtual ICollection<Ordrar> Ordrars { get; set; } = new List<Ordrar>();
}
