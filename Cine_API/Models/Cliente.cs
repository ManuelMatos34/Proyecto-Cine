using System;
using System.Collections.Generic;

namespace Cine_API.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Usuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Rol { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public string? Status { get; set; }

    public virtual ICollection<Entrada> Entrada { get; set; } = new List<Entrada>();

    public virtual Pedido? Pedido { get; set; }

    public virtual Role? RolNavigation { get; set; }

    public virtual Estatus? StatusNavigation { get; set; }
}
