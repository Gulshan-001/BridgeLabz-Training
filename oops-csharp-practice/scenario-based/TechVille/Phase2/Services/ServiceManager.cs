using System;
using TechVille_Phase2.Models;

namespace TechVille_Phase2.Services
{
    public class ServiceManager
    {
        public void ProcessService(Service service)
        {
            service.BookService();
            service.ShowStatus();
        }
    }
}
