
using HotelBooking.Domain.Contracts.Specifications;
using HotelBooking.Domain.Entities.Rooms;
using System.Linq.Expressions;

namespace HotelBooking.Application.Specifications.HotelSearchSpecifications
{
    public class HotelSearchCriteriaSpecification : ICriteriaSpecification<Room>
    {
        public Expression<Func<Room, bool>> Criteria { get; }
        private HotelSearchCriteriaSpecification(Expression<Func<Room, bool>> criteria)
         => Criteria = criteria;

        public static HotelSearchCriteriaSpecification ByAmenity(string amenityName)
           => new(r =>
               r.IsActive
               && r.Status == BookingStatus.Available
               && r.RoomType.RoomAmenities
                   .Any(ra => ra.Amenity.Name.Contains(amenityName))

           );
        public static HotelSearchCriteriaSpecification ByRoomTypeName(string roomTypeName)
           => new(r =>
               r.IsActive
               && r.Status == BookingStatus.Available
               && r.RoomType.TypeName.Contains(roomTypeName)

           );

        public static HotelSearchCriteriaSpecification ByViewType(string viewType)
          => new(r =>
              r.IsActive
              && r.Status == BookingStatus.Available
              && r.ViewType.Contains(viewType)
          );
        public static HotelSearchCriteriaSpecification ByMinAverageRating(int minRating)
            => new(r =>
                r.IsActive
                && r.Status == BookingStatus.Available

            );

    }
}
