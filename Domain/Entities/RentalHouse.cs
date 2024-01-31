namespace StudentHive.Domain.Entities;

public class RentalHouse{

        // [Key]              
        // [DatabaseGenerated(databaseGeneratedOption.Identity)] //hare que sea identity
        public int ID_Publication { get; set; }
        // [Required]
        public required string Title { get; set; }

        // [Required]
        public required List<string> Image_Url_P { get; set; }
        // [Required]
        // [Column(TypeName ="decimal(18,2)")]
        public required int NumberOfRooms { get; set; }
        // [Required]
        public string? Description { get; set; }
        public bool OwnHouse { get; set; }
        public bool SharedRoom { get; set; }
        public int NumberOfGuests { get; set; }
        public int NumberOfBathrooms { get; set; }
        public required Location Location { get; set; }
        public decimal RentPrice { get; set; }
        public DateTime PublicationDate { get; set; }
        // [Required(ErrorMessage = "Service is required")]
        // [ForeignKey("ServiceId")]
        public required Service service { get; set; }
        // [Required]
        // [ForeignKey("UserId")]
        public required User User { get; set; }    
}





