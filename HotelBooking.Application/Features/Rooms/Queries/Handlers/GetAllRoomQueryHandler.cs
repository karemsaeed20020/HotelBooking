using AutoMapper;
using HotelBooking.Application.DTOs.RoomDTOs;
using HotelBooking.Application.Features.Rooms.Commands.Requests;
using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Results;
using HotelBooking.Application.Specifications.RoomSpecifications;
using HotelBooking.Domain.Contracts.Specifications;
using HotelBooking.Domain.Entities.Rooms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.Rooms.Queries.Handlers
{
    public class GetAllRoomQueryHandler : IRequestHandler<GetAllRoomQuery, Result<PaginatedResultDTO<RoomDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllRoomQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<PaginatedResultDTO<RoomDTO>>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Room>();
            var matchingSpec = RoomCriteriaSpecification.MatchingQuery(request.QueryParams);
            var sortingSpec = RoomSortingSpecification.ByOption(request.QueryParams.SortingOption);
            var paginationSpec = RoomPaginationSpecification.ForQuery(request.QueryParams);


            var rooms = await repo.GetAllAsync([matchingSpec, sortingSpec, paginationSpec]);
            var dataToReturn = _mapper.Map<IEnumerable<RoomDTO>>(rooms);
            var countOfReturnData = dataToReturn.Count();

            var countOfAllRooms = await repo.CountAsync(new List<IBaseSpecification<Room>> { matchingSpec });

            return new PaginatedResultDTO<RoomDTO>(request.QueryParams.PageIndex, countOfReturnData, countOfAllRooms, dataToReturn);
        }
    }
}
