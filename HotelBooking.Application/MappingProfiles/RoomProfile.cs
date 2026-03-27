using AutoMapper;
using HotelBooking.Application.DTOs.RoomDTOs;
using HotelBooking.Application.Features.Rooms.Commands.Requests;
using HotelBooking.Domain.Entities.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.MappingProfiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDTO>();
            CreateMap<CreateRoomCommand, Room>();
        }
    }
}
