using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.DTOs.RoomDTOs
{
    public class RoomDTO
    {
        public int Id { get; init; }
        public decimal Price { get; init; }
        public bool IsActive { get; init; }
        public string BedType { get; init; } = default!;
        public string ViewType { get; init; } = default!;
        public string Status { get; init; } = default!;
        public int RoomTypeID { get; init; }
        public string RoomNumber { get; init; } = default!;
    }
}
