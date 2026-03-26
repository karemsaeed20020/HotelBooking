using AutoMapper;
using HotelBooking.Application.Features.RoomTypes.Commands.Requests;
using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Results;
using HotelBooking.Domain.Entities.Rooms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.RoomTypes.Commands.Handlers
{
    public class UpdateRoomTypeCommandHandler
    : IRequestHandler<UpdateRoomTypeWithUserCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRoomTypeCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Handle(
            UpdateRoomTypeWithUserCommand request,
            CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<RoomType>();

            // 1. Check Exists
            var roomType = await repo.GetByIdAsync(request.Command.RoomTypeId);
            if (roomType is null)
            {
                return Result.Fail(
                    Error.NotFound(
                        "RoomType.NotFound",
                        $"RoomType with id {request.Command.RoomTypeId} not found"
                    )
                );
            }

            
            _mapper.Map(request.Command, roomType);

            roomType.CreatedBy = request.UserEmail;

            // 3. Save
            int result = await _unitOfWork.SaveChangesAsync();

            if (result == 0)
            {
                return Result.Fail(
                    Error.Failure(
                        "RoomType.UpdateFailed",
                        "RoomType can't be updated"
                    )
                );
            }

            return Result.Ok();
        }
    }
}
