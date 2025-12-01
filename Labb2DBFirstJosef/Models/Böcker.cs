using System;
using System.Collections.Generic;

namespace Labb2DBFirstJosef.Models;

public partial class Böcker
{
    public string Isbn13 { get; set; } = null!;

    public string Titel { get; set; } = null!;

    public string? Språk { get; set; }

    public decimal? Pris { get; set; }

    public DateOnly? Utgivningsdatum { get; set; }

    public int FörfattareId { get; set; }

    public int? FörlagsId { get; set; }

    public virtual Författare Författare { get; set; } = null!;

    public virtual Förlag? Förlags { get; set; }

    public virtual ICollection<LagerSaldo> LagerSaldos { get; set; } = new List<LagerSaldo>();
}
