using System;
namespace LibraryManagement
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.ShowMenu();
    }
}

//railway reservations system 
//interface three methods-- add passenger , sortpassenger by pnr number(bubble), and search passenger(binary search), calculate fare
//two type of passenger--normal and senior
//store passenger three details (pnr no., name and age) in array and sort this array when sortPassengers() is called