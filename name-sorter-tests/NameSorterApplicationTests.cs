using System;
using Xunit;
using NameSorter.App;
using Microsoft.Extensions.Logging;
using Moq;
using NameSorter.Data;
using NameSorter.UI;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using NameSorter.Common;

namespace NameSorter.App_tests
{
    public class NameSorterApplicationTests
    {
        private readonly Mock<ILogger<NameSorterApplication>> loggerMock;
        private readonly Mock<IFileOperations> fileOperationsMock;
        private readonly Mock<INameSorter> nameSorterMock;
        private readonly Mock<IScreenWriter> screenWriterMock;
        private readonly Mock<IConfiguration> configMock;
        private readonly Mock<IValidator> validatorMock;
        private readonly NameSorterApplication sut;

        public NameSorterApplicationTests()
        {
            loggerMock = new Mock<ILogger<NameSorterApplication>>();
            fileOperationsMock = new Mock<IFileOperations>();
            nameSorterMock = new Mock<INameSorter>();
            screenWriterMock = new Mock<IScreenWriter>();
            configMock = new Mock<IConfiguration>();
            validatorMock = new Mock<IValidator>();
            sut = new NameSorterApplication(
                                                loggerMock.Object,
                                                fileOperationsMock.Object,
                                                nameSorterMock.Object,
                                                screenWriterMock.Object,
                                                configMock.Object,
                                                validatorMock.Object);
        }
        [Fact]
        public void Run_WhenArgsInvalid_FileIsNotRead()
        {
            validatorMock.Setup(v => v.ValidateArgs(It.IsAny<string[]>())).Returns(false);

            sut.Run(new string[0]);

            //Assert
            fileOperationsMock.Verify(f => f.ReadFile(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void Run_WhenArgsAreValid_ReadFileIsCalled()
        {
            // Arrange
            var args = new string[] { "fakeFile.txt" };
            validatorMock.Setup(v => v.ValidateArgs(It.IsAny<string[]>())).Returns(true);

            // Act
            sut.Run(args);

            // Assert
            fileOperationsMock.Verify(f => f.ReadFile(args[0]), Times.Once);
        }

        [Fact]
        public void Run_WhenFileIsRead_ThenNamesAreValidatedAndSorted()
        {
            // Arrange
            var args = new string[] { "fakeFile.txt" };
            validatorMock.Setup(v => v.ValidateArgs(It.IsAny<string[]>())).Returns(true);
            var fakeNameList = GetFakeNameList();
            fileOperationsMock.Setup(f => f.ReadFile(It.IsAny<string>())).Returns(fakeNameList);

            // Act
            sut.Run(args);

            // Assert
            validatorMock.Verify(v => v.ValidateNames(fakeNameList), Times.Once);
            nameSorterMock.Verify(n => n.SortNames(fakeNameList), Times.Once);
        }

        [Fact]
        public void Run_WhenNameAreSorted_NamesWrittenToConsoleAndFile()
        {
            // Arrange
            var args = new string[] { "fakeFile.txt" };
            validatorMock.Setup(v => v.ValidateArgs(It.IsAny<string[]>())).Returns(true);
            var fakeNameList = GetFakeNameList();
            nameSorterMock.Setup(n => n.SortNames(It.IsAny<IList<string>>())).Returns(fakeNameList);

            // Act
            sut.Run(args);

            // Arrange
            screenWriterMock.Verify(s => s.WriteListOfNamesToConsole(fakeNameList));
            fileOperationsMock.Verify(f => f.WriteNamesToFile(It.IsAny<string>(), fakeNameList));
            screenWriterMock
                .Verify(s => s.WriteStringToConsole(Content.WriteToFileComplete(It.IsAny<string>())));
            screenWriterMock.Verify(s => s.ShowExitMessageOnConsole(Content.ExitMessage));
        }

        IList<string> GetFakeNameList()
        {
            return new List<string>()
            {
                "Dwight Schrute",
                "Jim Halpert",
                "Pam Beesly",
                "Michael Scott"
            };
        }
    }
}
