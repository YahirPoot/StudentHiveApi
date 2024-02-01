namespace StudentHive.Domain.Dtos;

public class RentalHouseDTO{ /* It's just for transferring data */
        public int ID_Publication { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int RentPrice { get; set; }
        public List<string> Image_Url_P { get; set; } = null!;
        public int NumberOfRooms { get; set; }
        public bool OwnHouse { get; set; }
        public bool SharedRoom { get; set; }
        public int NumberOfGuests { get; set; }
        public int NumberOfBathrooms { get; set; }
        public DateTime PublicationDate { get; set; }
        public LocationDTO Location { get; set; } = null!;
        public HouserServiceDTO Service { get; set; } = null!;
        public int ID_User { get; set; }    
}





