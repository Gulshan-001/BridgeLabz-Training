using System;

class SnakeAndLadder
{
    static Random random = new Random();

    // Roll dice between 1 and 6
    static int RollDice()
    {
        return random.Next(1, 7);
    }

    // Move player based on dice
    static int MovePlayer(int position, int dice)
    {
        int newPosition = position + dice;

        // If position goes beyond 100, stay at same place
        return newPosition > 100 ? position : newPosition;
    }

    // Apply snake or ladder using arrays
    static int ApplySnakeOrLadder(int position, int[] start, int[] end)
    {
        for (int i = 0; i < start.Length; i++)
        {
            if (position == start[i])
                return end[i];
        }

        return position;
    }

    // Check win condition
    static bool CheckWin(int position)
    {
        return position == 100;
    }

    static void Main()
    {
        // Snakes and ladders using arrays
        int[] start = { 4, 9, 17, 20, 28, 54, 62, 64, 87, 93, 95, 99 };
        int[] end   = {14,31,  7, 38, 84, 34, 19, 60, 24, 73, 75, 78 };

        Console.Write("Enter number of players (2-4): ");
        int playerCount = int.Parse(Console.ReadLine());

        if (playerCount < 2 || playerCount > 4)
        {
            Console.WriteLine("Invalid number of players.");
            return;
        }

        string[] players = new string[playerCount];
        int[] positions = new int[playerCount];

        // Player names input
        for (int i = 0; i < playerCount; i++)
        {
            Console.Write($"Enter name of Player {i + 1}: ");
            players[i] = Console.ReadLine();
            positions[i] = 0;
        }

        bool gameOver = false;

        Console.WriteLine("\nGame Started!");

        // Game loop
        while (!gameOver)
        {
            for (int i = 0; i < playerCount; i++)
            {
                Console.WriteLine($"\n{players[i]}'s turn. Press Enter to roll dice.");
                Console.ReadLine();

                int dice = RollDice();
                int oldPosition = positions[i];

                int newPosition = MovePlayer(oldPosition, dice);
                newPosition = ApplySnakeOrLadder(newPosition, start, end);

                positions[i] = newPosition;

                // Display turn details
                Console.WriteLine("Player: " + players[i]);
                Console.WriteLine("Dice: " + dice);
                Console.WriteLine("Position: " + oldPosition + " -> " + newPosition);

                // Check win
                if (CheckWin(newPosition))
                {
                    Console.WriteLine("\n" + players[i] + " wins the game!");
                    gameOver = true;
                    break;
                }
            }
        }
    }
}
