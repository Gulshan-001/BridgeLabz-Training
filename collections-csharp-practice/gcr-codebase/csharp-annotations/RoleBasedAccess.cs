using System;
using System.Reflection;

// Step 1: Define RoleAllowed attribute
[AttributeUsage(AttributeTargets.Method)]
class RoleAllowedAttribute : Attribute
{
    public string Role { get; }

    public RoleAllowedAttribute(string role)
    {
        Role = role;
    }
}

// Step 2: Simulate user context
class UserContext
{
    public static string CurrentRole { get; set; }
}

// Step 3: Secured service
class AdminService
{
    [RoleAllowed("ADMIN")]
    public void DeleteUser()
    {
        Console.WriteLine("User deleted successfully.");
    }

    public void ViewUsers()
    {
        Console.WriteLine("Viewing users.");
    }
}

// Step 4: Access validator
class AccessController
{
    public static void Invoke(object obj, string methodName)
    {
        Type type = obj.GetType();
        MethodInfo method = type.GetMethod(methodName);

        RoleAllowedAttribute attribute =
            method.GetCustomAttribute<RoleAllowedAttribute>();

        if (attribute != null)
        {
            if (UserContext.CurrentRole != attribute.Role)
            {
                Console.WriteLine("Access Denied!");
                return;
            }
        }

        method.Invoke(obj, null);
    }
}

// Step 5: Demo
class Program
{
    static void Main()
    {
        AdminService service = new AdminService();

        // Simulate NON-ADMIN user
        UserContext.CurrentRole = "USER";
        AccessController.Invoke(service, "DeleteUser");

        // Simulate ADMIN user
        UserContext.CurrentRole = "ADMIN";
        AccessController.Invoke(service, "DeleteUser");

        // Public method (no restriction)
        AccessController.Invoke(service, "ViewUsers");
    }
}
