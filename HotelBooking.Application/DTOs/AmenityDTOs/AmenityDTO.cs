using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.DTOs.AmenityDTOs
{
    public class AmenityDTO
    {
        public int Id { get; init; }
        public string Name { get; init; } = default!;
        public string Description { get; init; } = default!;
        public bool IsActive { get; init; }
    }
}
