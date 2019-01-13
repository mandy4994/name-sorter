using System.Collections.Generic;

namespace NameSorter.App
{
    public interface IValidator
    {
        /// <summary>
        /// Validates the arguments passed in the application
        /// </summary>
        /// <param name="args">A string array of arguments passed in the app to validate</param>
        /// <returns>true if valid, false otherwise</returns>
        bool ValidateArgs(string[] args);

        /// <summary>
        /// Validates if the names inside the list are correct
        /// </summary>
        /// <param name="listOfNames">list Of Names</param>
        /// <returns></returns>
        bool ValidateNames(IList<string> listOfNames);
    }
}
