namespace HotelBooking.Domain.Entities
{
    public class RoomFeedback : BaseModel
    {
        public string Message { get; set; }
        public int Rating { get; set; } // Rating from 1 to 5
        // Foreign key
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
} 