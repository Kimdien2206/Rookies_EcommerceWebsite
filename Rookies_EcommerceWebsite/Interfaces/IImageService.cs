using CloudinaryDotNet.Actions;
using Dtos;

namespace Rookies_EcommerceWebsite.Interfaces
{
    public interface IImageService
    {
        List<ImageUploadResult> Upload(List<IFormFile> file);
    }
}
