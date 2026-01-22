class Program
{
    static void Main()
    {
        IHospitalRoute route = new CircularRoute();
        Menu menu = new Menu(route);

        // Predefined hospital layout
        route.AddUnit("Emergency");
        route.AddUnit("Radiology");
        route.AddUnit("Surgery");
        route.AddUnit("ICU");

        menu.Show();
    }
}
