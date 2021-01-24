using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingChallenge.Domain;
using CodingChallenge.Domain.Interfaces;

namespace CodingChallenge.Application
{
    public class PassengerService : IPassengerService
    {
        private readonly IJayrideChallegeProxy _jayrideChallegeProxy;

        public PassengerService(IJayrideChallegeProxy jayrideChallegeProxy)
        {
            _jayrideChallegeProxy = jayrideChallegeProxy;
        }
        public async Task<IEnumerable<ListingDto>> GetQuote(int passengerNumber)
        {
            var quote =await _jayrideChallegeProxy.GetQuote();
            var filteredListing = quote.Listings.Where(r => r.VehicleType.MaxPassengers >= passengerNumber);

           var listingDtos=  filteredListing.OrderBy(r => r.PricePerPassenger).Select(p=> new ListingDto
            {
                Name = p.Name,
                TotalPrice = p.PricePerPassenger * passengerNumber,
                VehicleType = p.VehicleType
            }).ToList();
           return listingDtos;
        }
    }

    public class ListingDto
    {
        public string Name { get; set; }
        public decimal TotalPrice { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}