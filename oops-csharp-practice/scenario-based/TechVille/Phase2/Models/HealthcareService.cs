using System;
using TechVille_Phase2.Interfaces;

namespace TechVille_Phase2.Models
{
    public class HealthcareService : Service, IBookable, ITrackable
    {
        public HealthcareService() : base("Healthcare Service") { }

        public override void BookService()
        {
            Console.WriteLine("Healthcare appointment booked.");
        }

        public void TrackService()
        {
            Console.WriteLine("Tracking healthcare service status...");
        }
    }
}
