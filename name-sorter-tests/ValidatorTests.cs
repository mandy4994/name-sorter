using Microsoft.Extensions.Logging;
using Moq;
using NameSorter.App;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace NameSorter.App_tests
{
    public class ValidatorTests
    {
        private readonly Mock<ILogger<Validator>> loggerMock;
        private readonly Validator sut;

        public ValidatorTests()
        {
            loggerMock = new Mock<ILogger<Validator>>();
            sut = new Validator(loggerMock.Object);
        }

        [Fact]
        public void ValidateArgs_WhenArgsAreInvalid_ReturnsFalse()
        {
            var invalidArgs = new string[] { "abc", "asd" };
            sut.ValidateArgs(invalidArgs).Should().Be(false);
        }

        [Fact]
        public void ValidateArgs_WhenArgsAreValid_ReturnsTrue()
        {
            var invalidArgs = new string[] { "abc" };
            sut.ValidateArgs(invalidArgs).Should().Be(true);
        }

        [Fact]
        public void ValidateNames_WhenNameContainsOnlyLastName_ReturnsFalse()
        {
            var invalidNameList = new List<string>()
            {
                "Dwight Schrute",
                "Jim Halpert",
                "Pam Beesly",
                "Michael Scott",
                "Clarke" // InvalidName
            };
            sut.ValidateNames(invalidNameList).Should().Be(false);
        }

        [Fact]
        public void ValidateNames_WhenNameContainsMoreThanThreeGivenNames_ReturnsFalse()
        {
            var invalidNameList = new List<string>()
            {
                "Dwight Schrute",
                "Jim Michael Adam Chris Halpert",
                "Pam Beesly",
                "Michael Scott",
                "Stanley Hudson" // InvalidName
            };
            sut.ValidateNames(invalidNameList).Should().Be(false);
        }

        [Fact]
        public void ValidateNames_WhenNamesAreValid_ReturnsTrue()
        {
            var validNameList = new List<string>()
            {
                "Dwight Schrute",
                "Jim Halpert",
                "Pam Beesly",
                "Michael Scott",
                "Stanley James Hudson" // InvalidName
            };
            sut.ValidateNames(validNameList).Should().Be(true);
        }
    }
}
