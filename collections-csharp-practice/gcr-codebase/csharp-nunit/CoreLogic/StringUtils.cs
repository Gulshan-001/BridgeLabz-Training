namespace CoreLogic;

public class StringUtils
{
    public string Reverse(string str) =>
        new string(str.Reverse().ToArray());

    public bool IsPalindrome(string str) =>
        str == Reverse(str);

    public string ToUpperCase(string str) =>
        str.ToUpper();
}
