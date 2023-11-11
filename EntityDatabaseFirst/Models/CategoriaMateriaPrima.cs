using System;
using System.Collections.Generic;

namespace EntityDatabaseFirst.Models;

public partial class CategoriaMateriaPrima
{
    public int Id { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public string? MedidaCategoria { get; set; }

    public virtual ICollection<MateriaPrima> MateriaPrimas { get; set; } = new List<MateriaPrima>();
}
