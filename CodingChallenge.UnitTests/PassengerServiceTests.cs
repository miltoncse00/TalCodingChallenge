using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CodingChallenge.Application;
using CodingChallenge.Domain;
using CodingChallenge.Domain.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Options;
using NSubstitute;
using Xunit;

namespace CodingChallenge.UnitTests
{
    public class PassengerServiceTests
    {
        private IJayrideChallegeProxy _proxy;
        public PassengerServiceTests()
        {
            _proxy = Substitute.For<IJayrideChallegeProxy>();
        }

        [Fact]
        public async Task GivenQuoteofOneVechicleShouldReturnValueBasedOnLowerPrice()
        {
            _proxy.GetQuote().Returns(Task.FromResult(GetSingleQoute()));
            var passengerService = new PassengerService(_proxy);

            var result = await passengerService.GetQuote(2);
            result.Count().Should().Be(1);
            result.First().TotalPrice.Should().Be(4);
        }

        [Fact]
        public async Task GivenQuoteofOneVechicleExceedPassengerShouldReturn0()
        {
            _proxy.GetQuote().Returns(Task.FromResult(GetSingleQoute()));
            var passengerService = new PassengerService(_proxy);

            var result = await passengerService.GetQuote(4);
            result.Count().Should().Be(0);
        }

        [Fact]
        public async Task GivenQuoteofOneVechicleExceedPassengerShouldReturnInProperOrder()
        {
            _proxy.GetQuote().Returns(Task.FromResult(GetTwoQoute()));
            var passengerService = new PassengerService(_proxy);

            var result = await passengerService.GetQuote(2);
            result.Count().Should().Be(2);
            result.First().Name.Should().Be("L2");
            result.First().TotalPrice.Should().Be(3);
            result.Last().Name.Should().Be("L1");
            result.Last().TotalPrice.Should().Be(4);
        }

        private Quote GetSingleQoute()
        {
            return new Quote()
            {
                From = "A",
                To = "B",
                Listings = new List<Listing>()
                {
                    new Listing()
                    {
                        Name = "L1",
                        PricePerPassenger = 2,
                        VehicleType = new VehicleType
                        {
                            MaxPassengers = 3,
                            Name = "V1"
                        }
                    }
                }
            };
        }

        private Quote GetTwoQoute()
        {
            return new Quote()
            {
                From = "A",
                To = "B",
                Listings = new List<Listing>()
                {
                    new Listing()
                    {
                        Name = "L1",
                        PricePerPassenger = 2,
                        VehicleType = new VehicleType
                        {
                            MaxPassengers = 2,
                            Name = "V1"
                        }
                    },
                    new Listing()
                    {
                        Name = "L2",
                        PricePerPassenger = 1.5M,
                        VehicleType = new VehicleType
                        {
                            MaxPassengers = 3,
                            Name = "V1"
                        }
                    }
                }
            };
        }
    }
}
