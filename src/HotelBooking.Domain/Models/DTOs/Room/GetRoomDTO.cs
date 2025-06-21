namespace HotelBooking.Domain.Models.DTOs.Room
{
    public class GetRoomDTO
    {
        public int ID { get; set; }
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
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 