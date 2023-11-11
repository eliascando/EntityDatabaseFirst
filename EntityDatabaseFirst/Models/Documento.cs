using System;
using System.Collections.Generic;

namespace EntityDatabaseFirst.Models;

public partial class Documento
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }
}
