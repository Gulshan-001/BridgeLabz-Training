using System;

namespace TechVille_Phase2.Models
{
    public class PremiumHealthcareService : HealthcareService
    {
        public PremiumHealthcareService() : base()
        {
            ServiceName = "Premium Healthcare Service";
        }

        public override void BookService()
        {
            base.BookService();
            Console.WriteLine("Premium features activated.");
        }
    }
}
