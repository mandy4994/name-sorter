using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NameSorter.UI
{
    public class ScreenWriter: IScreenWriter
    {
        [ExcludeFromCodeCoverage]
        public void ShowExitMessageOnConsole(string message)
        {
            WriteStringToConsole(message);
            Console.ReadKey();
        }

        [ExcludeFromCodeCoverage]
        public void WriteListOfNamesToConsole(IList<string> names)
        {
            foreach (var name in names)
            {
                WriteStringToConsole(name);
            }
        }

        [ExcludeFromCodeCoverage]
        public void WriteStringToConsole(string stringParam)
        {
            Console.WriteLine(stringParam);
        }
    }
}
