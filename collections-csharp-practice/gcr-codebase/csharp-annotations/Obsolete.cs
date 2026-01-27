using System;

class LegacyAPI
{
    [Obsolete("OldFeature is deprecated. Use NewFeature instead.")]
    public void OldFeature()
    {
        Console.WriteLine("Executing old feature");
    }

    public void NewFeature()
    {
        Console.WriteLine("Executing new feature");
    }
}

class Program
{
    static void Main()
    {
        LegacyAPI api = new LegacyAPI();

        api.OldFeature();   // Compiler warning
        api.NewFeature();   // Recommended
    }
}
