using HotelBooking.Application.DTOs.StateDTOs;
using HotelBooking.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.States.Queries.Requests
{
    public record GetStateByIdQuery(int StateId) : IRequest<Result<StateDTO>>;
}
