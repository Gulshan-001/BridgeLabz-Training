using System;
using TechVille_Phase2.Interfaces;

namespace TechVille_Phase2.Models
{
    public class EducationService : Service, IBookable
    {
        public EducationService() : base("Education Service") { }

        public override void BookService()
        {
            Console.WriteLine("Education service registered.");
        }
    }
}
