using System;
using System.Text.RegularExpressions;

public class Utility
{
    public static bool validateTransportId(string transportId)
    {
        return Regex.IsMatch(transportId, "^RTS[0-9]{3}[A-Z]$");
    }

    public static GoodsTransport parseDetails(string input)
    {
        string[] d = input.Split(':');

        string transportId = d[0];
        if (!validateTransportId(transportId))
        {
            Console.WriteLine($"Transport id {transportId} is invalid");
            Console.WriteLine("Please provide a valid record");
            return null;
        }

        string transportDate = d[1];
        int rating = int.Parse(d[2]);
        string type = d[3];

        if (type.Equals("BrickTransport", StringComparison.OrdinalIgnoreCase))
        {
            return new BrickTransport(
                transportId, transportDate, rating,
                float.Parse(d[4]),
                int.Parse(d[5]),
                float.Parse(d[6])
            );
        }

        return new TimberTransport(
            transportId, transportDate, rating,
            float.Parse(d[4]),
            float.Parse(d[5]),
            d[6],
            float.Parse(d[7])
        );
    }

    public static string findObjectType(GoodsTransport g)
    {
        return g is TimberTransport ? "TimberTransport" : "BrickTransport";
    }
}
