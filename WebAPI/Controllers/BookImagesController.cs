using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookImagesController : ControllerBase
    {
        IBookImageService _bookImageService;

        public BookImagesController(IBookImageService bookImageService)
        {
            _bookImageService = bookImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _bookImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagebybookimageid")]
        public IActionResult Get(int bookImageId)
        {
            var result = _bookImageService.Get(bookImageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addbookimage")]
        public IActionResult Add([FromForm] IFormFile formFile, [FromForm] BookImage bookImage)
        {
            var result = _bookImageService.Add(formFile, bookImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        } 
    }
}