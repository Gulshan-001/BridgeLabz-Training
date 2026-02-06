using System;
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool isAvailable { get; set; }
    

    public Book(string title, string author,bool isAvailable)
    {
        Title = title;
        Author = author;
        isAvailable=True;
    }
}