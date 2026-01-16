interface IBookShelfOperations
{
    void AddBookToGenre(Book book);
    void BorrowBook(string genre, int bookId);
    void ReturnBook(Book book);
    void DisplayBooksByGenre(string genre);
    void DisplayEntireCatalog();
}
