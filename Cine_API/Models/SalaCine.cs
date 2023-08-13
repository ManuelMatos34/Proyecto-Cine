using System;
using System.Collections.Generic;

namespace Cine_API.Models;

public partial class SalaCine
{
    public int IdSala { get; set; }

    public int CapacidadSala { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Historial> Historials { get; set; } = new List<Historial>();

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Estatus? StatusNavigation { get; set; }
}
