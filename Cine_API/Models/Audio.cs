using System;
using System.Collections.Generic;

namespace Cine_API.Models;

public partial class Audio
{
    public string Audio1 { get; set; } = null!;

    public virtual ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>();
}
