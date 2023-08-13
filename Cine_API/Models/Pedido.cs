using System;
using System.Collections.Generic;

namespace Cine_API.Models;

public partial class Pedido
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public int? IdComida { get; set; }

    public int IdEntradas { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Comidum? IdComidaNavigation { get; set; }

    public virtual Entrada IdEntradasNavigation { get; set; } = null!;
}
