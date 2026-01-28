namespace CoreLogic;

public class DateFormatter
{
    public string FormatDate(string input)
    {
        if (!DateTime.TryParse(input, out var date))
            throw new FormatException();

        return date.ToString("dd-MM-yyyy");
    }
}
