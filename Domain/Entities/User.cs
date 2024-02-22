using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class User
{
    public int IdUser { get; set; }

    public int? UserAge { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? Description { get; set; }

    public long? PhoneNumber { get; set; }

    public string? ProfilePhotoUrl { get; set; }

    public byte? Genderu { get; set; }

    public int? IdTypeReport { get; set; }

    public int? IdRol { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ReportType? IdTypeReportNavigation { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<RentalHouse> RentalHouses { get; set; } = new List<RentalHouse>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<Report> IdReport { get; set; } = new List<Report>();
}
