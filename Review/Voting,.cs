using System;

class Voting
{
    static void Main(string[] args)
    {
        int cand = 0;
        int votesDone = 0;
        int[] votesp = null;
        string[] candarr = null;
        int flag = 0;

        Console.WriteLine("ENTER YOUR ROLE");
        Console.WriteLine("1:- ADMIN, 2:- VOTER");
        int ch = int.Parse(Console.ReadLine());

        if (ch == 1)
        {
            // ADMIN
            Console.WriteLine("---------- ADMIN ----------");
            Console.WriteLine("Enter Number of Candidates:");
            cand = int.Parse(Console.ReadLine());
            votesp = new int[cand];
            candarr = new string[cand];
            for (int i = 0; i < cand; i++)
            {
                Console.WriteLine("Enter Name of Candidate " + (i + 1));
                candarr[i] = Console.ReadLine();
            }

            flag = 1;
            Console.WriteLine("Switching to VOTER mode...");
        }

        if (ch == 2 || flag == 1)
        {
            if (flag == 0)
            {
                Console.WriteLine("Admin setup not done. Cannot vote.");
                return;
            }

            // VOTER (Max 10 votes)
            while (votesDone < 10)
            {
                Console.WriteLine("\nEnter Birth Year (or 0 to stop voting):");
                int dob = int.Parse(Console.ReadLine());

                if (dob == 0)
                    break;

                if ((2026 - dob) >= 18)
                {
                    Console.WriteLine("Choose Your Candidate:");
                    for (int i = 0; i < cand; i++)
                    {
                        Console.WriteLine((i + 1) + " - " + candarr[i]);
                    }

                    int vote = int.Parse(Console.ReadLine());

                    if (vote >= 1 && vote <= cand)
                    {
                        votesp[vote - 1]++;
                        votesDone++;
                        Console.WriteLine("Vote Cast Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Vote");
                    }
                }
                else
                {
                    Console.WriteLine("Not Eligible to Vote");
                }
            }
        }

        // RESULT
        Console.WriteLine("----- RESULT -----");
        int maxVotes = 0;
        int winnerIndex = 0;

        for (int i = 0; i < cand; i++)
        {
            if (votesp[i] > maxVotes)
            {
                maxVotes = votesp[i];
                winnerIndex = i;
            }
        }

        Console.WriteLine("THE Winner is: " + candarr[winnerIndex]);
        Console.WriteLine("Total Votes: " + maxVotes);
    }
}

//passenger interface/abs
//two passenger classes implementing--> senior passenger, normal passenger
//passenger details user input (number , name, age)
//sort passengers based on age (number) and store in array and display by searching by pr number using binary search
// calculate fare based on type of passenger (senior citizen discount)...