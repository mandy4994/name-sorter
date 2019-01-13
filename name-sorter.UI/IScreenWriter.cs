using System.Collections.Generic;
using NameSorter.Data;

namespace NameSorter.UI
{
    public interface IScreenWriter
    {
        void WriteListOfNamesToConsole(IList<string> names);
        void WriteStringToConsole(string stringParam);
        void ShowExitMessageOnConsole(string message);
    }
}
