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
    public void AddAuthor(Author author)
    {
        throw new NotImplementedException();
    }

    public void AddBook(AddBookViewModel book)
    {
        throw new NotImplementedException();
    }

    public void AddBookCopy(AddBookCopyViewModel vm)
    {
        throw new NotImplementedException();
    }

    public void ArchiveAuthor(Guid id, bool archive)
    {
        throw new NotImplementedException();
    }

    public void ArchiveBook(Guid id, bool archive)
    {
        throw new NotImplementedException();
    }

    public void DeleteAuthor(Guid id)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Author> GetAllAuthorsInternal()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BookListViewModel> GetArchivedBooks()
    {
        throw new NotImplementedException();
    }

    public EditBookViewModel GetBookById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BookCopyDetailsViewModel> GetBookCopies(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public PulloutBookCopyViewModel? GetBookCopyForPullout(Guid bookCopyId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BookListViewModel> GetBooks(bool includeArchived = false)
    {
        throw new NotImplementedException();
    }

    public void PulloutBookCopy(PulloutBookCopyViewModel vm)
    {
        throw new NotImplementedException();
    }

    public void UpdateAuthor(EditAuthorViewModel vm)
    {
        throw new NotImplementedException();
    }
}