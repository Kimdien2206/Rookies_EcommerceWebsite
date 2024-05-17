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
        public async Task<IResult> UploadImage(IFormFile formFile)
        {
            var result = _imageService.Upload(formFile);

            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Results.Ok(result);
            }

            return Results.UnprocessableEntity();
        }
    }
}
