using System;

// Node (Process)
class Process
{
    public int pid;
    public int burstTime;
    public int remainingTime;
    public int waitingTime;
    public int turnAroundTime;
    public Process next;
    
    public Process(int id, int bt)
    {
        pid = id;
        burstTime = bt;
        remainingTime = bt;
        waitingTime = 0;
        turnAroundTime = 0;
        next = null;
    }
}

// Circular Linked List Scheduler
class RoundRobinScheduler
{
    private Process head = null;
    private int timeQuantum;

    public RoundRobinScheduler(int tq)
    {
        timeQuantum = tq;
    }

    // Add process at end
    public void AddProcess(int id, int burst)
    {
        Process newProcess = new Process(id, burst);

        if (head == null)
        {
            head = newProcess;
            head.next = head;
            return;
        }

        Process temp = head;
        while (temp.next != head)
            temp = temp.next;

        temp.next = newProcess;
        newProcess.next = head;
    }

    // Remove process by PID
    private void RemoveProcess(Process prev, Process curr)
    {
        if (curr == head && curr.next == head)
        {
            head = null;
            return;
        }

        if (curr == head)
            head = head.next;

        prev.next = curr.next;
    }

    // Display processes
    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("No processes left");
            return;
        }

        Process temp = head;
        do
        {
            Console.Write($"P{temp.pid}({temp.remainingTime}) -> ");
            temp = temp.next;
        } while (temp != head);

        Console.WriteLine();
    }

    // Simulate Round Robin
    public void Execute()
    {
        int time = 0;
        int completed = 0;
        int totalWaiting = 0;
        int totalTurnAround = 0;

        Process curr = head;
        Process prev = null;

        while (head != null)
        {
            Console.WriteLine("\nCurrent Queue:");
            Display();

            if (curr.remainingTime > timeQuantum)
            {
                curr.remainingTime -= timeQuantum;
                time += timeQuantum;
            }
            else
            {
                time += curr.remainingTime;
                curr.remainingTime = 0;

                curr.turnAroundTime = time;
                curr.waitingTime = curr.turnAroundTime - curr.burstTime;

                totalWaiting += curr.waitingTime;
                totalTurnAround += curr.turnAroundTime;
                completed++;

                RemoveProcess(prev, curr);
            }

            prev = curr;
            curr = curr.next;
        }

        Console.WriteLine("\nAll processes completed");
        Console.WriteLine("Average Waiting Time: " + (totalWaiting / completed));
        Console.WriteLine("Average Turn Around Time: " + (totalTurnAround / completed));
    }
}

// Main
class Program
{
    static void Main()
    {
        RoundRobinScheduler rr = new RoundRobinScheduler(2); // Time Quantum = 2

        rr.AddProcess(1, 5);
        rr.AddProcess(2, 3);
        rr.AddProcess(3, 7);

        rr.Execute();
    }
}