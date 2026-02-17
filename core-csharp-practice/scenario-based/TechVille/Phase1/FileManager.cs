using System;
using System.IO;

namespace TechVille_Phase1
{
    public static class FileManager
    {
        private static string filePath = "citizens.txt";

        public static void SaveCitizen(Citizen citizen)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine($"{citizen.Name},{citizen.Age},{citizen.Income},{citizen.ResidencyYears},{citizen.ServicePackage}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("File error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Save operation completed.");
            }
        }
    }
}
