using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    { 
        IDataResult<List<Book>> GetAll();
        IDataResult<Book> Get(int bookId);
        IDataResult<Book> GetByAuthorId(int authorId);
        IResult Add(Book book);
        IResult Delete(Book book);
        IResult Update(Book book);
        IDataResult<List<BookDetailDto>> GetAllBookDetails();
    }
}
