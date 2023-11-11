using System;
using System.Collections.Generic;

namespace EntityDatabaseFirst.Models;

public partial class CategoriaProducto
{
    public short IdCategoria { get; set; }

    public string Categoria { get; set; } = null!;
}
