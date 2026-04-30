using HotelBooking.Application.DTOs.StateDTOs;
using HotelBooking.Domain.Contracts.Specifications;
using HotelBooking.Domain.Entities.Geography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Specifications.StateSpecifications
{
    public class StateCriteriaSpecification : ICriteriaSpecification<State>
    {
        public Expression<Func<State, bool>> Criteria { get; set; }
        private StateCriteriaSpecification(Expression<Func<State, bool>> criteria)
        {
            Criteria = criteria;
        }
        public static StateCriteriaSpecification ByCountryId(int countryId) => new(s => s.CountryID == countryId);
        public static StateCriteriaSpecification ByNameAndCountryId(string name, int countryId) => new(s => s.StateName == name && s.CountryID == countryId);
        public static StateCriteriaSpecification ForQuery(StateQueryParams queryParams)
        {
            return new StateCriteriaSpecification(s =>
            (!queryParams.CountryId.HasValue || s.CountryID == queryParams.CountryId.Value) &&
            (!queryParams.IsActive.HasValue || s.IsActive == queryParams.IsActive.Value));
        }

    }
}
