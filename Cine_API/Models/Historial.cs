using System;
using System.Collections.Generic;

namespace Cine_API.Models;

public partial class Historial
{
    public int IdRegistro { get; set; }

    public DateTime Fecha { get; set; }

    public int IdHorario { get; set; }

    public int IdPelicula { get; set; }

    public int IdSala { get; set; }

    public TimeSpan HoraInicio { get; set; }

    public virtual Horario IdHorarioNavigation { get; set; } = null!;

    public virtual Pelicula IdPeliculaNavigation { get; set; } = null!;

    public virtual SalaCine IdSalaNavigation { get; set; } = null!;
}
