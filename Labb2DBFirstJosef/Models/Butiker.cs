using System;
using System.Collections.Generic;

namespace Labb2DBFirstJosef.Models;

public partial class Butiker
{
    public int Id { get; set; }

    public string Namn { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string Stad { get; set; } = null!;

    public string Postnummer { get; set; } = null!;

    public virtual ICollection<LagerSaldo> LagerSaldos { get; set; } = new List<LagerSaldo>();
}
