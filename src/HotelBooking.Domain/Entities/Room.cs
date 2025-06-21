namespace HotelBooking.Domain.Entities
{
    public class Room : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal PricePerNight { get; set; }
        public decimal DiscountPercentage { get; set; }
        public int Capacity { get; set; }
        
        public int NumberOfBedrooms { get; set; }
        public int NumberOfLivingRooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfDiningRooms { get; set; }
        public int UnitsReady { get; set; }
        public int NumberOfRefrigerators { get; set; }
        public int NumberOfTelevisions { get; set; }

        // Navigation properties
        public ICollection<RoomImage> Images { get; set; }
        public ICollection<RoomFacility> Facilities { get; set; }
        public ICollection<RoomFeedback> Feedbacks { get; set; }
        public ICollection<RoomComment> Comments { get; set; }
        public ICollection<RoomBooking> Bookings { get; set; }
    }
} 