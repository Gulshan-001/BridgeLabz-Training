// ATM Cash Handler
// Goal: Give cash using minimum number of notes

using System;

class ATMDispenser
{
    static void DispenseAmount(int amount, int[] notes)
    {
        int remainingAmount = amount;
        bool dispensedSomething = false;

        foreach (int note in notes)
        {
            // check how many notes of this type we can use
            int used = remainingAmount / note;

            if (used > 0)
            {
                Console.WriteLine(note + " x " + used);
                remainingAmount -= note * used;
                dispensedSomething = true;
            }
        }

        // if some amount is still left, ATM can't give exact cash
        if (remainingAmount > 0)
        {
            Console.WriteLine("Unable to dispense exact amount.");
            Console.WriteLine("Remaining balance: ₹" + remainingAmount);
            Console.WriteLine("Please try a different amount.\n");
        }
        else if (dispensedSomething)
        {
            Console.WriteLine("\nTransaction completed successfully.\n");
        }
    }

    static void Main()
    {
        int[] allNotes = { 500, 200, 100, 50, 20, 10, 5, 2, 1 };
        int[] noFiveHundred = { 200, 100, 50, 20, 10, 5, 2, 1 };
        int[] limitedNotes = { 10, 5 };

        Console.WriteLine("Case 1: ₹880 with full denominations");
        DispenseAmount(880, allNotes);

        Console.WriteLine("Case 2: ₹880 without ₹500 note");
        DispenseAmount(880, noFiveHundred);

        Console.WriteLine("Case 3: Exact cash not possible");
        DispenseAmount(2, limitedNotes);
    }
}