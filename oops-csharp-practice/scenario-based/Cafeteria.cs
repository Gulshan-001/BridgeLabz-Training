using System;

class Cafeteria
{
    private string[] cafeteriaItems;

    
    // Overloaded constructor to allow custom menu
    public Cafeteria(string[] customMenu)
    {
        this.cafeteriaItems = customMenu;
    }

    // Method to display menu
    public void DisplayMenu()
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine("       SCHOOL CAFETERIA MENU       ");
        Console.WriteLine("----------------------------------");
        for (int i=1;i<+10;i++)
        {
            Console.Write(i+" ");
            Console.WriteLine(cafeteriaItems[i]);
        }
        Console.WriteLine("----------------------------------");
    }
    
    public void GetItemByIndex(int j)
    {
        Console.WriteLine("Item Selected :-"+ cafeteriaItems[j]);
    }
}

    class Program{

    static void Main()
    {
        string[] cafeteriaItems2 = new string[] {
            "Cheese Sandwich",
            "Veggie Wrap",
            "Chicken Nuggets",
            "Fruit Salad",
            "Chocolate Milk",
            "Apple Juice",
            "French Fries",
            "Yogurt Cup",
            "Pizza Slice",
            "Granola Bar"
        };
        // Create a Cafeteria object using default menu
        Cafeteria schoolCafeteria = new Cafeteria(cafeteriaItems2);
        schoolCafeteria.DisplayMenu();

        Console.WriteLine("Enter your Order Index--");
        int ord=int.Parse(Console.ReadLine());
        schoolCafeteria.GetItemByIndex(ord);
        
    }
}
