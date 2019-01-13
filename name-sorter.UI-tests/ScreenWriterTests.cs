using Moq;
using NameSorter.UI;
using System;
using System.Collections.Generic;
using Xunit;

namespace NameSorter.UI_tests
{
    public class ScreenWriterTests
    {
        [Fact]
        public void Test1()
        {
            var sr = new ScreenWriter();
            var sut = new Mock<IScreenWriter>();

            var listOfNames = new List<string>()
                {
                    "Dwight Schrute",
                    "Jim Halpert",
                    "Pam Beesly",
                    "Michael Scott"
                };

            sut.Setup(s => s.WriteListOfNamesToConsole(listOfNames)).Callback(() => sr.WriteListOfNamesToConsole(listOfNames));
            sut.Object.WriteListOfNamesToConsole(listOfNames);
            sut.Verify(s => s.WriteStringToConsole(It.IsAny<string>()), Times.AtLeastOnce);
        }
    }
}
