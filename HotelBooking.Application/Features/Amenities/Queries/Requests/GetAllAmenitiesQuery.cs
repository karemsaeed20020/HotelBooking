using HotelBooking.Application.DTOs.AmenityDTOs;
using HotelBooking.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.Amenities.Queries.Requests
{
    public record GetAllAmenitiesQuery(bool? IsActive) : IRequest<Result<IEnumerable<AmenityDTO>>>;
}
