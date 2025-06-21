namespace HotelBooking.Domain.Entities
{
    public class RoomComment : BaseModel
    {
        public string Content { get; set; }

        // Foreign key
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
} 