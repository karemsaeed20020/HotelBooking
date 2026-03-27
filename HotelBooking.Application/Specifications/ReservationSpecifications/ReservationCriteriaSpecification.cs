using HotelBooking.Domain.Contracts.Specifications;
using HotelBooking.Domain.Entities.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Specifications.ReservationSpecifications
{
    public class ReservationCriteriaSpecification : ICriteriaSpecification<Reservation>
    {
        public Expression<Func<Reservation, bool>> Criteria { get; }
        public ReservationCriteriaSpecification(Expression<Func<Reservation, bool>> criteria)
        {   
               Criteria = criteria;
        }
        public static ReservationCriteriaSpecification ByRoomId(int roomId)
                    => new(r =>
                        r.ReservationRooms.Any(rr => rr.RoomID == roomId)
                        && (r.Status == ReservationStatus.Reserved
                            || r.Status == ReservationStatus.CheckedIn)
                    );
    }
}
