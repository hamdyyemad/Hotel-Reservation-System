namespace HotelBooking.Domain.Entities
{
    public class RoomBooking : BaseModel
    {
        public int NumberOfGuests { get; set; }
        public decimal TotalPrice { get; set; }
        public string BookingStatus { get; set; } // e.g., "Pending", "Confirmed", "Cancelled"

        // Foreign key
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
} 