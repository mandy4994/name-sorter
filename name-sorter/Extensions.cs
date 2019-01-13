namespace NameSorter.App
{
    public static class Extensions
    {
        public static string GetGivenNames(this string fullName)
        {
            return fullName.Substring(0, fullName.LastIndexOf(' '));
        }

        public static string GetLastName(this string fullName)
        {
            return fullName.Substring(fullName.LastIndexOf(' ') + 1);
        }
    }
}
