using System;

public class UserInterface
{
    public static void Start()
    {
        IIPLService service = new IPLService();

        service.ProcessJson("ipl_input.json", "ipl_output.json");
        service.ProcessCsv("ipl_input.csv", "ipl_output.csv");

        Console.WriteLine("Censorship completed.");
    }
}
