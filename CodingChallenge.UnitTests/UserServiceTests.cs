using System;
using CodingChallenge.Application;
using CodingChallenge.Domain;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Xunit;

namespace CodingChallenge.UnitTests
{
    public class UserServiceTests
    {
        [Fact]
        public void GivenOptionWithValueCallGetUserShouldReturnSameValue()
        {
            var phone = "04XXXXXX29";
            var name = "SYED BASHAR";
            var option = Options.Create<UserSetting>(new UserSetting {Phone = phone, Name = name});

            var userService = new UserService(option);

            var user = userService.GetUser();

            user.Phone.Should().Be(phone);
            user.Name.Should().Be(name);
        }

        [Fact]
        public void GivenEmptyNameValueCallGetUserShouldReturnException()
        {
            var phone = "04XXXXXX29";
            var name = "";
            var option = Options.Create<UserSetting>(new UserSetting { Phone = phone, Name = name });

            var userService = new UserService(option);

            Action act = () => userService.GetUser();
            act.Should().Throw<Exception>().WithMessage("User setting is not correct.");
        }
    }
}
