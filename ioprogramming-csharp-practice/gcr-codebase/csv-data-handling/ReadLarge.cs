using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string filePath = "largefile.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("CSV file not found.");
            return;
        }

        int batchSize = 100;
        int totalRecordsProcessed = 0;

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            bool isHeader = true;

            List<string> buffer = new List<string>(batchSize);

            while ((line = reader.ReadLine()) != null)
            {
                // Skip header row
                if (isHeader)
                {
                    isHeader = false;
                    continue;
                }

                buffer.Add(line);

                if (buffer.Count == batchSize)
                {
                    ProcessBatch(buffer, ref totalRecordsProcessed);
                    buffer.Clear();
                }
            }

            // Process remaining lines (if any)
            if (buffer.Count > 0)
            {
                ProcessBatch(buffer, ref totalRecordsProcessed);
            }
        }

        Console.WriteLine("Total records processed: " + totalRecordsProcessed);
    }

    static void ProcessBatch(List<string> batch, ref int totalCount)
    {
        foreach (string record in batch)
        {
            // Process each CSV row here (parsing / validation etc.)
            totalCount++;
        }

        Console.WriteLine("Processed records so far: " + totalCount);
    }
}
