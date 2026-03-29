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
    public class CreateAmenitiesCommandHandler : IRequestHandler<CreateAmenitiesWithUserCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateAmenitiesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(CreateAmenitiesWithUserCommand request, CancellationToken cancellationToken)
        {
            var amenities = _mapper.Map<List<Amenity>>(request.Command.Amenities);
            foreach (var amenity in amenities)
            {
                amenity.CreatedBy = request.userEmail;
                amenity.CreatedDate = DateTime.UtcNow;
            }
            await _unitOfWork.GetRepository<Amenity>().AddRangeAsync(amenities);
            int result = await _unitOfWork.SaveChangesAsync();
            if (result == 0)
                return Error.Failure("Amenity.Failure", "Amenities can't be created");
            return result;
        }
    }
}
