using System;

namespace TechVille_Phase1
{
    public static class ProfileUtils
    {
        public static string FormatName(string name)
        {
            return name.Trim().ToUpper();
        }

        public static bool ValidateName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }
    }
}
