using Library_Management.Models;
using Library_Management_Domain.Entities;

public interface _IBookService
{
    void AddAuthor(Author author);
    void AddBook(AddBookViewModel book);
    void AddBookCopy(AddBookCopyViewModel vm);
    void ArchiveAuthor(Guid id, bool archive);
    void ArchiveBook(Guid id, bool archive);
    void DeleteAuthor(Guid id);
    void DeleteBook(Guid id);
    IEnumerable<Author> GetAllAuthorsInternal();
    IEnumerable<BookListViewModel> GetArchivedBooks();
    EditBookViewModel GetBookById(Guid id);
    IEnumerable<BookCopyDetailsViewModel> GetBookCopies(Guid bookId);
    PulloutBookCopyViewModel? GetBookCopyForPullout(Guid bookCopyId);
    IEnumerable<BookListViewModel> GetBooks(bool includeArchived = false);
    void PulloutBookCopy(PulloutBookCopyViewModel vm);
    void UpdateAuthor(EditAuthorViewModel vm);
}

public class BookDBService : _IBookService
{
    public void AddBook(AddBookViewModel book)
    {
        throw new NotImplementedException();
    }


}