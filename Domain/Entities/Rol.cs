using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? NombreRol { get; set; }

    public virtual ICollection<Administrador> Administrador { get; set; } = new List<Administrador>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
