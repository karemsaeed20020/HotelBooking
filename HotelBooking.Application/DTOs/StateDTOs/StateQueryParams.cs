using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.DTOs.StateDTOs
{
    public class StateQueryParams
    {
        public int? CountryId { get; set; }
        public bool? IsActive { get; set; }
    }
}
