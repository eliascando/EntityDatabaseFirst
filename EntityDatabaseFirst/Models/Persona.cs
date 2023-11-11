using System;
using System.Collections.Generic;

namespace EntityDatabaseFirst.Models;

public partial class Persona
{
    public int Id { get; set; }

    public string? Cedula { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Password { get; set; }

    public bool? Admin { get; set; }

    public string? Imagen { get; set; }

    public DateTime? Edad { get; set; }

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();
}
