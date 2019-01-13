using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NameSorter.Common;
using NameSorter.Data;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace NameSorter.Data_testss
{
    public class FileOperationsTests
    {
        private readonly Mock<ILogger<FileOperations>> mockLogger;

        public FileOperationsTests()
        {
            mockLogger = new Mock<ILogger<FileOperations>>();
        }
        [Fact]
        public void ReadFile_WhenFileIsRead_ListOfNamesIsReturned()
        {
            // Arrange
            var sut = new FileOperations(mockLogger.Object);

            // Act
            var result = sut.ReadFile("..\\..\\..\\test-unsorted-names-list.txt");

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Count.Should().Be(11);
        }

        [Fact]
        public void ReadFile_WhenFileNotFound_ThrowsException()
        {
            // Arrange
            var sut = new FileOperations(mockLogger.Object);

            // Act and Assert
            Assert.Throws<FileNotFoundException>(() => sut.ReadFile("invalidFile.txt"));
        }

        [Fact]
        public void WriteNamesToFile_WhenFinished_VerifyFileExistsWithCorrectNames()
        {
            var path = "..\\..\\..\\writeNamesToFileTestFile.txt";
            try
            {
                // Arrange
                var sut = new FileOperations(mockLogger.Object);
                
                var listOfNames = new List<string>()
                {
                    "Dwight Schrute",
                    "Jim Halpert",
                    "Pam Beesly",
                    "Michael Scott"
                };

                // Act
                sut.WriteNamesToFile(path, listOfNames);

                File.Exists(path).Should().BeTrue();
                var resultList = File.ReadAllLines(path);
                resultList.Should().BeEquivalentTo(listOfNames, opt => opt.WithStrictOrdering());
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }           
        }
    }
}
