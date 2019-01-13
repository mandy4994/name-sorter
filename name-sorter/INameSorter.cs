using NameSorter.Data;
using System.Collections.Generic;

namespace NameSorter.App
{
    public interface INameSorter
    {
        IList<string> SortNames(IList<string> personList);
    }
}
