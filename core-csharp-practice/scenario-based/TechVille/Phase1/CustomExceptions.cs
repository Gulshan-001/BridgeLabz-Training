using System;

namespace TechVille_Phase1
{
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message) { }
    }

    public class DuplicateCitizenException : Exception
    {
        public DuplicateCitizenException(string message) : base(message) { }
    }
}
