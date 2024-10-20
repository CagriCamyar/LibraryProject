    using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{  
    public class BookImageManager : IBookImageService
    {
        IBookImageDal _bookImageDal;
        IFileHelper _fileHelper;
        public BookImageManager(IBookImageDal bookImageDal, IFileHelper fileHelper)
        {
            _bookImageDal = bookImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile formFile, BookImage bookImage)
        {
            var result = BusinessRules.Run(CheckIfBookImageLimit(bookImage.BookId));
            if (result != null)
            {
                return result;
            }
            bookImage.ImagePath = _fileHelper.Upload(formFile, PathConstants.ImagesPath);
            bookImage.Date = DateTime.Now;
            _bookImageDal.Add(bookImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(BookImage bookImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + bookImage.ImagePath);
            _bookImageDal.Delete(bookImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<BookImage> Get(int bookImageId)
        {         
            return new SuccessDataResult<BookImage>(_bookImageDal.Get(bi=> bi.BookImageId == bookImageId), "Book Image Your Choosed!");
        }

        public IDataResult<List<BookImage>> GetAll()
        {
            return new SuccessDataResult<List<BookImage>>(_bookImageDal.GetAll(), "All Images Listed!");
        }

        public IResult Update(IFormFile formFile, BookImage bookImage)
        {
            bookImage.ImagePath = _fileHelper.Update(formFile, PathConstants.ImagesPath + bookImage.ImagePath, PathConstants.ImagesPath);
            _bookImageDal.Update(bookImage);
            return new SuccessResult("Image Updated");
        }
        private IResult CheckIfBookImageLimit(int bookId)
        {
            var result = _bookImageDal.GetAll(c => c.BookId == bookId).Count();
            if (result > 5)
            {
                return new ErrorResult(Messages.ImageLimitInvalid);
            }
            return new SuccessResult(Messages.ImageLimitSucceed);
        }
        private IDataResult<List<BookImage>> GetDefaultImage(int bookId)
        {
            List<BookImage> bookImages = new List<BookImage>();
            bookImages.Add(new BookImage { BookId = bookId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<BookImage>>(bookImages);
        }
        private IResult CheckBookImage(int bookId)
        {
            var result = _bookImageDal.GetAll(b => b.BookId == bookId).Count();
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
