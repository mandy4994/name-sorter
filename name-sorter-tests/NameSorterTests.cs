using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace NameSorter.App_tests
{
    public class NameSorterTests
    {
        [Fact]
        public void SortNames_WhenCalled_SortNamesByLastNameAndThenByGivenName()
        {
            var unsortedList = new List<string>
            {
                "Jim Morris",
                "Michael Morris",
                "Ashton Clarke",
                "Adam Clarke"               
            };

            var expectedList = new List<string>
            {
                "Adam Clarke",
                "Ashton Clarke",
                "Jim Morris",
                "Michael Morris"
            };
            var sut = new App.NameSorter();
            var resultList = sut.SortNames(unsortedList);
            resultList.Should().BeEquivalentTo(expectedList, options => options.WithStrictOrdering());
        }

    }
}
