using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Data
{
    public interface IFileOperations
    {
        IList<string> ReadFile(string path);
        void WriteNamesToFile(string path, IList<string> list);
    }
}
