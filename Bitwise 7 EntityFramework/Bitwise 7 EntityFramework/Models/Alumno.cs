using System;
using System.Collections.Generic;

namespace Bitwise_7_EntityFramework.Models;

public partial class Alumno
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Telefono { get; set; }

    public bool? Deudor { get; set; }

    public decimal? MontoDeuda { get; set; }
}
