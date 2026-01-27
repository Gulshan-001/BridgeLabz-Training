using System;
using System.Reflection;

// Step 1: Define interface
public interface IGreeting
{
    void SayHello(string name);
}

// Step 2: Real implementation
public class Greeting : IGreeting
{
    public void SayHello(string name)
    {
        Console.WriteLine("Hello, " + name);
    }
}

// Step 3: Logging proxy
public class LoggingProxy<T> : DispatchProxy
{
    private T _target;

    public void SetTarget(T target)
    {
        _target = target;
    }

    protected override object Invoke(MethodInfo targetMethod, object[] args)
    {
        // Log method name
        Console.WriteLine("Calling method: " + targetMethod.Name);

        // Invoke actual method
        return targetMethod.Invoke(_target, args);
    }
}

// Step 4: Demo
class Program
{
    static void Main()
    {
        IGreeting greeting = new Greeting();

        // Create proxy dynamically
        IGreeting proxy = DispatchProxy.Create<IGreeting, LoggingProxy<IGreeting>>();

        ((LoggingProxy<IGreeting>)proxy).SetTarget(greeting);

        // Method call intercepted
        proxy.SayHello("Alice");
    }
}
