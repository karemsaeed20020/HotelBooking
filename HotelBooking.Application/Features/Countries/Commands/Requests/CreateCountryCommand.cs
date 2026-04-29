using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.Countries.Commands.Requests
{
    public class CreateCountryCommand
    {
        public string CountryName { get; set; } = default!;
        public string CountryCode { get; set; } = default!;
    }
}
