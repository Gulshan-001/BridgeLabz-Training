using System;
using System.Reflection;

// Step 1: Create Inject attribute
[AttributeUsage(AttributeTargets.Field)]
class InjectAttribute : Attribute
{
}

// Step 2: Dependency service
class MessageService
{
    public void Send()
    {
        Console.WriteLine("Message sent.");
    }
}

// Step 3: Consumer class
class Notification
{
    [Inject]
    private MessageService _messageService;

    public void Notify()
    {
        _messageService.Send();
    }
}

// Step 4: Simple DI Container
class SimpleDIContainer
{
    public static T Resolve<T>() where T : new()
    {
        T instance = new T();
        InjectDependencies(instance);
        return instance;
    }

    private static void InjectDependencies(object obj)
    {
        Type type = obj.GetType();

        FieldInfo[] fields = type.GetFields(
            BindingFlags.NonPublic |
            BindingFlags.Public |
            BindingFlags.Instance
        );

        foreach (FieldInfo field in fields)
        {
            if (Attribute.IsDefined(field, typeof(InjectAttribute)))
            {
                // Create dependency instance
                object dependency = Activator.CreateInstance(field.FieldType);

                // Inject dependency
                field.SetValue(obj, dependency);
            }
        }
    }
}

// Step 5: Demo
class Program
{
    static void Main()
    {
        Notification notification =
            SimpleDIContainer.Resolve<Notification>();

        notification.Notify();
    }
}
