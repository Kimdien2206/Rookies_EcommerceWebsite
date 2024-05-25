using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService) 
        {
            this._imageService = imageService;
        }

        [HttpPost]
        public IResult UploadImage()
        {
            List<IFormFile> images = HttpContext.Request.Form.Files.ToList();
            var results = _imageService.Upload(images);

            return Results.Ok(results);
        }
    }
}
