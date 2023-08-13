using System;
using System.Collections.Generic;

namespace Cine_API.Models;

public partial class Role
{
    public string Rol { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
