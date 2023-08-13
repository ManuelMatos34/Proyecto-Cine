using System;
using System.Collections.Generic;

namespace Cine_API.Models;

public partial class Horario
{
    public int IdHorario { get; set; }

    public int IdPelicula { get; set; }

    public int IdSala { get; set; }

    public TimeSpan HoraInicio { get; set; }

    public virtual ICollection<Entrada> Entrada { get; set; } = new List<Entrada>();

    public virtual ICollection<Historial> Historials { get; set; } = new List<Historial>();

    public virtual Pelicula IdPeliculaNavigation { get; set; } = null!;

    public virtual SalaCine IdSalaNavigation { get; set; } = null!;
}
