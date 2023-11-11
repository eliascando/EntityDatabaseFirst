using System;
using System.Collections.Generic;

namespace EntityDatabaseFirst.Models;

public partial class Colore
{
    public short IdColor { get; set; }

    public string Color { get; set; } = null!;

    public virtual ICollection<MateriaPrima> MateriaPrimas { get; set; } = new List<MateriaPrima>();
}
