using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using HotelBooking.Domain.Models.DTOs.Room;
using HotelBooking.Infrastructure.Repositories;

namespace HotelBooking.Application.Services
{
    public class RoomService
    {
        private readonly GeneralRepository<Room> _roomRepository;
        private readonly MapperService _mappingService;
        private readonly ValidationService _validationService;

        public RoomService(MapperService mappingService, ValidationService validationService)
        {
            _roomRepository = new GeneralRepository<Room>();
            _mappingService = mappingService;
            _validationService = validationService;
        }

        public async Task<IEnumerable<GetAllRoomsDTO>> GetAll()
        {
            var roomsQuery = await Task.Run(() => _roomRepository.GetAll());
            return _mappingService.ProjectTo<Room, GetAllRoomsDTO>(roomsQuery);
        }

        public async Task<GetRoomDTO> GetRoomById(int id)
        {
            var room = await _validationService.IsExist(_roomRepository, (r => r.ID == id), ErrorCode.RoomNotFound, "This room isn't found");
            return _mappingService.Map<Room, GetRoomDTO>(room);
        }

        public async Task CreateRoomAsync(CreateRoomDTO dto)
        {
            // var existingRoom = await _roomRepository.GetAll()
            //     .FirstOrDefaultAsync(r => r.Title == dto.Title && r.Location == dto.Location);
            
            // if (existingRoom != null)
            // {
            //     throw new Exception("A room with this title already exists at this location")
            //     {
            //         Data = { { "ErrorCode", ErrorCode.RoomAlreadyExist } }
            //     };
            // }
            await _validationService.IsNotExist(
                _roomRepository,
                r => r.Title == dto.Title && r.Location == dto.Location,
                ErrorCode.RoomAlreadyExist,
                "A room with this title already exists at this location"
            );

            var room = _mappingService.Map<CreateRoomDTO, Room>(dto);
            await _roomRepository.Add(room);
        }

        public async Task UpdateRoomAsync(int id, UpdateRoomDTO updateRoomDTO)
        {
            await _validationService.IsNotExist(
                _roomRepository,
                r => r.Title == updateRoomDTO.Title && r.Location == updateRoomDTO.Location && r.ID != id,
                ErrorCode.RoomAlreadyExist,
                "A room with this title already exists at this location"
            );

            var room = await _validationService.IsExist(_roomRepository, r => r.ID == id, ErrorCode.RoomNotFound, "This room isn't found");

            _mappingService.Map(updateRoomDTO, room);
            await _roomRepository.Update(room);
        }

        public async Task DeleteRoomAsync(int id)
        {
            await _validationService.IsExist(_roomRepository, id, ErrorCode.RoomNotFound);
            await _roomRepository.Delete(id);
        }
    }
} 