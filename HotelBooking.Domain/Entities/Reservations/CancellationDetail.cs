using HotelBooking.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities.Reservations
{
    public class CancellationDetail : BaseEntity
    {
        public int? CancellationRequestId { get; set; }
        public int? ReservationRoomId { get; set; }

        public CancellationRequest? CancellationRequest { get; set; }
        public ReservationRoom? ReservationRoom { get; set; }
    }
}
