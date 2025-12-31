using System;

class InvoiceGenerator
{
    public static string[] ParseInvoice(string input)
    {
        // Break the full invoice string wherever a comma appears
        // so each task becomes a separate string
        return input.Split(',');
    }

    public static int GetTotalAmount(string[] tasks)
    {
        int total = 0;

        foreach (string task in tasks)
        {
            // Remove extra spaces so indexing works correctly
            string cleanTask = task.Trim();

            // Find where '-' and 'INR' are located in the string
            int dashIndex = cleanTask.LastIndexOf('-');
            int inrIndex = cleanTask.IndexOf("INR");

            // Only proceed if both symbols actually exist
            if (dashIndex != -1 && inrIndex != -1)
            {
                // Extract only the number part between '-' and 'INR'
                string amountPart =
                    cleanTask.Substring(dashIndex + 1, inrIndex - dashIndex - 1).Trim();

                // Convert the extracted number to int and add to total
                total += int.Parse(amountPart);
            }
        }
        return total;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string input = "Logo Design - 3000 INR, Web Page - 4500 INR";

        // First split the input into individual task strings
        string[] tasks = InvoiceGenerator.ParseInvoice(input);

        Console.WriteLine("Invoice Details:");
        foreach (string task in tasks)
        {
            Console.WriteLine(task.Trim());
        }

        // Pass the tasks to calculate the total invoice amount
        int totalAmount = InvoiceGenerator.GetTotalAmount(tasks);

        Console.WriteLine("\nTotal Invoice Amount: " + totalAmount + " INR");
    }
}
