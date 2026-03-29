using HotelBooking.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.Amenities.Commands.Requests
{
    public record CreateAmenitiesWithUserCommand(CreateAmenitiesCommand Command, string userEmail) : IRequest<Result<int>>;
}
