using HotelBooking.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities.Reservations
{
    public class Reservation : BaseEntity
    {
        public DateTime BookingDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public ReservationStatus Status { get; set; }

        public decimal TotalCost { get; set; }
        public int NumberOfNights { get; set; }

        public string UserID { get; set; } = default!;
        public Feedback? Feedback { get; set; }

        public ICollection<ReservationRoom> ReservationRooms { get; set; } = [];

    }
}
