using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class RentalHouse
{
    public int IdPublication { get; set; }  

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Status { get; set; }

    public int? IdTypeReport { get; set; }

    public string WhoElse { get; set; } = null!;

    public long RentPrice { get; set; }

    public string TypeHouse { get; set; } = null!;

    public int? IdRentalHouseDetail { get; set; }

    public DateTime PublicationDate { get; set; }

    public int? IdLocation { get; set; }

    public int? IdHouseService { get; set; }

    public int? IdUser { get; set; }

    public virtual HouseService? IdHouseServiceNavigation { get; set; } // Se usa para crear 

    public virtual Location? IdLocationNavigation { get; set; } // Se usa para crear 

    public virtual RentalHouseDetail? IdRentalHouseDetailNavigation { get; set; } // Se usa para crear 

    public virtual ReportType? IdTypeReportNavigation { get; set; } //solo lo verá el admin

    public virtual User? IdUserNavigation { get; set; } // Se usa para crear

    public virtual ICollection<Image> Images { get; set; } = new List<Image>(); //se usa para crear

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>(); //se usa para crear

    public virtual ICollection<Report> IdReport { get; set; } = new List<Report>(); //solo lo verá el admin
}
