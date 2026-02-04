public class WordValidator
{
    public static bool IsValidWord(string word)
    {
        return !word.Contains(" ");
    }
}
