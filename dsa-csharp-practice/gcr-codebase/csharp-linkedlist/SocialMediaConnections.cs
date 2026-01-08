using System;

// Node representing a User
class User
{
    public int userId;
    public string name;
    public int age;

    // Store friend IDs in an array
    public int[] friends = new int[10];
    public int friendCount = 0;

    public User next;

    public User(int id, string n, int a)
    {
        userId = id;
        name = n;
        age = a;
        next = null;
    }
}

// Singly Linked List
class SocialMedia
{
    private User head = null;

    // Add user at end
    public void AddUser(int id, string name, int age)
    {
        User newUser = new User(id, name, age);

        if (head == null)
        {
            head = newUser;
            return;
        }

        User temp = head;
        while (temp.next != null)
            temp = temp.next;

        temp.next = newUser;
    }

    // Find user by ID
    private User FindUser(int id)
    {
        User temp = head;
        while (temp != null)
        {
            if (temp.userId == id)
                return temp;
            temp = temp.next;
        }
        return null;
    }

    // Add friend connection (both sides)
    public void AddFriend(int id1, int id2)
    {
        User u1 = FindUser(id1);
        User u2 = FindUser(id2);

        if (u1 == null || u2 == null)
        {
            Console.WriteLine("User not found");
            return;
        }

        u1.friends[u1.friendCount++] = id2;
        u2.friends[u2.friendCount++] = id1;

        Console.WriteLine("Friend connection added");
    }

    // Remove friend connection
    public void RemoveFriend(int id1, int id2)
    {
        User u1 = FindUser(id1);
        User u2 = FindUser(id2);

        if (u1 == null || u2 == null) return;

        RemoveFromArray(u1, id2);
        RemoveFromArray(u2, id1);

        Console.WriteLine("Friend connection removed");
    }

    // Helper to remove friend ID from array
    private void RemoveFromArray(User user, int id)
    {
        for (int i = 0; i < user.friendCount; i++)
        {
            if (user.friends[i] == id)
            {
                for (int j = i; j < user.friendCount - 1; j++)
                    user.friends[j] = user.friends[j + 1];

                user.friendCount--;
                break;
            }
        }
    }

    // Display friends of a user
    public void DisplayFriends(int id)
    {
        User user = FindUser(id);
        if (user == null) return;

        Console.Write("Friends of " + user.name + ": ");
        for (int i = 0; i < user.friendCount; i++)
            Console.Write(user.friends[i] + " ");

        Console.WriteLine();
    }

    // Find mutual friends
    public void MutualFriends(int id1, int id2)
    {
        User u1 = FindUser(id1);
        User u2 = FindUser(id2);

        if (u1 == null || u2 == null) return;

        Console.Write("Mutual Friends: ");
        for (int i = 0; i < u1.friendCount; i++)
        {
            for (int j = 0; j < u2.friendCount; j++)
            {
                if (u1.friends[i] == u2.friends[j])
                    Console.Write(u1.friends[i] + " ");
            }
        }
        Console.WriteLine();
    }

    // Search user by ID or Name
    public void Search(string key)
    {
        User temp = head;
        while (temp != null)
        {
            if (temp.userId.ToString() == key || temp.name == key)
            {
                Console.WriteLine($"Found: {temp.name}, Age: {temp.age}");
                return;
            }
            temp = temp.next;
        }
        Console.WriteLine("User not found");
    }

    // Count friends of each user
    public void CountFriends()
    {
        User temp = head;
        while (temp != null)
        {
            Console.WriteLine($"{temp.name} has {temp.friendCount} friends");
            temp = temp.next;
        }
    }
}

// Main Program
class Program
{
    static void Main()
    {
        SocialMedia sm = new SocialMedia();

        sm.AddUser(1, "Aman", 21);
        sm.AddUser(2, "Riya", 20);
        sm.AddUser(3, "Kunal", 22);

        sm.AddFriend(1, 2);
        sm.AddFriend(1, 3);

        sm.DisplayFriends(1);
        sm.MutualFriends(2, 3);

        sm.Search("Riya");
        sm.CountFriends();

        sm.RemoveFriend(1, 2);
        sm.DisplayFriends(1);
    }
}
