using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.DTOs.StateDTOs
{
    public class StateDTO
    {
        public int Id { get; init; }
        public string StateName { get; init; } = default!;
        public bool IsActive { get; init; }
    }
}
