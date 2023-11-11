using System;
using System.Collections.Generic;

namespace EntityDatabaseFirst.Models;

public partial class Proveedor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string CedulaRuc { get; set; } = null!;

    public string? Correo { get; set; }

    public string Telefono { get; set; } = null!;

    public bool Activo { get; set; }
}
