using HotelBooking.Application.DTOs.CountryDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.Countries.Queries.Requests
{
    public record GetAllCountriesQuery(bool? IsActive) : IRequest<IEnumerable<CountryDTO>>;
}
