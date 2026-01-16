using System;

class BrowserMenu
{
    private IBrowser browser;

    public BrowserMenu()
    {
        Console.Write("Enter homepage: ");
        string home = Console.ReadLine();
        browser = new BrowserUtilityImpl(home);
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\n--- BrowserBuddy Menu ---");
            Console.WriteLine("1. Visit Page");
            Console.WriteLine("2. Back");
            Console.WriteLine("3. Forward");
            Console.WriteLine("4. Close Tab");
            Console.WriteLine("5. Restore Closed Tab");
            Console.WriteLine("6. Exit");
            Console.Write("Choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter URL: ");
                    browser.VisitPage(Console.ReadLine());
                    break;

                case 2:
                    browser.GoBack();
                    break;

                case 3:
                    browser.GoForward();
                    break;

                case 4:
                    browser.CloseTab();
                    break;

                case 5:
                    browser.RestoreTab();
                    break;

                case 6:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
