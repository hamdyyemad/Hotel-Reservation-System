using AutoMapper;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Models.DTOs.Room;
using HotelBooking.Domain.Models.ViewModels.Room;

namespace HotelBooking.Domain.Models.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            // Entity to DTO mappings
            CreateMap<Room, GetAllRoomsDTO>().ReverseMap();
            CreateMap<Room, GetRoomDTO>().ReverseMap();
            CreateMap<CreateRoomDTO, Room>().ReverseMap();
            CreateMap<UpdateRoomDTO, Room>();

            // DTO to ViewModel mappings && ViewModel to DTO mappings
            CreateMap<GetAllRoomsDTO, GetAllRoomsViewModel>().ReverseMap();
            CreateMap<GetRoomDTO, GetRoomViewModel>().ReverseMap();
            CreateMap<CreateRoomViewModel, CreateRoomDTO>().ReverseMap();
            CreateMap<UpdateRoomViewModel, UpdateRoomDTO>().ReverseMap();
        }
    }
} 