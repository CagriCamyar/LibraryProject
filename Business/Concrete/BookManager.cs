using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public IResult Add(Book book)
        {
            _bookDal.Add(book);
            return new SuccessResult("Book Added!");
        }

        public IResult Delete(Book book)
        {
            _bookDal.Delete(book);
            return new SuccessResult("Book Deleted!");
        }

        public IDataResult<Book> Get(int bookId)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(b => b.BookId == bookId), "Which Book You Choose : ");
        }

        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(), "All Books Listed!");
        }

        public IDataResult<List<BookDetailDto>> GetAllBookDetails()
        {
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetAllBookDetails());
        }

        public IDataResult<Book> GetByAuthorId(int authorId)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(a => a.AuthorId == authorId), "Your Choosed Author's Books : ");
        }

        public IResult Update(Book book)
        {
            _bookDal.Update(book);
            return new SuccessResult("Book Updated!");
        }
    }
}
