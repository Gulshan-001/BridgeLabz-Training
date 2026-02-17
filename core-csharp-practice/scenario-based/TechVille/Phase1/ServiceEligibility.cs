using System;

namespace TechVille_Phase1
{
    public static class ServiceEligibility
    {
        public static string DeterminePackage(int age, double income, int residencyYears)
        {
            // MODULE 1 – Basic eligibility score
            int score = 0;

            if (age >= 18) score += 10;
            if (income >= 50000) score += 20;
            if (residencyYears >= 5) score += 30;

            // MODULE 2 – Multi-level package decision
            if (score >= 50)
                return "Platinum";
            else if (score >= 40)
                return "Gold";
            else if (score >= 20)
                return "Silver";
            else
                return "Basic";
        }
    }
}
