using System;
using System.Collections.Generic;

namespace Labb2DBFirstJosef.Models;

public partial class OrderRader
{
    public int Id { get; set; }

    public int? KundId { get; set; }

    public DateTime? OrderDatum { get; set; }

    public virtual Kunder? Kund { get; set; }
}
