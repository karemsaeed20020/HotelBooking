using HotelBooking.Application.Features.Rooms.Queries.Request;
using HotelBooking.Domain.Contracts.Specifications;
using HotelBooking.Domain.Entities.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Specifications.RoomSpecifications
{
    public class RoomPaginationSpecification : IPaginateSpecification<Room>
    {
        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool ISPaginated { get; private set; }
        private RoomPaginationSpecification()
        {
            
        }
        public static RoomPaginationSpecification ForQuery(RoomQueryParams queryParams)
        {
            return new()
            {
                Take = queryParams.PageSize,
                Skip = (queryParams.PageSize - 1) * queryParams.PageSize,
                ISPaginated = true
            };
        }
    }
}
