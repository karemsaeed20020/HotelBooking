using HotelBooking.Application.DTOs.HotelSearchDTOs;
using HotelBooking.Application.Features.HotelSearch.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers
{
    public class HotelSearchController : ApiBaseController
    {
        private readonly IMediator _mediator;

        public HotelSearchController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet("Type")]
        public async Task<ActionResult<IEnumerable<RoomSearchDTO>>> SearchByRoomType(string roomTypeName)
        {
            var result = await _mediator.Send(new SearchRoomsByTypeQuery(roomTypeName));

            return HandleResult(result);
        }

        [HttpGet("View")]
        public async Task<ActionResult<IEnumerable<RoomSearchDTO>>> SearchByViewType(string viewType)
        {
            var result = await _mediator.Send(new SearchRoomsByViewTypeQuery(viewType));

            return HandleResult(result);
        }

        [HttpGet("Amenity")]
        public async Task<ActionResult<IEnumerable<RoomSearchDTO>>> SearchByAmenity(string amenityName)
        {
            var result = await _mediator.Send(new SearchRoomsByAmenityQuery(amenityName));

            return HandleResult(result);
        }

        [HttpGet("Rating")]
        public async Task<ActionResult<IEnumerable<RoomSearchDTO>>> SearchByMinRating(int minRating)
        {
            var result = await _mediator.Send(new SearchRoomsByMinRatingQuery(minRating));

            return HandleResult(result);
        }


    }
}
