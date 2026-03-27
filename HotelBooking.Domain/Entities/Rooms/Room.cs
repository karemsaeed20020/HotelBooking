using HotelBooking.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities.Rooms
{
    public class Room : AuditableEntity
    {
        public string RoomNumber { get; set; } = default!;
        public decimal Price { get; set; }
        public string BedType { get; set; } = default!;
        public string ViewType { get; set; } = default!;
        public bool IsActive { get; set; } = true;
        public BookingStatus Status { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; } = default!;
    }
}
