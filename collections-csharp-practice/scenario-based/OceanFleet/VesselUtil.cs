using System.Collections.Generic;

public class VesselUtil : IVesselUtil
{
    private List<Vessel> vesselList = new List<Vessel>();

    public void AddVesselPerformance(Vessel vessel)
    {
        vesselList.Add(vessel);
    }

    public Vessel GetVesselById(string vesselId)
    {
        foreach (Vessel v in vesselList)
        {
            if (v.VesselId == vesselId) // case-sensitive
            {
                return v;
            }
        }
        return null;
    }

    public List<Vessel> GetHighPerformanceVessels()
    {
        List<Vessel> result = new List<Vessel>();

        double maxSpeed = 0;

        foreach (Vessel v in vesselList)
        {
            if (v.AverageSpeed > maxSpeed)
            {
                maxSpeed = v.AverageSpeed;
            }
        }

        foreach (Vessel v in vesselList)
        {
            if (v.AverageSpeed == maxSpeed)
            {
                result.Add(v);
            }
        }

        return result;
    }
}
