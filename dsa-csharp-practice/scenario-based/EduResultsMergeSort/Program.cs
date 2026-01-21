class Program
{
    static void Main()
    {
        IRankSystem utility = new RankUtility(20);
        Menu menu = new Menu(utility);

        menu.Show();
    }
}
