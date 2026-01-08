using System;

// Node class (each student)
class StudentNode
{
    public int RollNo;
    public string Name;
    public int Age;
    public string Grade;
    public StudentNode Next;

    public StudentNode(int roll, string name, int age, string grade)
    {
        RollNo = roll;
        Name = name;
        Age = age;
        Grade = grade;
        Next = null;
    }
}

// Linked List class
class StudentLinkedList
{
    private StudentNode head;

    // add at beginning
    public void AddAtBeginning(int roll, string name, int age, string grade)
    {
        StudentNode newNode = new StudentNode(roll, name, age, grade);
        newNode.Next = head;
        head = newNode;
    }

    // add at end
    public void AddAtEnd(int roll, string name, int age, string grade)
    {
        StudentNode newNode = new StudentNode(roll, name, age, grade);

        if (head == null)
        {
            head = newNode;
            return;
        }

        StudentNode temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = newNode;
    }

    // add at specific position (1-based index)
    public void AddAtPosition(int position, int roll, string name, int age, string grade)
    {
        if (position == 1)
        {
            AddAtBeginning(roll, name, age, grade);
            return;
        }

        StudentNode newNode = new StudentNode(roll, name, age, grade);
        StudentNode temp = head;

        for (int i = 1; i < position - 1 && temp != null; i++)
        {
            temp = temp.Next;
        }

        if (temp == null)
        {
            Console.WriteLine("Invalid position");
            return;
        }

        newNode.Next = temp.Next;
        temp.Next = newNode;
    }

    // delete by roll number
    public void DeleteByRollNo(int roll)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        if (head.RollNo == roll)
        {
            head = head.Next;
            Console.WriteLine("Student deleted");
            return;
        }

        StudentNode temp = head;
        while (temp.Next != null && temp.Next.RollNo != roll)
        {
            temp = temp.Next;
        }

        if (temp.Next == null)
        {
            Console.WriteLine("Student not found");
            return;
        }

        temp.Next = temp.Next.Next;
        Console.WriteLine("Student deleted");
    }

    // search by roll number
    public void Search(int roll)
    {
        StudentNode temp = head;

        while (temp != null)
        {
            if (temp.RollNo == roll)
            {
                Console.WriteLine("Student Found:");
                PrintStudent(temp);
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Student not found");
    }

    // update grade
    public void UpdateGrade(int roll, string newGrade)
    {
        StudentNode temp = head;

        while (temp != null)
        {
            if (temp.RollNo == roll)
            {
                temp.Grade = newGrade;
                Console.WriteLine("Grade updated");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Student not found");
    }

    // display all students
    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("No student records");
            return;
        }

        StudentNode temp = head;
        while (temp != null)
        {
            PrintStudent(temp);
            temp = temp.Next;
        }
    }

    // helper method
    private void PrintStudent(StudentNode s)
    {
        Console.WriteLine($"Roll: {s.RollNo}, Name: {s.Name}, Age: {s.Age}, Grade: {s.Grade}");
    }
}

// Main class
class Program
{
    static void Main()
    {
        StudentLinkedList list = new StudentLinkedList();

        list.AddAtBeginning(1, "Aman", 20, "A");
        list.AddAtEnd(2, "Riya", 21, "B");
        list.AddAtPosition(2, 3, "Karan", 22, "C");

        Console.WriteLine("\nAll Students:");
        list.DisplayAll();

        Console.WriteLine("\nSearch Roll No 2:");
        list.Search(2);

        Console.WriteLine("\nUpdate Grade of Roll No 3:");
        list.UpdateGrade(3, "A+");

        Console.WriteLine("\nAfter Update:");
        list.DisplayAll();

        Console.WriteLine("\nDelete Roll No 1:");
        list.DeleteByRollNo(1);

        Console.WriteLine("\nFinal List:");
        list.DisplayAll();
    }
}
