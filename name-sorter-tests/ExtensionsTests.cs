using FluentAssertions;
using NameSorter.App;
using Xunit;

namespace NameSorter.App_tests
{
    public class ExtensionsTests
    {
        [Fact]
        public void GetGivenNames_WhenCalled_ReturnsCorrectGivenName()
        {
            string fullName = "Gabe Adams Morris Lewis";
            fullName.GetGivenNames().Should().Be("Gabe Adams Morris");
        }

        [Fact]
        public void GetLastName_WhenCalled_ReturnsCorrectLastName()
        {
            string fullName = "Gabe Adams Morris Lewis";
            fullName.GetLastName().Should().Be("Lewis");
        }
    }
}
