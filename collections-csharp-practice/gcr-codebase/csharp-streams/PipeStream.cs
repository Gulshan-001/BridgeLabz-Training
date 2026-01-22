using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;

class Program
{
    static void Main()
    {
        // Create pipe server (writer side)
        using (AnonymousPipeServerStream pipeServer =
               new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable))
        {
            // Create pipe client (reader side)
            using (AnonymousPipeClientStream pipeClient =
                   new AnonymousPipeClientStream(PipeDirection.In, pipeServer.ClientSafePipeHandle))
            {
                Thread writerThread = new Thread(() => WriteData(pipeServer));
                Thread readerThread = new Thread(() => ReadData(pipeClient));

                writerThread.Start();
                readerThread.Start();

                writerThread.Join();
                readerThread.Join();
            }
        }
    }

    // ================= WRITER THREAD =================
    static void WriteData(AnonymousPipeServerStream pipe)
    {
        using (StreamWriter writer = new StreamWriter(pipe, Encoding.UTF8))
        {
            writer.AutoFlush = true;

            string[] messages =
            {
                "Hello from Writer Thread",
                "This data is sent through a pipe",
                "Inter-thread communication",
                "END"
            };

            foreach (string msg in messages)
            {
                writer.WriteLine(msg);
                Thread.Sleep(500); // simulate delay
            }
        }
    }

    // ================= READER THREAD =================
    static void ReadData(AnonymousPipeClientStream pipe)
    {
        using (StreamReader reader = new StreamReader(pipe, Encoding.UTF8))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line == "END")
                    break;

                Console.WriteLine("Reader received: " + line);
            }
        }
    }
}
