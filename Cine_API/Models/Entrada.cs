using System;
using System.Collections.Generic;

namespace Cine_API.Models;

public partial class Entrada
{
    public int IdEntradas { get; set; }

    public int IdHorario { get; set; }

    public int IdCliente { get; set; }

    public string Asiento { get; set; } = null!;

    public decimal Precio { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Horario IdHorarioNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
