using System;

// Node of Doubly Linked List
class TextState
{
    public string content;
    public TextState prev;
    public TextState next;

    public TextState(string text)
    {
        content = text;
        prev = null;
        next = null;
    }
}

// Editor class
class TextEditor
{
    private TextState head;
    private TextState current;
    private int size = 0;
    private int maxSize = 10; // limit history

    // Add new text state
    public void AddState(string text)
    {
        TextState newState = new TextState(text);

        // if first state
        if (head == null)
        {
            head = newState;
            current = newState;
            size++;
            return;
        }

        // remove redo states
        current.next = null;

        newState.prev = current;
        current.next = newState;
        current = newState;

        size++;

        // limit history size
        if (size > maxSize)
        {
            head = head.next;
            head.prev = null;
            size--;
        }
    }

    // Undo operation
    public void Undo()
    {
        if (current.prev != null)
        {
            current = current.prev;
            Console.WriteLine("Undo done");
        }
        else
        {
            Console.WriteLine("Nothing to undo");
        }
    }

    // Redo operation
    public void Redo()
    {
        if (current.next != null)
        {
            current = current.next;
            Console.WriteLine("Redo done");
        }
        else
        {
            Console.WriteLine("Nothing to redo");
        }
    }

    // Display current text
    public void Display()
    {
        Console.WriteLine("Current Text: " + current.content);
    }
}

// Main class
class Program
{
    static void Main()
    {
        TextEditor editor = new TextEditor();

        editor.AddState("Hello");
        editor.AddState("Hello World");
        editor.AddState("Hello World!");

        editor.Display();

        editor.Undo();
        editor.Display();

        editor.Undo();
        editor.Display();

        editor.Redo();
        editor.Display();

        editor.AddState("Hello World!!!");
        editor.Display();
    }
}