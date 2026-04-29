using HotelBooking.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.Countries.Commands.Requests
{
    public record UpdateCountryWithUserCommand(UpdateCountryCommand Command, string UserEmail) : IRequest<Result>;
}
