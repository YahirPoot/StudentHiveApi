using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class RentalHouse
{
    public int IdPublication { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool? Status { get; set; }
    public long? RentPrice { get; set; }
    public int? IdRentalHouseDetail { get; set; }
    public int? IdTypeHouseRental { get; set; }
    public DateTime PublicationDate { get; set; }
    public int? IdHouseLocation { get; set; }
    public int? IdHouseService { get; set; }
    public int? IdUser { get; set; }
    public virtual HouseLocation? IdHouseLocationNavigation { get; set; }
    public virtual HouseService? IdHouseServiceNavigation { get; set; }
    public virtual RentalHouseDetail? IdRentalHouseDetailNavigation { get; set; }

    public virtual TypeHouseRental? IdTypeHouseRentalNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
