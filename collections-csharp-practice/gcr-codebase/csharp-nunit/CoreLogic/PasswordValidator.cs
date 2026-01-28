namespace CoreLogic;

public class PasswordValidator
{
    public bool IsValid(string password)
    {
        return password.Length >= 8 &&
               password.Any(char.IsUpper) &&
               password.Any(char.IsDigit);
    }
}
