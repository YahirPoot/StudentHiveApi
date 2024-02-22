using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Administrador
{
    public int IdAdmin { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? IdRol { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
