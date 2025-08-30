using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class BookController : Controller
    {
        private readonly _IBookService _bookService;

        public BookController(_IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetBooks();
            return View(books);
        }

        public IActionResult AddModal()
        {
            return PartialView("_AddBookPartial");
        }

        [HttpPost]
        public IActionResult Add(AddBookViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("AddModal", vm);
            }

            _bookService.AddBook(vm);
            return RedirectToAction("Index");
        }

        public IActionResult EditModal(Guid id)
        {
            var editBookViewModel = _bookService.GetBookById(id);
            if (editBookViewModel == null)
                return NotFound();

            return PartialView("_EditBookPartial", editBookViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditBookViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bookService.UpdateBook(vm);
            return Ok();
        }

        public IActionResult DeleteModal(Guid id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
                return NotFound();

            return PartialView("_DeleteBookPartial", book);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
                return NotFound();

            _bookService.DeleteBook(id);
            return Ok();
        }

        public IActionResult Details(Guid id)
        {
            var book = _bookService.GetBooks(includeArchived: true).FirstOrDefault(b => b.BookId == id);
            if (book == null)
                return NotFound();

            ViewBag.BookCopies = _bookService.GetBookCopies(id);
            return View(book);
        }

        [HttpGet]
        public IActionResult AddCopy(Guid bookId)
        {
            var vm = new AddBookCopyViewModel
            {
                BookId = bookId
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddCopy(AddBookCopyViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            _bookService.AddBookCopy(vm);
            return RedirectToAction("Details", new { id = vm.BookId });
        }

        public IActionResult Archive()
        {
            var archivedBooks = _bookService.GetArchivedBooks();
            return View(archivedBooks);
        }

        [HttpPost]
        public IActionResult ArchiveBook(Guid id)
        {
            try
            {
                _bookService.ArchiveBook(id, true);
                return Json(new { success = true });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult RestoreBook(Guid id)
        {
            try
            {
                _bookService.ArchiveBook(id, false);
                return Json(new { success = true });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        public IActionResult PulloutModal(Guid bookCopyId)
        {
            var bookCopy = _bookService.GetBookCopyForPullout(bookCopyId);
            if (bookCopy == null)
                return NotFound();

            return PartialView("_PulloutBookCopyPartial", bookCopy);
        }

        [HttpPost]
        public IActionResult Pullout(PulloutBookCopyViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_PulloutBookCopyPartial", vm);
            }

            _bookService.PulloutBookCopy(vm);
            return Json(new { success = true });
        }
    }
}
