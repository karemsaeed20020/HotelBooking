using HotelBooking.Application.Features.Rooms.Queries.Request;
using HotelBooking.Domain.Contracts.Specifications;
using HotelBooking.Domain.Entities.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Specifications.RoomSpecifications
{
    public class RoomCriteriaSpecification : ICriteriaSpecification<Room>
    {
        public Expression<Func<Room, bool>> Criteria { get; }
        public RoomCriteriaSpecification(Expression<Func<Room, bool>> criteria)
        {
            Criteria = criteria;
        }
        public static RoomCriteriaSpecification ByRoomTypeId(int roomTypeId) => new(r => r.RoomTypeId == roomTypeId);
        public static RoomCriteriaSpecification ByRoomNumber(string number) => new(r => r.RoomNumber == number);
        public static RoomCriteriaSpecification MatchingQuery(RoomQueryParams queryParams)
           => new(r =>
               (!queryParams.RoomTypeId.HasValue || r.RoomTypeId == queryParams.RoomTypeId.Value)
               && (string.IsNullOrEmpty(queryParams.SearchByRoomNumber)
                   || r.RoomNumber.Contains(queryParams.SearchByRoomNumber))
               && (!queryParams.Status.HasValue || r.Status == (BookingStatus)queryParams.Status.Value)
           );
    }
}
