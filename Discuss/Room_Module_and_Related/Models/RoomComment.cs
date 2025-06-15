using System;

namespace HotelReservationSystem.Discuss.Room_Module_and_Related.Models
{
    public class RoomComment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; } // Assuming you have user authentication

        // Foreign key
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
} 