namespace HotelBooking.Domain.Entities
{
    public class RoomFacility
    {
        public int Id { get; set; }
        public string Name { get; set; }  // e.g., "Free WiFi", "Air Conditioning", "Swimming Pool"
        public string Description { get; set; }  // Detailed description of the facility
        public string Icon { get; set; }  // Icon name or path for UI display
        public bool IsAvailable { get; set; }  // Whether this facility is currently available
        public string Category { get; set; }  // e.g., "Basic", "Premium", "Luxury"
        public int DisplayOrder { get; set; }  // For controlling the display order in UI

        // Foreign key
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
} 