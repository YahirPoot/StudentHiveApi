namespace StudentHive.Domain.Dtos;

public class RentalHouseDTO
{ /* It's just for transferring data */

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

    public virtual HouseServiceDTO? IdHouseServiceNavigation { get; set; } // Se usa para crear 

    public virtual HouseLocationDTO? IdLocationNavigation { get; set; } // Se usa para crear 

    public virtual RentalHouseDetailDTO? IdRentalHouseDetailNavigation { get; set; } // Se usa para crear 

    public virtual TypeReportDTO? IdTypeReportNavigation { get; set; } //solo lo verá el admin

    public virtual UserDTO? IdUserNavigation { get; set; } // Se usa para crear

//     public virtual ICollection<ImageRentalHouseDTO> Images { get; set; } = new List<ImageRentalHouseDTO>(); //se usa para crear

    public virtual ICollection<RequestDTO> Requests { get; set; } = new List<RequestDTO>(); //se usa para crear

}





