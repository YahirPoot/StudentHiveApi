namespace StudentHive.Domain.Entities;

public class RentalHouse{
        public int ID_Publication { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
        public int RentPrice { get; set; }
        public DateTime PublicationDate { get; set; }
        public required List<string> Image_Url_P { get; set; } 
        public required RentalHouseDetail DetailRentalHouse { get; set; }
        public required HouseService HouseService { get; set; }
        // public required TypeHouseRental TypeHouseRental { get; set; }
        // public required Location Location { get; set; }
        public required string ID_User { get; set; }    
}





