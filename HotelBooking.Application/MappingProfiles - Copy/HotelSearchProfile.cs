
using AutoMapper;
using HotelBooking.Application.DTOs.HotelSearchDTOs;
using HotelBooking.Domain.Entities.Rooms;

namespace HotelBooking.Application.MappingProfiles
{
    public class HotelSearchProfile : Profile
    {
        public HotelSearchProfile()
        {
            CreateMap<RoomType, RoomTypeSearchDTO>();

            // 2. Map the main Room entity
            CreateMap<Room, RoomSearchDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType));

            // 3. Keep your amenity mapping
            CreateMap<RoomAmenity, AmenitySearchDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Amenity.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Amenity.Description));


        }
    }
}
