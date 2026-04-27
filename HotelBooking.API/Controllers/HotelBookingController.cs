using HotelBooking.Application.Features.HotelBooking.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HotelBookingController : ApiBaseController
    {
        private readonly IMediator _mediator;

        public HotelBookingController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost]
        public async Task<ActionResult<int>> CreateReservation(CreateReservationCommand command)
        {
            var userId = GetUserIdFromToken();

            var wrapper = new CreateReservationWithUserCommand(command, userId);
            var result = await _mediator.Send(wrapper);

            return HandleResult(result);
        }

        [HttpPost("AddGuests")]
        public async Task<IActionResult> AddGuestsToReservation(AddGuestsToReservationCommand command)
        {
            var userId = GetUserIdFromToken();
            var userEmail = GetEmailFromToken();

            var wrapper = new AddGuestsToReservationWithUserCommand(userId, userEmail, command);

            var result = await _mediator.Send(wrapper);

            return HandleResult(result);
        }


    }
}
