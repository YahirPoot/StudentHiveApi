using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class User
{
    public int IdUser { get; set; }

    public int UserAge { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public long PhoneNumber { get; set; }

    public string ProfilePhotoUrl { get; set; } = null!;

    public string? Genderu { get; set; }

    public virtual ICollection<RentalHouse> RentalHouse { get; set; } = new List<RentalHouse>();
}
