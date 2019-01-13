using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NameSorter.Common;
using NameSorter.Data;
using NameSorter.UI;
using System;

namespace NameSorter.App
{
    public class NameSorterApplication: INameSorterApplication
    {
        private readonly ILogger<NameSorterApplication> _logger;
        private readonly IFileOperations _fileOperations;
        private readonly INameSorter _nameSorter;
        private readonly IScreenWriter _screenWriter;
        private readonly IConfiguration _config;
        private readonly IValidator _validator;

        public NameSorterApplication(
            ILogger<NameSorterApplication> logger,
            IFileOperations fileOperations,
            INameSorter nameSorter,
            IScreenWriter screenWriter,
            IConfiguration config,
            IValidator validator)
        {
            _logger = logger;
            _fileOperations = fileOperations;
            _nameSorter = nameSorter;
            _screenWriter = screenWriter;
            _config = config;
            _validator = validator;
        }
        public void Run(string[] args)
        {
            // Exit App if incorrect params are provided
            if (!_validator.ValidateArgs(args)) return;

            // Read File and get list of names
            var listOfNames =_fileOperations.ReadFile(args[0]);

            // Validate Names
            _validator.ValidateNames(listOfNames);

            // Sort Names
            var sortedNames = _nameSorter.SortNames(listOfNames);

            // Write to screen
            _screenWriter.WriteListOfNamesToConsole(sortedNames);

            // Write to file
            var writeToFilePath = _config["OutputFilePath"];
            _fileOperations.WriteNamesToFile(writeToFilePath, sortedNames);

            _screenWriter.WriteStringToConsole(Content.WriteToFileComplete(writeToFilePath));

            _screenWriter.ShowExitMessageOnConsole(Content.ExitMessage);
        }
    }
}
