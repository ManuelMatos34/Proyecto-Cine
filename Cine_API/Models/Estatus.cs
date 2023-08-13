using System;
using System.Collections.Generic;

namespace Cine_API.Models;

public partial class Estatus
{
    public string Estatus1 { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>();

    public virtual ICollection<SalaCine> SalaCines { get; set; } = new List<SalaCine>();
}
