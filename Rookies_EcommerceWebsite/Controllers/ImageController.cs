using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Interfaces;
using Rookies_EcommerceWebsite.Services;

namespace Rookies_EcommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ImageService _imageService;
        public ImageController(ImageService imageService) 
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
