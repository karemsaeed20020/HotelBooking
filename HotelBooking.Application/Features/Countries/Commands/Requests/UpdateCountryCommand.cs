using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.Countries.Commands.Requests
{
    public class UpdateCountryCommand
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; } = default!;
        public string CountryCode { get; set; } = default!;
    }
}
