using CloudinaryDotNet.Actions;
using Dtos;

namespace Rookies_EcommerceWebsite.Interfaces
{
    public interface IImageService
    {
        ImageUploadResult Upload(IFormFile file);
    }
}
