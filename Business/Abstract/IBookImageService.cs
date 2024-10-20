using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookImageService
    {
        IDataResult<List<BookImage>> GetAll();
        IDataResult<BookImage> Get(int bookImageId);
        IResult Add(IFormFile formFile, BookImage bookImage);
        IResult Delete(BookImage bookImage);
        IResult Update(IFormFile formFile, BookImage bookImage);
    }
}
