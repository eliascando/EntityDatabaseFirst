using System;
using System.Collections.Generic;

namespace EntityDatabaseFirst.Models;

public partial class Producto
{
    public int Idproducto { get; set; }

    public string Categoria { get; set; } = null!;

    public string Talla { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Color { get; set; } = null!;

    public int Stock { get; set; }

    public double Precio { get; set; }

    public bool? Activo { get; set; }
}
