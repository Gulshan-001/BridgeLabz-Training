using System;

namespace TechVille_Phase1
{
    public class RegistrationManager
    {
        private Citizen[] citizens = new Citizen[100];
        private int count = 0;

        public void RegisterCitizen()
        {
            try
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                if (!ProfileUtils.ValidateName(name))
                    throw new Exception("Invalid Name!");

                name = ProfileUtils.FormatName(name);

                Console.Write("Enter Age: ");
                int age = int.Parse(Console.ReadLine());

                if (age < 18)
                    throw new InvalidAgeException("Citizen must be 18+");

                Console.Write("Enter Income: ");
                double income = double.Parse(Console.ReadLine());

                Console.Write("Enter Residency Years: ");
                int residency = int.Parse(Console.ReadLine());

                Citizen citizen = new Citizen(name, age, income, residency);

                citizen.ServicePackage =
                    ServiceEligibility.DeterminePackage(age, income, residency);

                citizens[count++] = citizen;

                FileManager.SaveCitizen(citizen);

                Console.WriteLine("Citizen Registered Successfully!");
                citizen.Display();
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine("Age Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
        }
    }
}
