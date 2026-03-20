using HotelBooking.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities.Reservations
{
    public class CancellationRequest : AuditableEntity
    {
        public string CancellationType { get; set; } = default!;
        public string? CancellationReason { get; set; }
        public DateTime RequestedOn { get; set; }
        public CancellationStatus CancellationStatus { get; set; } = default!;

        public string UserId { get; set; } = default!;
        public string? AdminReviewedById { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int ReservationID { get; set; }
        public Reservation Reservation { get; set; } = default!;

        public ICollection<CancellationDetail> CancellationDetails { get; set; } = [];
        public CancellationCharge CancellationCharge { get; set; } = default!;
    }
}
