using AutoMapper;
using HotelBooking.Application.DTOs.StateDTOs;
using HotelBooking.Application.Features.States.Commands.Requests;
using HotelBooking.Domain.Entities.Geography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.MappingProfiles
{
    public class StateProfile  : Profile
    {
        public StateProfile()
        {
            CreateMap<State, StateDTO>();
            CreateMap<CreateStateCommand, State>();

            CreateMap<UpdateStateCommand, State>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(_ => DateTime.Now));
        }
    }
}
