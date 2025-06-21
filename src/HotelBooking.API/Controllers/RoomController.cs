using Microsoft.AspNetCore.Mvc;
using HotelBooking.Application.Services;
using HotelBooking.Domain.Models.ViewModels;
using HotelBooking.Domain.Models.DTOs.Room;
using HotelBooking.Domain.Models.ViewModels.Room;

namespace HotelBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly RoomService _roomService;
        private readonly MapperService _mappingService;

        public RoomController(RoomService roomService, MapperService mappingService)
        {
            _roomService = roomService;
            _mappingService = mappingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = await _roomService.GetAll();
            var res = _mappingService.Map<GetAllRoomsDTO, GetAllRoomsViewModel>(query);
            return Ok(new SuccessResponseViewModel<IEnumerable<GetAllRoomsViewModel>>(res, "Rooms retrieved successfully"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var room = await _roomService.GetRoomById(id);
            var res = _mappingService.Map<GetRoomDTO, GetRoomViewModel>(room);
            return Ok(new SuccessResponseViewModel<GetRoomViewModel>(res, "Room retrieved successfully"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomViewModel createRoomViewModel)
        {
            var createRoomDTO = _mappingService.Map<CreateRoomViewModel, CreateRoomDTO>(createRoomViewModel);
            await _roomService.CreateRoomAsync(createRoomDTO);
            return Ok(new SuccessResponseViewModel<object>(null, "Room created successfully"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] UpdateRoomViewModel updateRoomViewModel)
        {
            var updateRoomDTO = _mappingService.Map<UpdateRoomViewModel, UpdateRoomDTO>(updateRoomViewModel);
            await _roomService.UpdateRoomAsync(id, updateRoomDTO);
            return Ok(new SuccessResponseViewModel<object>(null, "Room updated successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _roomService.DeleteRoomAsync(id);
            return Ok(new SuccessResponseViewModel<object>(null, "Room deleted successfully"));
        }
    }
} 