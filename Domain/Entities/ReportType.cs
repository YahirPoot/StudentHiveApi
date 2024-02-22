using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class ReportType
{
    public int IdTypeReport { get; set; }

    public string? TypeReportName { get; set; }

    public virtual ICollection<RentalHouse> RentalHouses { get; set; } = new List<RentalHouse>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
