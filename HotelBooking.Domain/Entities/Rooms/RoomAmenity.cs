using HotelBooking.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities.Rooms
{
    public class RoomAmenity : BaseEntity
    {
        public int RoomTypeID { get; set; }
        public RoomType RoomType { get; set; } = default!;

        public int AmenityID { get; set; }
        public Amenity Amenity { get; set; } = default!;
    }
}
