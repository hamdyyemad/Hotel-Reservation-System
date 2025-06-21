using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace HotelBooking.Infrastructure.Data
{
    public class Context : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomBooking> RoomBookings { get; set; }
        public DbSet<RoomComment> RoomComments { get; set; }
        public DbSet<RoomFacility> RoomFacilities { get; set; }
        public DbSet<RoomFeedback> RoomFeedbacks { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=ATLAS-CB38B4CQ0;initial catalog=HotelBooking;trusted_connection=true;TrustServerCertificate=True;")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging(true);
        }
    
    }
}
