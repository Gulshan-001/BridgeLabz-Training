using TechVille_Phase2.Models;

namespace TechVille_Phase2.Services
{
    public static class ServiceFactory
    {
        public static Service CreateService(int choice)
        {
            return choice switch
            {
                1 => new HealthcareService(),
                2 => new EducationService(),
                3 => new PremiumHealthcareService(),
                _ => null
            };
        }
    }
}
