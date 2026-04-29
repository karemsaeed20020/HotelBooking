using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.DTOs.CountryDTOs
{
    public class CountryDTO
    {
        public int Id { get; init; }
        public string CountryName { get; init; } = default!;
        public string CountryCode { get; init; } = default!;
        public bool IsActive { get; init; }
    }
}
