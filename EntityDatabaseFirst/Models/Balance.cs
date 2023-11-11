using System;
using System.Collections.Generic;

namespace EntityDatabaseFirst.Models;

public partial class Balance
{
    public int Id { get; set; }

    public string? Producto { get; set; }

    public DateTime? Fecha { get; set; }

    public double? Valor { get; set; }
}
