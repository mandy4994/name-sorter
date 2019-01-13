using System.Diagnostics.CodeAnalysis;

namespace NameSorter.Common
{
    // Excluding because content can be changed later
    [ExcludeFromCodeCoverage]
    public class Content
    {
        public static string WriteToFileComplete(string path)
        {
            return $"\nWrite to file complete at { path }";
        }

        public static string NameNotValid(string name)
        {
            return $"Name \"{ name }\" not valid in the list";
        }

        public const string ExitMessage = "\nPress any key to exit...";
    }
}
