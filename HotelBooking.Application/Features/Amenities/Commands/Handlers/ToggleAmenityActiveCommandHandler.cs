using HotelBooking.Application.Features.Amenities.Commands.Requests;
using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Results;
using HotelBooking.Application.Specifications.RoomAmenitySpecifications;
using HotelBooking.Domain.Entities.Rooms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.Amenities.Commands.Handlers
{
    public class ToggleAmenityActiveCommandHandler : IRequestHandler<ToggleAmenityActiveCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ToggleAmenityActiveCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(ToggleAmenityActiveCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Amenity>();
            var amenity = await repo.GetByIdAsync(request.AmenityId);
            if (amenity is null)
                return Result.Fail(Error.Failure("Amenity.NotFound", $"Amenity with id {request.AmenityId} is not found"));
            var spec = RoomAmenityCriteriaSpecification.ByAmenityId(request.AmenityId);
            var roomTypeLinkedAmenity = await _unitOfWork.GetRepository<RoomAmenity>().GetAsync([spec]);
            if (roomTypeLinkedAmenity is not null && amenity.IsActive)
                return Result.Fail(Error.Failure("Amenity.HasRelatedRoomTypes", $"Amenity with id {request.AmenityId} cannot be deactivated because it has associated RoomTypes"));

            amenity.IsActive = !amenity.IsActive;

            int result = await _unitOfWork.SaveChangesAsync();
            if (result == 0)
                return Result.Fail(Error.Failure("Amenity.ToggleFailed", "Amenity can't be updated"));

            return Result.Ok();
        }
    }
}
