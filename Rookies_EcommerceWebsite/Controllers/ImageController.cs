using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
            if(images == null || images.Count == 0)
            {
                return Results.BadRequest();
            }
            var results = _imageService.Upload(images);

            return Results.Ok(results);
        }

        [HttpDelete]
        [Route("{id}")]
        public IResult DeleteImage(string id) 
        {
            if(id == null) { return Results.BadRequest();
            }
            var result = _imageService.Delete(id);
            return Results.Ok(result);
        }
    }
}
