using System;
class Book
{
    public int BookID{ get; private set; }
    public string Title{ get; private set; }
    public string Author{ get; private set; }
    public string Genre{ get; private set; }

    public Book(int bookid,string title,string author, string genre)
    {
        BookID=bookid;
        Title=title;
        Author=author;
        Genre=genre;
    }
}