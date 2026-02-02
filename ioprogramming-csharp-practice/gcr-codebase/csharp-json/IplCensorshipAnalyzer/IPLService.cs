using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class IPLService : IIPLService
{
    private string Mask(string team)
    {
        var parts = team.Split(' ');
        parts[parts.Length - 1] = "***";
        return string.Join(" ", parts);
    }

    public void ProcessJson(string input, string output)
    {
        var matches = JsonConvert.DeserializeObject<List<IplMatch>>(File.ReadAllText(input));

        foreach (var m in matches)
        {
            string t1 = Mask(m.team1);
            string t2 = Mask(m.team2);

            m.team1 = t1;
            m.team2 = t2;
            m.winner = Mask(m.winner);
            m.player_of_match = "REDACTED";

            var newScore = new Dictionary<string, int>();
            foreach (var s in m.score)
                newScore[Mask(s.Key)] = s.Value;

            m.score = newScore;
        }

        File.WriteAllText(output, JsonConvert.SerializeObject(matches, Formatting.Indented));
    }

    public void ProcessCsv(string input, string output)
    {
        var lines = File.ReadAllLines(input);
        using var writer = new StreamWriter(output);
        writer.WriteLine(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            var d = lines[i].Split(',');
            d[1] = Mask(d[1]);
            d[2] = Mask(d[2]);
            d[5] = Mask(d[5]);
            d[6] = "REDACTED";
            writer.WriteLine(string.Join(",", d));
        }
    }
}
