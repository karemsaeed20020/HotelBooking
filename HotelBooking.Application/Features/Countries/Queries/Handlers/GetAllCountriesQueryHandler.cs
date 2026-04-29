using AutoMapper;
using HotelBooking.Application.DTOs.CountryDTOs;
using HotelBooking.Application.Features.Countries.Queries.Requests;
using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Specifications.CountrySpecifications;
using HotelBooking.Domain.Entities.Geography;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.Countries.Queries.Handlers
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllCountriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CountryDTO>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var spec = CountryCriteriaSpecification.ByStatus(request.IsActive);
            var countries = await _unitOfWork.GetRepository<Country>().GetAllAsync([spec]);
            var countryDtos = _mapper.Map<List<CountryDTO>>(countries);

            return countryDtos;
        }
    }
}
