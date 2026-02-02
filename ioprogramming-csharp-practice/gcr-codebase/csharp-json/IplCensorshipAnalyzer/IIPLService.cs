using System.Collections.Generic;

public interface IIPLService
{
    void ProcessJson(string input, string output);
    void ProcessCsv(string input, string output);
}
