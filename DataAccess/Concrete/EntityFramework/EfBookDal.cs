using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfRepositoryBase<Book, LibraryProjectDbContext>, IBookDal
    {
        public List<BookDetailDto> GetAllBookDetails()
        {
            using (LibraryProjectDbContext context = new LibraryProjectDbContext())
            {
                var result = from b in context.Books
                             join a in context.Authors
                             on b.AuthorId equals a.AuthorId
                             select new BookDetailDto
                             {
                                 BookId = b.BookId,
                                 AuthorName = a.AuthorName,
                                 BookName = b.BookName,
                                 BookGenre = b.BookGenre,
                                 DailyPrice = b.DailyPrice,
                                 Description = b.Description,
                             };
                return result.ToList();
            }
        } 
    }
}
