using HotelBooking.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.States.Commands.Requests
{
    public record CreateStateWithUserCommand(CreateStateCommand Command, string UserEmail) : IRequest<Result<int>>;
}
