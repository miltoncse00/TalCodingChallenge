using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CodingChallenge.Application;
using CodingChallenge.Data;
using CodingChallenge.Domain;
using NSubstitute;
using FluentAssertions;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace CodingChallenge.UnitTests
{
    public class DeathPremiumServiceTests
    {
        private IDeathPremiumRepository _proxy;
        public DeathPremiumServiceTests()
        {
            _proxy = Substitute.For<IDeathPremiumRepository>();
        }

        [Fact]
        public void GivenServiceGetOccupationsReturnValidResult()
        {
            _proxy.GetOccupation().Returns(returnThis: new List<string>{"Cleaner","Doctor"});
            var service = new DeathPremiumService(_proxy);
            var occupations = service.GetOccupations();
            occupations.Count().Should().Be(2);
            occupations.First().Should().Be("Cleaner");
            occupations.Last().Should().Be("Doctor");
        }

        [Fact]
        public void GivenServiceCalcMonthlyDeathPremiumReturnValidResult()
        {
            var insuredInput = new InsuredInput {Age = 30, DeathSumInsured = 10000, DateOfBirth = DateTime.Now.Date.AddYears(-30), Name = "Nick", Occupation ="Doctor" };
            _proxy.GetFactor(insuredInput.Occupation).Returns(0.1M);
            var service = new DeathPremiumService(_proxy);
            var expectedValue =Math.Round(insuredInput.DeathSumInsured * 0.1M * insuredInput.Age / (1000 * 12),2);
            var actualValue = service.CalculateMonthlyDeathPremium(insuredInput);
            actualValue.MonthlyDeathPremium.Should().Be(expectedValue);
        }

        [Fact]
        public void ValidateAgeInputModelWithAnnotation()
        {
            var validationResult = ValidateModel(InvalidInputwithAgeGreaterThan150());
            validationResult.Count.Should().Be(1);
            validationResult.First().ErrorMessage.Should().ContainAny("Age");

        }

        [Fact]
        public void ValidateDeathSumInsuredInputModelWithAnnotation()
        {
            var validationResult = ValidateModel(InvalidInputwithInsuredSumEqualThan10B());
            validationResult.Count.Should().Be(1);
            validationResult.First().ErrorMessage.Should().ContainAny("Death-Sum Insured");

        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new System.ComponentModel.DataAnnotations.ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

        private InsuredInput InvalidInputwithAgeGreaterThan150()
        {
            var insuredInput = new InsuredInput
            {
                Name = "Nick",
                Age = 1234,
                DeathSumInsured = 12344,
                Occupation = "Doctor",
                DateOfBirth = DateTime.Now.Date.AddYears(-30)
            };
            return insuredInput;
        }

        private InsuredInput InvalidInputwithInsuredSumEqualThan10B()
        {
            var insuredInput = new InsuredInput
            {
                Name = "Nick",
                Age = 30,
                DeathSumInsured = 10000000000,
                Occupation = "Doctor",
                DateOfBirth = DateTime.Now.Date.AddYears(-30)
            };
            return insuredInput;
        }
    }
}
