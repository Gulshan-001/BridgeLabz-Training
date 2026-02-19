using System;

namespace TechVille_Phase2.Models
{
    public abstract class Service
    {
        public static int TotalServices = 0;

        public string ServiceName { get; protected set; }

        protected Service(string serviceName)
        {
            ServiceName = serviceName;
            TotalServices++;
        }

        public abstract void BookService();

        public virtual void ShowStatus()
        {
            Console.WriteLine($"{ServiceName} is active.");
        }

        public override string ToString()
        {
            return $"Service: {ServiceName}";
        }
    }
}
