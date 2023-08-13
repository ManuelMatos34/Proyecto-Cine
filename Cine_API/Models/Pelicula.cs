using System;
using System.Collections.Generic;

namespace Cine_API.Models;

public partial class Pelicula
{
    public int IdPelicula { get; set; }

    public string Titulo { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public string Duracion { get; set; } = null!;

    public string Sinopsis { get; set; } = null!;

    public string? Poster { get; set; }

    public string? Idioma { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Trailer { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Historial> Historials { get; set; } = new List<Historial>();

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Audio? IdiomaNavigation { get; set; }

    public virtual Estatus? StatusNavigation { get; set; }
}
