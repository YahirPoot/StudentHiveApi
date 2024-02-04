namespace StudentHive.Domain.Dtos;

public class RentalHouseDTO{ /* It's just for transferring data */
        public int ID_Publication { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool Status { get; set; }
        public int RentPrice { get; set; }
        public DateTime PublicationDate { get; set; }
        public List<string> Image_Url_P { get; set; } = null!;
        public RentalHouseDetailDTO DetailRentalHouse { get; set; } = null!;
        public HouseServiceDTO HouseService { get; set; } = null!;
        // public TypeHouseRentalDTO TypeHouseRental { get; set; } = null!;
        // public LocationDTO Location { get; set; } = null!;
        public string ID_User { get; set; } = null!;
}





