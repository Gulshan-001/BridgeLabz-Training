using System;

// Node class
class TaskNode
{
    public int TaskId;
    public string TaskName;
    public int Priority;
    public string DueDate;   // kept simple as string

    public TaskNode Next;

    public TaskNode(int id, string name, int priority, string dueDate)
    {
        TaskId = id;
        TaskName = name;
        Priority = priority;
        DueDate = dueDate;
        Next = null;
    }
}

// Circular Linked List class
class TaskScheduler
{
    private TaskNode head;

    // add at beginning
    public void AddAtBeginning(int id, string name, int priority, string dueDate)
    {
        TaskNode newNode = new TaskNode(id, name, priority, dueDate);

        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
            return;
        }

        TaskNode temp = head;
        while (temp.Next != head)
            temp = temp.Next;

        newNode.Next = head;
        temp.Next = newNode;
        head = newNode;
    }

    // add at end
    public void AddAtEnd(int id, string name, int priority, string dueDate)
    {
        TaskNode newNode = new TaskNode(id, name, priority, dueDate);

        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
            return;
        }

        TaskNode temp = head;
        while (temp.Next != head)
            temp = temp.Next;

        temp.Next = newNode;
        newNode.Next = head;
    }

    // add at position (1-based)
    public void AddAtPosition(int position, int id, string name, int priority, string dueDate)
    {
        if (position == 1)
        {
            AddAtBeginning(id, name, priority, dueDate);
            return;
        }

        TaskNode temp = head;
        for (int i = 1; i < position - 1 && temp.Next != head; i++)
            temp = temp.Next;

        TaskNode newNode = new TaskNode(id, name, priority, dueDate);
        newNode.Next = temp.Next;
        temp.Next = newNode;
    }

    // remove by task id
    public void RemoveByTaskId(int id)
    {
        if (head == null)
        {
            Console.WriteLine("No tasks");
            return;
        }

        TaskNode curr = head;
        TaskNode prev = null;

        do
        {
            if (curr.TaskId == id)
            {
                if (prev != null)
                    prev.Next = curr.Next;
                else
                {
                    TaskNode temp = head;
                    while (temp.Next != head)
                        temp = temp.Next;

                    head = curr.Next;
                    temp.Next = head;
                }

                Console.WriteLine("Task removed");
                return;
            }

            prev = curr;
            curr = curr.Next;

        } while (curr != head);

        Console.WriteLine("Task not found");
    }

    // view current task and move to next
    public void ViewCurrentAndNext()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks");
            return;
        }

        PrintTask(head);
        head = head.Next; // move to next task
    }

    // display all tasks
    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks");
            return;
        }

        TaskNode temp = head;
        do
        {
            PrintTask(temp);
            temp = temp.Next;
        } while (temp != head);
    }

    // search by priority
    public void SearchByPriority(int priority)
    {
        if (head == null)
        {
            Console.WriteLine("No tasks");
            return;
        }

        TaskNode temp = head;
        bool found = false;

        do
        {
            if (temp.Priority == priority)
            {
                PrintTask(temp);
                found = true;
            }
            temp = temp.Next;
        } while (temp != head);

        if (!found)
            Console.WriteLine("No tasks with this priority");
    }

    // helper
    private void PrintTask(TaskNode t)
    {
        Console.WriteLine($"ID: {t.TaskId}, Name: {t.TaskName}, Priority: {t.Priority}, Due: {t.DueDate}");
    }
}

// Main class
class Program
{
    static void Main()
    {
        TaskScheduler scheduler = new TaskScheduler();

        scheduler.AddAtEnd(1, "Write Report", 1, "10 Aug");
        scheduler.AddAtEnd(2, "Team Meeting", 2, "11 Aug");
        scheduler.AddAtBeginning(3, "Fix Bugs", 1, "09 Aug");

        Console.WriteLine("\nAll Tasks:");
        scheduler.DisplayAll();

        Console.WriteLine("\nCurrent Task:");
        scheduler.ViewCurrentAndNext();

        Console.WriteLine("\nNext Task:");
        scheduler.ViewCurrentAndNext();

        Console.WriteLine("\nSearch Priority 1:");
        scheduler.SearchByPriority(1);

        Console.WriteLine("\nRemove Task ID 2:");
        scheduler.RemoveByTaskId(2);

        Console.WriteLine("\nFinal Task List:");
        scheduler.DisplayAll();
    }
}