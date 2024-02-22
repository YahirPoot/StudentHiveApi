using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Report
{
    public int IdReport { get; set; }

    public int IdReportType { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ReportType IdReportTypeNavigation { get; set; } = null!;

    public virtual ICollection<RentalHouse> IdPublication { get; set; } = new List<RentalHouse>();

    public virtual ICollection<User> IdUser { get; set; } = new List<User>();
}
