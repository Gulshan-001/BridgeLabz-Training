using System;

class Program
{
    static void Main()
    {
        // Fixed size is decided once so the database doesn’t grow randomly
        AccountDatabase accountStore = new AccountDatabase(10);

        // UI is given access to the database so it can perform actions on it
        UI appUI = new UI(accountStore);

        // Control is handed over to the UI to start interacting with the user
        appUI.Start();
    }
}
