using System;
using System.Collections.Generic;

namespace EntityDatabaseFirst.Models;

public partial class Registro
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public int IdUsuario { get; set; }

    public string? Descripcion { get; set; }

    public int? Cantidad { get; set; }

    public string IdProducto { get; set; } = null!;

    public virtual Persona IdUsuarioNavigation { get; set; } = null!;
}
