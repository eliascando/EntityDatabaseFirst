using System;
using System.Collections.Generic;

namespace EntityDatabaseFirst.Models;

public partial class MateriaPrima
{
    public int Id { get; set; }

    public int CategoriaId { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? Nombre { get; set; }

    public int ProveedorId { get; set; }

    public int Stock { get; set; }

    public double Precio { get; set; }

    public DateTime FechaCompra { get; set; }

    public short ColorId { get; set; }

    public virtual CategoriaMateriaPrima Categoria { get; set; } = null!;

    public virtual Colore Color { get; set; } = null!;
}
