using System;

namespace HotelReservationSystem.Discuss.Room_Module_and_Related.Models
{
    public class RoomImage
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] FileData { get; set; }
        public long FileSize { get; set; }
        public bool IsMainImage { get; set; }
        public DateTime UploadDate { get; set; }

        // Foreign key
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
} 