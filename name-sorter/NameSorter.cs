using NameSorter.Data;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.App
{
    public class NameSorter : INameSorter
    {
        public IList<string> SortNames(IList<string> namesList)
        {
            namesList = namesList
                        .OrderBy(n => n.GetLastName())
                        .ThenBy(n => n.GetGivenNames()).ToList();
            return namesList;
        }
    }
}
