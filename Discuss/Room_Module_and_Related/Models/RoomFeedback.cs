using System;

namespace HotelReservationSystem.Discuss.Room_Module_and_Related.Models
{
    public class RoomFeedback
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int Rating { get; set; } // Rating from 1 to 5
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; } // Assuming you have user authentication

        // Foreign key
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
} 