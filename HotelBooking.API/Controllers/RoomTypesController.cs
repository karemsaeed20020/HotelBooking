using HotelBooking.Application.DTOs.RoomTypeDTOs;
using HotelBooking.Application.Features.RoomTypes.Commands.Requests;
using HotelBooking.Application.Features.RoomTypes.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypesController : ApiBaseController
    {
        private readonly IMediator _mediator;
        public RoomTypesController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateRoomType(CreateRoomTypeCommand command)
        {
            var wrapper = new CreateRoomTypeWithUserCommand(command, GetEmailFromToken());  
            var result = await _mediator.Send(wrapper); 
            return HandleResult(result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomTypeDTO>>> GetAllRoomTypes(bool? isActive)
        {
            var result = await _mediator.Send(new GetAllRoomTypesQuery(isActive));

            return HandleResult(result);
        }

        [HttpGet("{roomTypeId}")]
        public async Task<ActionResult<RoomTypeDTO>> GetRoomTypeById(int roomTypeId)
        {
            var result = await _mediator.Send(new GetRoomTypeByIdQuery(roomTypeId));

            return HandleResult(result);
        }
        [HttpDelete("{roomTypeId}")]
        public async Task<IActionResult> DeleteRoomType(int roomTypeId)
        {
            var result = await _mediator.Send(new DeleteRoomTypeCommand(roomTypeId));
            return HandleResult(result);
        }
        [HttpPut("{roomTypeId}/toggle-active")]
        public async Task<IActionResult> ToggleRoomType(int roomTypeId)
        {
            var result = await _mediator.Send(new ToggleRoomTypeActiveCommand(roomTypeId));
            return HandleResult(result);
        }
        [HttpPut("{roomTypeId}")]
        public async Task<IActionResult> UpdateRoomType(
            int roomTypeId,
            [FromBody] UpdateRoomTypeCommand command)
        {
            if (roomTypeId != command.RoomTypeId)
            {
                return BadRequest("RoomTypeId in URL does not match ID in body");
            }
            var wrapper = new UpdateRoomTypeWithUserCommand(command, GetEmailFromToken());

            var result = await _mediator.Send(wrapper);

            return HandleResult(result);
        }

    }
}
