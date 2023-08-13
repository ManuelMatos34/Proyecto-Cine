using System;
using System.Collections.Generic;

namespace Cine_API.Models;

public partial class Comidum
{
    public int IdComida { get; set; }

    public DateTime Fecha { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
