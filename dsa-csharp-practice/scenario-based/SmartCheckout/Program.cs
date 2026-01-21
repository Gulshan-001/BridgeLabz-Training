class Program
{
    static void Main()
    {
        ICheckoutSystem utility = new CheckoutUtility();
        Menu menu = new Menu(utility);

        menu.Show();
    }
}
