using Microsoft.Extensions.Logging;
using NameSorter.Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace NameSorter.Data
{
    public class FileOperations : IFileOperations
    {
        private readonly ILogger<FileOperations> _logger;

        public FileOperations(ILogger<FileOperations> logger)
        {
            _logger = logger;
        }
        public IList<string> ReadFile(string path)
        {
            List<string> list = null;

            try
            {
                list = new List<string>(File.ReadAllLines(path));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, LogEventConstants.Error);
                throw;
            }
            return list;
        }

        public void WriteNamesToFile(string path, IList<string> names)
        {
            try
            {
                using (StreamWriter outputfile = new StreamWriter(path))
                {
                    foreach (var name in names)
                    {
                        outputfile.WriteLine(name);
                    }
                    outputfile.Close();
                }                                      
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, LogEventConstants.Error);
                throw;
            }                           
        }
    }
}
