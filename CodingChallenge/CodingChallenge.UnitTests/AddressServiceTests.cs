using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CodingChallenge.Application;
using CodingChallenge.Domain;
using CodingChallenge.Domain.Interfaces;
using NSubstitute;
using FluentAssertions;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace CodingChallenge.UnitTests
{
    public class AddressServiceTests
    {
        private IIPStakeProxy _proxy;
        public AddressServiceTests()
        {
            _proxy = Substitute.For<IIPStakeProxy>();
        }

        [Fact]
        public async Task GivenInvalidIPCheckException()
        {
            _proxy.GetAddress(Arg.Any<string>()).Returns(Task.FromResult(new Address()));
            var ip = string.Empty;
            var service = new AddressService(_proxy);
            Func<Task> act = async () => await service.GetAddress(ip);
            act.Should().Throw<ValidationException>();
        }

        [Fact]
        public async Task GivenValidIPCheckReturnAddess()
        {
            _proxy.GetAddress(Arg.Any<string>()).Returns(Task.FromResult(new Address() { City = "Parramatta" }));
            var ip = "149.167.62.77";
            var service = new AddressService(_proxy);
            var address = await service.GetAddress(ip);
            address.City.Should().Be("Parramatta");
        }
    }
}
