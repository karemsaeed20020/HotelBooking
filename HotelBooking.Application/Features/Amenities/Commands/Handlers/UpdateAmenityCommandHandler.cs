using AutoMapper;
using HotelBooking.Application.Features.Amenities.Commands.Requests;
using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Results;
using HotelBooking.Domain.Entities.Rooms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.Amenities.Commands.Handlers
{
    public class UpdateAmenityCommandHandler : IRequestHandler<UpdateAmenityWithUserCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateAmenityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result> Handle(UpdateAmenityWithUserCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Amenity>();
            var amenity = await repo.GetByIdAsync(request.Command.AmenityId);
            if (amenity is null)
                return Result.Fail(Error.NotFound("Amenity.NotFound", $"Amenity with id {request.Command.AmenityId} not found"));
            _mapper.Map(request.Command, amenity);
            amenity.ModifiedBy = request.userEmail;
            repo.Update(amenity);
            int result = await _unitOfWork.SaveChangesAsync();
            if (result == 0)
                return Result.Fail(Error.Failure("Amenity.Failure", $"Amenity can't be updated"));

            return Result.Ok();
        }
    }
}
