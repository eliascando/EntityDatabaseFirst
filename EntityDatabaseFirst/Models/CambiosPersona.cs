using System;
using System.Collections.Generic;

namespace EntityDatabaseFirst.Models;

public partial class CambiosPersona
{
    public int Id { get; set; }

    public int? IdPersona { get; set; }

    public string? TipoCambio { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? Usuario { get; set; }

    public string? CamposModificados { get; set; }

    public string? ValoresAntiguos { get; set; }

    public string? ValoresNuevos { get; set; }
}
