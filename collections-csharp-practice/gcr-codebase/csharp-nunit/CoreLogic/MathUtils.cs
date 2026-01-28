namespace CoreLogic;

public class MathUtils
{
    public int Divide(int a, int b)
    {
        if (b == 0) throw new ArithmeticException();
        return a / b;
    }
}
